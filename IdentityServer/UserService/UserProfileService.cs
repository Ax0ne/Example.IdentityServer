using System.Security.Claims;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace IdentityServer.UserService
{
    public class UserProfileService : IProfileService
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        public UserProfileService(IUserService userService, ILogger<UserProfileService> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.LogProfileRequest(_logger);
            if (context.RequestedClaimTypes.Any())
            {
                var sub = context.Subject.GetSubjectId();
                int.TryParse(sub, out int userId);
                var user = _userService.GetUser(userId);
                if (user != null)
                {
                    context.AddRequestedClaims(new List<Claim>
                    {
                        new Claim("Name", user.Name),
                        new Claim("PhoneNumber", user.PhoneNumber),
                        new Claim("Nick", user.Nick),
                    });
                }
            }

            context.LogIssuedClaims(_logger);
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}