using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace VmsInform.DAL
{
    public interface ITransaction
    {
        IDbContextTransaction Begin();
        Task<IDbContextTransaction> BeginAsync(CancellationToken cancellationToken = default);
        void Commit();
        void Rollback();
    }
}
