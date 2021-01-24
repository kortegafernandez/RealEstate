using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Entities;
using RealEstate.Core.Interfaces;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories
{
    public class OwnerRepository: GenericRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(RealEstateContext context) : base(context) { }

        public async Task<Owner> GetByIdendtificationNumberAsync(string identificationNumber)
        {
            return await context.Owners.FirstOrDefaultAsync(o => o.IdentificationNumber.ToLower() == identificationNumber.ToLower());
        }
    }
}
