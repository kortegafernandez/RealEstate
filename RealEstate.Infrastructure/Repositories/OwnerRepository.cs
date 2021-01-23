using RealEstate.Core.Entities;
using RealEstate.Core.Interfaces;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories
{
    public class OwnerRepository: GenericRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(RealEstateContext context) : base(context) { }
    }
}
