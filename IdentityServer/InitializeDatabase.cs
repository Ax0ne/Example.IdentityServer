using IdentityServer.DbContexts;
using IdentityServer.Models;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;

namespace IdentityServer
{
    public class InitializeDatabase
    {
        public static void SeedData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TestDbContext>();
                if (!context.Users.Any())
                {
                    context.Users.Add(new User
                    {
                        //Id = 1,
                        Name = "zhang",
                        Nick = "小张",
                        Password = "asd",
                        PhoneNumber = "13812345678"
                    });
                    context.Users.Add(new User
                    {
                        //Id = 2,
                        Name = "wang",
                        Nick = "小王",
                        Password = "asd",
                        PhoneNumber = "13812345679"
                    });
                    context.SaveChanges();
                }
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                if (!context.Clients.Any())
                {
                    foreach (var client in Config.Clients)
                    {
                        context.Clients.Add(client.ToEntity());
                    }

                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.IdentityResources)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }

                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var resource in Config.ApiScopes)
                    {
                        context.ApiScopes.Add(resource.ToEntity());
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}