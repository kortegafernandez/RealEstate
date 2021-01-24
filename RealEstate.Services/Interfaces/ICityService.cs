using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Core.DTOs;

namespace RealEstate.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllAsync();
    }
}
