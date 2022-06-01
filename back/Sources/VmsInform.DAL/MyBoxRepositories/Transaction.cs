using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace VmsInform.DAL.MyBoxRepositories
{
    public class Transaction : ITransaction
    {
        private readonly DbContext _dbContext;
        public Transaction(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IDbContextTransaction Begin() => _dbContext.Database.BeginTransaction();

        public Task<IDbContextTransaction> BeginAsync(CancellationToken cancellationToken = default)
            => _dbContext.Database.BeginTransactionAsync(cancellationToken);


        public void Commit() => _dbContext.Database.CommitTransaction();

        public void Rollback() => _dbContext.Database.RollbackTransaction();

        public static ITransaction Create(DbContext dbContext) => new Transaction(dbContext);
        
    }
}
