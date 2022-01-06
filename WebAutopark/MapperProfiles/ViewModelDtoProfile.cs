using AutoMapper;
using WebAutopark.BusinessLogicLayer.DataTransferObjects;
using WebAutopark.Models;

namespace WebAutopark.MapperProfiles
{
    public class ViewModelDTOProfile : Profile
    {
        public ViewModelDTOProfile()
        {
            CreateMap<DetailViewModel, DetailDTO>().ReverseMap();
            CreateMap<VehicleTypeViewModel, VehicleTypeDTO>().ReverseMap();
            CreateMap<VehicleViewModel, VehicleDTO>().ReverseMap();
            CreateMap<OrderViewModel, OrderDTO>().ReverseMap();
            CreateMap<OrderElementViewModel, OrderElementDTO>().ReverseMap();
        }
    }
}
