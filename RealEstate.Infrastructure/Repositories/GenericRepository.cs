using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Entities;
using RealEstate.Core.Interfaces;
using RealEstate.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly RealEstateContext context;

        public GenericRepository(RealEstateContext context)
        {
            this.context = context;            
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {            
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entity.CreatedOn = DateTime.UtcNow;
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entity.ModifiedOn = DateTime.UtcNow;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id == default) throw new ArgumentNullException("entity");

            T entity = context.Set<T>().SingleOrDefault(s => s.Id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
