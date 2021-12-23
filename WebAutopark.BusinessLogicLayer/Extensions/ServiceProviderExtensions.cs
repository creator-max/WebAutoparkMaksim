using Microsoft.Extensions.DependencyInjection;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Interfaces;
using WebAutopark.DataAccesLayer.Repositories;
using WebAutopark.DataAccesLayer.Repositories.Connection;
using WebAutopark.BusinessLogicLayer.Interfaces;
using WebAutopark.BusinessLogicLayer.Services;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;

namespace WebAutopark.BusinessLogicLayer.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionStringProvider, MsSqlStringProvider>();
            services.AddScoped<IRepository<Detail>, DetailRepository>();
            services.AddScoped<IRepository<Vehicle>, VehicleRepository>();
            services.AddScoped<IRepository<VehicleType>, VehicleTypeRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<OrderElement>, OrderElementRepository>();
        }

        public static void AddDtoServices(this IServiceCollection services)
        {
            services.AddScoped<IDtoService<VehicleDto>, VehicleService>();
            services.AddScoped<IDtoService<VehicleTypeDto>, VehicleTypeService>();
            services.AddScoped<IDtoService<DetailDto>, DetailService>();
        }
    }
}
