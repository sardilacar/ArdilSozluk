using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> GetAll(bool is_track = true);
        IQueryable<T> GetList(Expression<Func<T, bool>> expression, bool is_track = true);
        Task<T> GetSingle(Expression<Func<T, bool>> expression, bool is_track = true);
        IQueryable<T> TrackState(bool is_track = true);
    }
}
