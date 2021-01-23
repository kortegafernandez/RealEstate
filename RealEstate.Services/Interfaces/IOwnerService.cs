using RealEstate.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Services.Interfaces
{
    public interface IOwnerService
    {
        Task DeleteAsync(int id);
        Task<IEnumerable<OwnerDto>> GetAllAsync();
        Task<OwnerDto> GetByIdAsync(int id);
        Task<OwnerDto> InsertAsync(OwnerDto ownerDto);
        Task<OwnerDto> UpdateAsync(OwnerDto ownerDto);
    }
}