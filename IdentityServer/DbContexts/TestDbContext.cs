using IdentityServer.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.DbContexts
{
    public class TestDbContext : DbContext
    {
        public TestDbContext()
        {
            
        }
        public TestDbContext(DbContextOptions options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if(!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IdentityServer;Integrated Security=True");
        //    }
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<User> Users { get; set; }
    }
}