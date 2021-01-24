using AutoMapper;
using RealEstate.Core.DTOs;
using RealEstate.Core.Entities;

namespace RealEstate.Infrastructure.Mappings
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>()
                .ForMember(o => o.Id, opt => opt.Ignore());

            CreateMap<PropertyCategory, PropertyCategoryDto>();
            CreateMap<PropertyCategoryDto, PropertyCategory>();

            CreateMap<Property, PropertyDto>()
                .ForMember(p => p.Owner, opt => opt.MapFrom(src => src.Owner));

            CreateMap<PropertyDto, Property>()
                .ForMember(p=>p.Id, opt=>opt.Ignore());

            CreateMap<City, CityDto>();
        }
    }
}
