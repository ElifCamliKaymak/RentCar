using RentCar.Application.Features.CQRS.Handlers.AboutHandlers;
using RentCar.Application.Features.CQRS.Handlers.BannerHandlers;
using RentCar.Application.Features.CQRS.Handlers.BrandHandlers;
using RentCar.Application.Features.CQRS.Handlers.CarHandlers;
using RentCar.Application.Features.CQRS.Handlers.CategoryHandlers;
using RentCar.Application.Features.CQRS.Handlers.ContactHandlers;
using RentCar.Application.Interfaces;
using RentCar.Application.Interfaces.BlogInterfaces;
using RentCar.Application.Interfaces.CarDescriptionInterfaces;
using RentCar.Application.Interfaces.CarFeatureInterfaces;
using RentCar.Application.Interfaces.CarInterfaces;
using RentCar.Application.Interfaces.CarPricingInterfaces;
using RentCar.Application.Interfaces.CarRentalInterfaces;
using RentCar.Application.Interfaces.RepositoryPattern.CommentRepositories;
using RentCar.Application.Interfaces.StatisticInterfaces;
using RentCar.Application.Interfaces.TagCloudInterfaces;
using RentCar.Bussiness.MapServices;
using RentCar.Persistance.Repositories;
using RentCar.Persistance.Repositories.BlogRepositories;
using RentCar.Persistance.Repositories.CarDescriptionRepositories;
using RentCar.Persistance.Repositories.CarFeatureRepositories;
using RentCar.Persistance.Repositories.CarPricingRepositories;
using RentCar.Persistance.Repositories.CarRentalRepositories;
using RentCar.Persistance.Repositories.CarRepositories;
using RentCar.Persistance.Repositories.CommentRepositories;
using RentCar.Persistance.Repositories.StatisticRespositories;
using RentCar.Persistance.Repositories.TagCloudRepositories;

namespace RentCar.WebApi.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
            services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
            services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
            services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
            services.AddScoped(typeof(IStatisticRepository), typeof(StatisticRepository));
            services.AddScoped(typeof(ICarRentalRepository), typeof(CarRentalRepository));
            services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
            services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
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

        public static void ConfigureCarRegistration(this IServiceCollection services)
        {
            services.AddScoped<GetCarQueryHandler>();
            services.AddScoped<GetCarByIdQueryHandler>();
            services.AddScoped<CreateCarCommandHandler>();
            services.AddScoped<UpdateCarCommandHandler>();
            services.AddScoped<RemoveCarCommandHandler>();
            services.AddScoped<GetCarWithBrandQueryHandler>();
            services.AddScoped<GetLastFiveCarsWithBrandQueryHandler>();
            services.AddScoped<GetCarsByBrandIdQueryHandler>();
        }        
        
        public static void ConfigureCategoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
        }    
        public static void ConfigureContactRegistration(this IServiceCollection services)
        {
            services.AddScoped<GetContactQueryHandler>();
            services.AddScoped<GetContactByIdQueryHandler>();
            services.AddScoped<CreateContactCommandHandler>();
            services.AddScoped<UpdateContactCommandHandler>();
            services.AddScoped<RemoveContactCommandHandler>();
        }

        public static void ConfigureCommentRegistration(this IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ICommentRepository), typeof(CommentRepository));
            services.AddScoped<CommentService>();
        }
    }
}
