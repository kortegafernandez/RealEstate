using AutoMapper;
using RealEstate.Core.DTOs;
using RealEstate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Infrastructure.Mappings
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();

            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>()
                .ForMember(o => o.Id, opt => opt.Ignore());

            CreateMap<PropertyCategory, PropertyCategoryDto>();
            CreateMap<PropertyCategoryDto, PropertyCategory>();

            CreateMap<Property, PropertyDto>();
            CreateMap<PropertyDto, Property>()
                .ForMember(p=>p.Id, opt=>opt.Ignore());
        }
    }
}
