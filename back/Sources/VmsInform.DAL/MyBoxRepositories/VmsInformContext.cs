using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Immutable;
using System.Linq;
using VmsInform.DAL.Domain.UserNotifications;

namespace VmsInform.DAL.MyBoxRepositories
{
    public class VmsInformContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

        public static volatile ImmutableHashSet<Type> SupportedRepositoryTypes;
        public DbSet<UserNotification> UserNotifications { get; set; }

        public VmsInformContext(IConfiguration configuration, ILoggerFactory loggerFactory = null)
        {
            _configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        public VmsInformContext(DbContextOptions options)
            : base(options)
        {   
        }

        public static bool IsSupportedRepository(Type entityType)
        {
            var set = SupportedRepositoryTypes;
            if (set == null)
            {
                throw new InvalidOperationException("DbContext wasn't initialized");
            }

            return SupportedRepositoryTypes.Contains(entityType);
        }

        public static bool IsSupportedRepository<TEntity>()
        {
            return IsSupportedRepository(typeof(TEntity));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VmsInformContext).Assembly);

            SupportedRepositoryTypes = modelBuilder.Model.GetEntityTypes()
                .Select(a => a.ClrType)
                .Where(t => typeof(VmsInformEntity).IsAssignableFrom(t))
                .ToImmutableHashSet();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString)
                    .UseLazyLoadingProxies();
                
                if (_loggerFactory != null)
                {
                    optionsBuilder.UseLoggerFactory(_loggerFactory);
                }
            }
        }
    }
}
