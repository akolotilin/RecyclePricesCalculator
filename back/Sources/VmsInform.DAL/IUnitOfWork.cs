using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        Task<int> SaveAsync(CancellationToken cancellationToken);
        IVmsInformRepository<TEntity> GetRepository<TEntity>() where TEntity : VmsInformEntity;

        ITransaction TransactionManager { get; }
        ISqlProgrammability Programmability { get; }
    }
}
