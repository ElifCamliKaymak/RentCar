using RentCar.Application.Features.CQRS.Handlers.AboutHandlers;
using RentCar.Application.Features.CQRS.Handlers.BannerHandlers;
using RentCar.Application.Features.CQRS.Handlers.BrandHandlers;
using RentCar.Application.Interfaces;
using RentCar.Persistance.Repositories;

namespace RentCar.WebApi.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static void ConfigureAboutRegistration(this IServiceCollection services)
        {
            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();
        }

        public static void ConfigureBannerRegistration(this IServiceCollection services)
        {
            services.AddScoped<GetBannerQueryHandler>();
            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<CreateBannerCommandHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();
            services.AddScoped<RemoveBannerCommandHandler>();
        }

        public static void ConfigureBrandRegistration(this IServiceCollection services)
        {
            services.AddScoped<GetBrandQueryHandler>();
            services.AddScoped<GetBrandByIdQueryHandler>();
            services.AddScoped<CreateBrandCommandHandler>();
            services.AddScoped<UpdateBrandCommandHandler>();
            services.AddScoped<RemoveBrandCommandHandler>();
        }
    }
}
