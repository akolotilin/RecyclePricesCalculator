using Microsoft.EntityFrameworkCore;

namespace VmsInform.DAL.MyBoxRepositories
{
    internal sealed class SqlProgrammability : ISqlProgrammability
    {
        private readonly DbContext _dbContext;
        public SqlProgrammability(DbContext dbContext)
        {
            _dbContext = dbContext; 
        }
    }
}
