using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DbMigration
{
    public class DbMigrationContext : VmsInformContext
    {
        public DbMigrationContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbMigrationContext(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}
