using IdentityServer.UserService;
using IdentityServer4.Test;

namespace IdentityServer
{
    public static class IdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddUsersService(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<IUserService, UserService.UserService>();

            builder.AddProfileService<UserProfileService>();
            builder.AddResourceOwnerValidator<UserResourceOwnerPasswordValidator>();

            return builder;
        }
    }
}
