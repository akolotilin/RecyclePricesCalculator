using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace VmsInform.DAL.MyBoxRepositories
{
    public class VmsInformUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly IDictionary<Type, object> _repositories;

        public VmsInformUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<Type, object>();
            TransactionManager = new Transaction(_dbContext);
            Programmability = new SqlProgrammability(_dbContext);
        }

        public VmsInformUnitOfWork(string connectionString, ILoggerFactory loggerFactory)
            :this(new VmsInformContext(connectionString, loggerFactory))
        {

        }

        public VmsInformUnitOfWork(string connectionString, ITransaction transactionManager, ILoggerFactory loggerFactory)
            : this(connectionString, loggerFactory)
        {
            TransactionManager = transactionManager;
        }

        public ITransaction TransactionManager { get; }

        public ISqlProgrammability Programmability { get; }

        public void Dispose()
        {
            _repositories.Clear();
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        public IVmsInformRepository<TEntity> GetRepository<TEntity>() where TEntity : VmsInformEntity
        {
            var entityType = typeof(TEntity);

            if (!VmsInformContext.IsSupportedRepository<TEntity>())
            {
                throw new ApplicationException($"Type {entityType} hasn't included in DbContext");
            }

            if (_repositories.ContainsKey(entityType))
            {
                _repositories.Add(entityType, new VmsInformRepository<TEntity>(_dbContext));
            }

            return _repositories[entityType] as IVmsInformRepository<TEntity>;
        }

        public int Save() => _dbContext.SaveChanges();
        public Task<int> SaveAsync(CancellationToken cancellationToken)  
            => _dbContext.SaveChangesAsync(cancellationToken);
    }
}
