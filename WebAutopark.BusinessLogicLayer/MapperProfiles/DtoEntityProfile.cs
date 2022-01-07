using AutoMapper;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.BusinessLogicLayer.Services.Enums;
using WebAutopark.DataAccesLayer.Entities;
using WebAutopark.DataAccesLayer.Repositories.Enums;

namespace WebAutopark.BusinessLogicLayer.MapperProfiles
{
    public class DtoEntityProfile : Profile
    {
        public DtoEntityProfile()
        {
            CreateMap<DetailDto, Detail>().ReverseMap();
            CreateMap<VehicleDto, Vehicle>().ReverseMap();
            CreateMap<VehicleTypeDto, VehicleType>().ReverseMap();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<OrderElementDto, OrderElement>().ReverseMap();
            CreateMap<SortOrderDto, SortOrder>().ReverseMap();
        }
    }
}