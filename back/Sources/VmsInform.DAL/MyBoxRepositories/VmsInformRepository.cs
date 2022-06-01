using Microsoft.EntityFrameworkCore;

namespace VmsInform.DAL.MyBoxRepositories
{
    public sealed class VmsInformRepository<TEntity> : Repository<long, TEntity>, IVmsInformRepository<TEntity>
        where TEntity : VmsInformEntity
    {
        public VmsInformRepository(DbContext dbContext)
            :base(dbContext)
        {
        }
    }
}
