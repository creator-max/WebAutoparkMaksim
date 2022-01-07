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
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionStringProvider, MsSqlStringProvider>();
            services.AddScoped<IRepository<Detail>, DetailRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IRepository<VehicleType>, VehicleTypeRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRepository<OrderElement>, OrderElementRepository>();
            return services;
        }

        public static IServiceCollection AddDtoServices(this IServiceCollection services)
        {
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IDataService<VehicleTypeDto>, VehicleTypeService>();
            services.AddScoped<IDataService<DetailDto>, DetailService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderElementService, OrderElementService>();
            return services;    
        }
    }
}
