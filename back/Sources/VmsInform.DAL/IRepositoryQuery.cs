using System.Linq;

namespace VmsInform.DAL
{
    public interface IRepositoryQuery<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Query();
    }
}
