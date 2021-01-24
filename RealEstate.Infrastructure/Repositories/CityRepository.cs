using RealEstate.Core.Entities;
using RealEstate.Core.Interfaces;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(RealEstateContext context) : base(context) { }
    }
}
