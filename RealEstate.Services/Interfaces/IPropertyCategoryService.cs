using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Core.DTOs;

namespace RealEstate.Services.Interfaces
{
    public interface IPropertyCategoryService
    {
        Task<IEnumerable<PropertyCategoryDto>> GetAllAsync();
    }
}
