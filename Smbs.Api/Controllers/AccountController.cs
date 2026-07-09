using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Smbs.Api.Models;
using Smbs.Api.Services;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtAuthenticationService _service;

        public AccountController(JwtAuthenticationService service)
        {
            _service = service;
        }
        //verilmis login request modeline gore access token almaq ucun yazilmis endpoint
        [HttpPost("GetAccessToken")]
        [EnableRateLimiting("anon-limit")]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var result=await _service.Authenticate(model);
            if (result == null) {
                return Unauthorized();
            
            }
            return result;
        }
        //access tokeni yenilemek ucun yazilmis endpoint
        [HttpPost("RefreshAccessToken")]
        [EnableRateLimiting("anon-limit")]
        public async Task<ActionResult<LoginResponseModel>> Refresh(RefreshRequestModel model)
        {
            if (model.Token == null)
            {
                return BadRequest("Invalid client request");
            }
            var result=await _service.ValidateToken(model.Token);
            if (result == null)
            {
                return Unauthorized();
            }
            return result;
        }
    }
}
