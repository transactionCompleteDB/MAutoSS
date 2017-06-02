using System.Data.Entity;

using MAutoSS.Data.Repositories.Contracts;

namespace MAutoSS.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
