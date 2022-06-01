using System;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL
{
    public interface IVmsInformRepository<TEntity> : IRepository<long, TEntity>
        where TEntity : VmsInformEntity
    {
    }
}
