using Microsoft.EntityFrameworkCore;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DbMigration
{
    public class DbMigrationContext : VmsInformContext
    {
        public DbMigrationContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbMigrationContext(string connectionString)
            : base(connectionString)
        {

        }
    }
}
