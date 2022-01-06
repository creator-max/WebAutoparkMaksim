using AutoMapper;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.DataAccesLayer.Entities;

namespace WebAutopark.BusinessLogicLayer.MapperProfiles
{
    public class DTOEntityProfile : Profile
    {
        public DTOEntityProfile()
        {
            CreateMap<DetailDTO, Detail>().ReverseMap();
            CreateMap<VehicleDTO, Vehicle>().ReverseMap();
            CreateMap<VehicleTypeDTO, VehicleType>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<OrderElementDTO, OrderElement>().ReverseMap();
        }
    }
}