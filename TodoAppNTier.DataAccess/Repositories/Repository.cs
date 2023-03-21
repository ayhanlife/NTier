using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DataAccess.Context;
using TodoAppNTier.DataAccess.Interfaces;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly TodoContext context;

        public Repository(TodoContext context)
        {
            this.context = context;
        }

        public async Task Create(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking
                 ? await context.Set<T>().SingleOrDefaultAsync(filter)
                 : await context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> Find(object id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQueryable()
        {
            return context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            //var deletedEntity = context.Set<T>().Find(entity);
            context.Set<T>().Remove(entity);
        }

        public void Update(T entity, T unchanged) // 
        {
            //var updateEntity = context.Set<T>().Find(entity.Id);
            context.Entry(unchanged).CurrentValues.SetValues(entity);

            //context.Set<T>().Update(entity);
        }
    }
}
