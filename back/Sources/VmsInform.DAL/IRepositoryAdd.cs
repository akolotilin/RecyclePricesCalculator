using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL
{
    public interface IRepositoryAdd<in TKey, TEntity>
        where TEntity : AbstractEntity<TKey>
    {
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
