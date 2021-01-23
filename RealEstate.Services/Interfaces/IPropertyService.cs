using RealEstate.Core.DTOs;
using RealEstate.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Services.Interfaces
{
    public interface IPropertyService
    {
        Task DeleteAsync(int id);
        Task<IEnumerable<PropertyDto>> GetAllAsync();
        Task<PropertyDto> GetByIdAsync(int id);
        Task<PropertyDto> InsertAsync(PropertyDto propertyDto);
        Task<PropertyDto> UpdateAsync(PropertyDto propertyDto);
    }
}