using AutoMapper;
using RealEstate.Core.DTOs;
using RealEstate.Core.Entities;
using RealEstate.Core.Exceptions;
using RealEstate.Core.Interfaces;
using RealEstate.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;
        public PropertyService(IPropertyRepository propertyRepository,
            IOwnerService ownerService,
            IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _ownerService = ownerService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyDto>> GetAllAsync()
        {
            var properties = await _propertyRepository.GetAllAsync();
            var propertiesDtos = _mapper.Map<IEnumerable<PropertyDto>>(properties);
            return propertiesDtos;
        }

        public async Task<PropertyDto> GetByIdAsync(int id)
        {
            var property = await _propertyRepository.GetByIdAsync(id);
            var propertyDto = _mapper.Map<PropertyDto>(property);
            return propertyDto;
        }

        public async Task<PropertyDto> InsertAsync(PropertyDto propertyDto)
        {
            if (propertyDto.OwnerId != default)
            {
                propertyDto.Owner = null;
                var owner = await _ownerService.GetByIdAsync(propertyDto.OwnerId);

                if (owner == null)
                {
                    throw new RealEstateException("Owner doesn't exists.");
                }
            }

            var property = _mapper.Map<Property>(propertyDto);
            await _propertyRepository.InsertAsync(property);
            propertyDto = _mapper.Map<PropertyDto>(property);

            return propertyDto;
        }

        public async Task<PropertyDto> UpdateAsync(PropertyDto propertyDto)
        {
            var currentProperty = await _propertyRepository.GetByIdAsync(propertyDto.Id);

            if(currentProperty == null)
            {
                throw new RealEstateException($"Property with id {propertyDto.Id} doesn't exists.");
            }

            currentProperty.Address1 = propertyDto.Address1;
            currentProperty.Address2 = propertyDto.Address2;
            currentProperty.Area = propertyDto.Area;
            currentProperty.CategoryId = propertyDto.CategoryId;
            currentProperty.CityId = propertyDto.CityId;
            currentProperty.Name = propertyDto.Name;
            currentProperty.OwnerId = propertyDto.OwnerId;
            currentProperty.PostalCode = propertyDto.PostalCode;
            currentProperty.Price = propertyDto.Price;
            await _propertyRepository.UpdateAsync(currentProperty);
            propertyDto = _mapper.Map<PropertyDto>(currentProperty);

            return propertyDto;
        }

        public async Task DeleteAsync(int id)
        {
            await _propertyRepository.DeleteAsync(id);
        }
    }
}
