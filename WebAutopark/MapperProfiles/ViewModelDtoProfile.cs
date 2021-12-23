using AutoMapper;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.Models;

namespace WebAutopark.MapperProfiles
{
    public class ViewModelDtoProfile : Profile
    {
        public ViewModelDtoProfile()
        {
            CreateMap<DetailViewModel, DetailDto>().ReverseMap();
            CreateMap<VehicleTypeViewModel, VehicleTypeDto>().ReverseMap();
            CreateMap<VehicleViewModel, VehicleDto>().ReverseMap();

        }
    }
}
