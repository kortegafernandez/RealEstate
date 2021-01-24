using RealEstate.Core.Entities;
using RealEstate.Core.Interfaces;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories
{
    public class PropertyCategoryRepository : GenericRepository<PropertyCategory>, IPropertyCategoryRepository
    {
        public PropertyCategoryRepository(RealEstateContext context) : base(context) { }
    }
}
