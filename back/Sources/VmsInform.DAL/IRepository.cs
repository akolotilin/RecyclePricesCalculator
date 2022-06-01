using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL
{
    public interface IRepository<in TKey, TEntity> : IRepositoryQuery<TEntity>,
        IRepositoryAdd<TKey, TEntity> where TEntity : AbstractEntity<TKey>
    {
        void Update(TEntity entity);
        TEntity Delete(TKey id);
        TEntity Delete(TEntity entity);
        TEntity Get(TKey id);
        Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken);
    }
}
