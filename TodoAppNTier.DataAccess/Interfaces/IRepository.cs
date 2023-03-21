using System.Linq.Expressions;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.DataAccess.Interfaces
{
    public interface IRepository<T> where T :   BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        Task<T> Find(object id);
        Task Create(T entity);
        void Update(T entity, T unchanged);
        void Remove(T entity);
        IQueryable<T> GetQueryable();
    }
}
