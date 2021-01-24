using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RealEstate.Core.DTOs;
using RealEstate.Core.Interfaces;
using RealEstate.Services.Interfaces;

namespace RealEstate.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository propertyCategoryRepository, IMapper mapper)
        {
            _cityRepository = propertyCategoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {
            var categories = await _cityRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CityDto>>(categories);
        }
    }
}
