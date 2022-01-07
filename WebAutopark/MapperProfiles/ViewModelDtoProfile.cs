using AutoMapper;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.Models;

namespace WebAutopark.MapperProfiles
{
    public class ViewModelDTOProfile : Profile
    {
        public ViewModelDTOProfile()
        {
            CreateMap<DetailViewModel, DetailDto>().ReverseMap();
            CreateMap<VehicleTypeViewModel, VehicleTypeDto>().ReverseMap();
            CreateMap<VehicleViewModel, VehicleDto>().ReverseMap();
            CreateMap<OrderViewModel, OrderDto>().ReverseMap();
            CreateMap<OrderElementViewModel, OrderElementDto>().ReverseMap();
        }
    }
}
