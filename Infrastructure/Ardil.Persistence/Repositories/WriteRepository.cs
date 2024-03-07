using Ardil.Application.Repositories;
using Ardil.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly ArdilDbContext _context;

        public WriteRepository(ArdilDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
          
        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entry = await Table.AddAsync(entity);
            return entry.State == EntityState.Added;
        }

        public async Task<bool> AddAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entry = Table.Remove(entity);
            return entry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var entity = await Table.FindAsync(Guid.Parse(id));
            return Remove(entity);
        }

        public bool Update(T entity)
        {
            EntityEntry<T> entry = Table.Update(entity);
            return entry.State == EntityState.Modified;
        }
    }
}
