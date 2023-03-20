using TodoAppNTier.DataAccess.Context;
using TodoAppNTier.DataAccess.Interfaces;
using TodoAppNTier.DataAccess.Repositories;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly TodoContext context;
        public Uow(TodoContext context)
        {
            this.context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(context);
        }

        public async Task SavaChange()
        {
            await context.SaveChangesAsync();
        }
    }
}
