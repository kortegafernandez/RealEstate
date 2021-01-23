using RealEstate.Core.Entities;
using RealEstate.Core.Interfaces;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories
{
    public class PropertyRepository: GenericRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(RealEstateContext context) : base(context) { }
        
    }
}
