using Microsoft.EntityFrameworkCore;
using IdentityServerHost.Quickstart.UI;
using IdentityServer;
using IdentityServer.DbContexts;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var connectionString = configuration["ConnectionStrings:sqlConnection"];
var migrationAssembly = typeof(Program).Assembly.GetName().Name;
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityServer(options =>
    {
        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseInformationEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseSuccessEvents = true;
        // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
        options.EmitStaticAudienceClaim = true;
        options.Authentication.CookieLifetime = TimeSpan.FromHours(1);
    })
    .AddDeveloperSigningCredential()
    //.AddInMemoryIdentityResources(Config.IdentityResources)
    //.AddInMemoryApiScopes(Config.ApiScopes)
    //.AddInMemoryClients(Config.Clients)
    //.AddTestUsers(TestUsers.Users)
    .AddUsersService()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b =>
            b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationAssembly));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b =>
            b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationAssembly));
    });
builder.Services.AddDbContext<TestDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();
app.MapDefaultControllerRoute();
//InitializeDatabase.SeedData(app);
app.Run();