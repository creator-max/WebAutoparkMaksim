using AutoMapper;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.DataAccesLayer.Entities;

namespace WebAutopark.BusinessLogicLayer.MapperProfiles
{
    public class DtoEntityProfile : Profile
    {
        public DtoEntityProfile()
        {
            CreateMap<DetailDto, Detail>().ReverseMap();
            CreateMap<VehicleDto, Vehicle>().ReverseMap();
            CreateMap<VehicleTypeDto, VehicleType>().ReverseMap();
        }
    }
}
