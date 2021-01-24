using System.Threading.Tasks;
using RealEstate.Core.Entities;

namespace RealEstate.Core.Interfaces
{
    public interface IOwnerRepository: IGenericRepository<Owner>
    {
        Task<Owner> GetByIdendtificationNumberAsync(string identificationNumber);
    }
}
