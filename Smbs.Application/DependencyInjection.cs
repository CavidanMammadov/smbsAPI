using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Smbs.Application.Services.Abstract;
using Smbs.Application.Services.Concrete;


namespace Smbs.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(a => a.RegisterServicesFromAssemblyContaining<ApplicationAssembly>());

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<ApplicationAssembly>();

            //Register CloudinaryService
            services.AddScoped<ICloudinaryService, CloudinaryService>();

            return services;
        }
    }
}
