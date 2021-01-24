using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Entities;
using RealEstate.Core.Interfaces;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories
{
    public class PropertyRepository: GenericRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(RealEstateContext context) : base(context) { }

        public override async Task<IEnumerable<Property>> GetAllAsync()
        {
            var query = context.Properties
                .Include(p => p.Owner)
                .Include(p => p.City)
                .Include(p => p.Category);

            return await query.ToListAsync();
        }

        public override async Task<Property> GetByIdAsync(int id)
        {
            return await context.Properties
                .Include(p => p.Owner)
                .Include(p => p.City)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
