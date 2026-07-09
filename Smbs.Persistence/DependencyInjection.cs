using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smbs.Domain.Interfaces;
using Smbs.Persistence.Context;
using Smbs.Persistence.Repositories;

namespace Smbs.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Register repositories
            services.AddScoped<AppDbContext>();

            services.AddScoped(typeof(Smbs.Domain.Interfaces.IRepository<>), typeof(Smbs.Persistence.Repositories.Repository<>));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();

            services.AddScoped<IBlogRepository, BlogRepository>();

            services.AddScoped<ILandingPageRepository, LandingPageRepository>();

            services.AddScoped<ITrainerRespository, TrainerRespository>();

            services.AddScoped<ITrainingRepository, TrainingRepository>();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IApplymentRepository, ApplymentRepository>();

            return services;
        }
    }
}
