using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RealEstate.Core.DTOs;
using RealEstate.Core.Interfaces;
using RealEstate.Services.Interfaces;

namespace RealEstate.Services
{
    public class PropertyCategoryService : IPropertyCategoryService
    {
        private readonly IPropertyCategoryRepository _propertyCategoryRepository;
        private readonly IMapper _mapper;

        public PropertyCategoryService(IPropertyCategoryRepository propertyCategoryRepository, IMapper mapper)
        {
            _propertyCategoryRepository = propertyCategoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyCategoryDto>> GetAllAsync()
        {
            var categories = await _propertyCategoryRepository.GetAllAsync();
            
            return _mapper.Map<IEnumerable<PropertyCategoryDto>>(categories);
        }
    }
}
