//using IdentityServer4.EntityFramework.DbContexts;
//using IdentityServer4.EntityFramework.Options;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//namespace IdentityServer
//{
//    public class ConfigurationDbContextFactory: IDesignTimeDbContextFactory<ConfigurationDbContext>
//    {
//        // Add-Migration InitialConfigurationMigration -c ConfigurationDbContext -o Migrations/IdentityServer/ConfigurationDb
//        // Update-Database -c ConfigurationDbContext
//        const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IdentityServer;Integrated Security=True";
//        public ConfigurationDbContext CreateDbContext(string[] args)
//        {
//            var builder = new DbContextOptionsBuilder<ConfigurationDbContext>();
//            builder.UseSqlServer(ConnectionString, b => b.MigrationsAssembly("IdentityServer"));
//            return new ConfigurationDbContext(builder.Options,new ConfigurationStoreOptions
//            {
//            });
//        }
//    }
//    public class PersistedGrantDbContextFactory : IDesignTimeDbContextFactory<PersistedGrantDbContext>
//    {
//        // Add-Migration InitialPersistedGranMigration -c PersistedGrantDbContext -o Migrations/IdentityServer/PersistedGrantDb
//        // Update-Database -c PersistedGrantDbContext
//        const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IdentityServer;Integrated Security=True";
//        public PersistedGrantDbContext CreateDbContext(string[] args)
//        {
//            var builder = new DbContextOptionsBuilder<PersistedGrantDbContext>();
//            builder.UseSqlServer(ConnectionString, b => b.MigrationsAssembly("IdentityServer"));
//            return new PersistedGrantDbContext(builder.Options, new OperationalStoreOptions
//            {
//            });
//        }
//    }
//}
