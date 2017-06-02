using System;

namespace MAutoSS.Data.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
