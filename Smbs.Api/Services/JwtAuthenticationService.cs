using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Smbs.Api.Models;
using Smbs.Application.Features.MediatR.Commands.RefreshTokens;
using Smbs.Application.Features.MediatR.Queries.RefreshTokens;
using Smbs.Application.Features.MediatR.Queries.Users;
using Smbs.Application.Features.MediatR.Results.Users;
using Smbs.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Smbs.Api.Services
{
    public class JwtAuthenticationService(IConfiguration config, IMediator mediator, IPasswordHasher<User> _hasher)
    {




        public async Task<LoginResponseModel> Authenticate(LoginRequestModel requestModel)
        {
            if (string.IsNullOrEmpty(requestModel.UserName) || string.IsNullOrEmpty(requestModel.Password))
            {

                return null;
            }
            var result = await mediator.Send(new GetUserByUserNameQuery(requestModel.UserName));
            if (result == null || result.Success == null || result.Success.ResponseValue == null) { return null; }
            var user = new User();
            var verify = _hasher.VerifyHashedPassword(user, result.Success.ResponseValue.UserPasswordHash, requestModel.Password);
            if (result == null || verify == PasswordVerificationResult.Failed)
            {
                return null;
            }
            return await GenerateToken(result.Success.ResponseValue);
        }
        public async Task<LoginResponseModel> GenerateToken(UserResult result)
        {
            var issuer = config["JwtConfig:Issuer"];
            var audience = config["JwtConfig:Audience"];
            var key = Encoding.UTF8.GetBytes(config["JwtConfig:Key"]!);
            var tokenValidity = config.GetValue<int>("JwtConfig:TokenValidityMin");
            var tokenValidityTime = DateTime.Now.AddMinutes(tokenValidity);
            string roleName = result.UserRoleId switch
            {
                1 => "Admin",
                2 => "Trainer",
                3 => "Student",
                _ => "Unknown"
            };

            var claims = new List<Claim>
{
    new Claim(ClaimTypes.NameIdentifier, result.UserId.ToString()),
    new Claim(ClaimTypes.Name, result.UserUserName),
    new Claim(ClaimTypes.Email, result.UserEmail),
    new Claim(ClaimTypes.Role, roleName)
};
            var token = new JwtSecurityToken(issuer, audience,claims:claims, expires: tokenValidityTime, signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key), Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new LoginResponseModel
            {
                AccessToken = accessToken,
                ExpireIn = (int)tokenValidityTime.Subtract(DateTime.Now).TotalSeconds,
                UserName = result.UserUserName,
                RefreshToken = await GenerateRefreshToken(result.UserId)

            };

        }
        public async Task<LoginResponseModel> ValidateToken(string token)
        {
            var refreshToken = await mediator.Send(new GetRefreshTokenByTokenQuery(token));
            if (refreshToken.Success == null || refreshToken.Success.ResponseValue.RefreshTokenExpireIn < DateTime.UtcNow)
            {
                return null;

            }
            var user = await mediator.Send(new GetUserByUserIdQuery(refreshToken.Success.ResponseValue.RefreshTokenUserId));
            if (user.Success == null)
            {
                return null;
;            }
            return await GenerateToken(user.Success.ResponseValue);
        }
        public async Task<string> GenerateRefreshToken(int userId)
        {
            var token = new CreateRefreshTokenCommand
            {
                RefreshTokenUserId = userId,
                RefreshTokenToken = Guid.NewGuid().ToString(),
                RefreshTokenExpireIn = DateTime.Now.AddDays(config.GetValue<int>("JwtConfig:RefreshTokenValidityMin"))
            };
            var result = await mediator.Send(token);
            return result.Success.ResponseValue.RefreshTokenToken;
        }
    }
}
