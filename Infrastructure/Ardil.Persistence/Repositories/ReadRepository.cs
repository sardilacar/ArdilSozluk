using Ardil.Application.Repositories;
using Ardil.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly ArdilDbContext _context;
        public ReadRepository(ArdilDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll(bool is_track = true) {
            IQueryable<T> table = TrackState(is_track);
            return table;
        }
        public async Task<T> GetSingle(Expression<Func<T, bool>> expression, bool is_track = true)
        {
            IQueryable<T> table = TrackState(is_track);
            return await table.FirstOrDefaultAsync(expression);
        }
        public IQueryable<T> GetList(Expression<Func<T, bool>> expression, bool is_track = true)
        {
            IQueryable<T> table = TrackState(is_track);
            return table.Where(expression);
        }

        public IQueryable<T> TrackState(bool is_track = true)
        {
            var query = Table.AsQueryable();
            if (!is_track)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
    }
}
