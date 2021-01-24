using AutoMapper;
using RealEstate.Core.DTOs;
using RealEstate.Core.Entities;
using RealEstate.Core.Exceptions;
using RealEstate.Core.Interfaces;
using RealEstate.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerService(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OwnerDto>> GetAllAsync()
        {
            var owners =  await _ownerRepository.GetAllAsync();
            var ownerDtos = _mapper.Map<IEnumerable<OwnerDto>>(owners);
            
            return ownerDtos;
        }

        public async Task<OwnerDto> GetByIdAsync(int id)
        {
            var owner = await _ownerRepository.GetByIdAsync(id);
            var ownerDto = _mapper.Map<OwnerDto>(owner);
            
            return ownerDto;
        }

        public async Task<OwnerDto> InsertAsync(OwnerDto ownerDto)
        {
            var existingOwner = await GetByIdendtificationNumberAsync(ownerDto.IdentificationNumber);

            if(existingOwner != null)
            {
                throw new RealEstateException($"Owner with identification number '{ownerDto.IdentificationNumber}' already exists.");
            }

            var owner = _mapper.Map<Owner>(ownerDto);
            await _ownerRepository.InsertAsync(owner);
            ownerDto = _mapper.Map<OwnerDto>(owner);
            
            return ownerDto;
        }

        public async Task<OwnerDto> UpdateAsync(OwnerDto ownerDto)
        {
            var currentOwner = await _ownerRepository.GetByIdAsync(ownerDto.Id);

            _mapper.Map(ownerDto, currentOwner);
            await _ownerRepository.UpdateAsync(currentOwner);
            ownerDto = _mapper.Map<OwnerDto>(currentOwner);
            
            return ownerDto;
        }

        public async Task<OwnerDto> GetByIdendtificationNumberAsync(string identificationNumber)
        {
            var owner = await _ownerRepository.GetByIdendtificationNumberAsync(identificationNumber);
            var ownerDto = _mapper.Map<OwnerDto>(owner);
            
            return ownerDto;
        }

        public async Task DeleteAsync(int id)
        {
            await _ownerRepository.DeleteAsync(id);
        }       
    }
}
