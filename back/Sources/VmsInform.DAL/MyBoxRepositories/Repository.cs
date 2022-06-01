using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VmsInform.DAL.MyBoxRepositories
{
    public class Repository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : AbstractEntity<TKey>
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _data;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _data = dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity) => _data.Add(entity).Entity;
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entry = await _data.AddAsync(entity, cancellationToken);
            return entry.Entity;
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) 
            => _data.AddRangeAsync(entities, cancellationToken);

        public TEntity Delete(TKey id)
        {
            var entity = _data.First(a => a.Id.Equals(id));
            return Delete(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _data.Attach(entity);
            }
            return _data.Remove(entity).Entity;
        }

        public TEntity Get(TKey id)
        {
            return _data.FirstOrDefault(a => a.Id.Equals(id));
        }

        public async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken)
        {
            return await _data.FirstOrDefaultAsync(a => a.Id.Equals(id), cancellationToken);
        }

        public IQueryable<TEntity> Query() => _data;

        public void Update(TEntity entity)
        {
            _data.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
