using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RentCar.WebApi.Extensions
{
    public static class MeditorExtension
    {
        public static void AddMediatorServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MeditorExtension).Assembly));
        }
    }
}
