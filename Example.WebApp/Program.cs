using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = "Cookies";
        options.DefaultChallengeScheme = "oidc";
    })
    .AddCookie(options=>
    {
        //options.Cookie.Expiration = TimeSpan.FromHours(1); // Cookie.Expiration is ignored
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
    })
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = "https://localhost:44311/";
        options.ClientId = "webapp";
        options.ClientSecret = "secret";
        options.ResponseType = "code";
        options.SaveTokens = true;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("country");
        options.ClaimActions.MapUniqueJsonKey("country", "country");
        options.Scope.Add("role");
        options.ClaimActions.Add(new JsonKeyClaimAction("role", "role", "role")); // 多个role
        //options.ClaimActions.MapUniqueJsonKey("role", "role"); // 单个role
        options.Scope.Add("Name");
        options.Scope.Add("PhoneNumber");
        options.Scope.Add("Nick");
        options.ClaimActions.MapUniqueJsonKey("UserName", "Name");
        options.ClaimActions.MapUniqueJsonKey("PhoneNumber", "PhoneNumber");
        options.ClaimActions.MapUniqueJsonKey("NickName", "Nick");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            RoleClaimType = "role"
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Area.China", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("country", "China");
    });
});

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
//app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();