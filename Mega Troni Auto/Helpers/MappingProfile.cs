using AutoMapper;
using Mega_Troni_Auto.Models;

namespace Mega_Troni_Auto.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleCreateDto, Vehicle>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DateAdded, opt => opt.Ignore())
                .ForMember(dest => dest.IsSold, opt => opt.Ignore());

            CreateMap<VehicleUpdateDto, Vehicle>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DateAdded, opt => opt.Ignore());
        }
    }
}
