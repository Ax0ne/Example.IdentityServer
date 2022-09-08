using IdentityServer4.Validation;

namespace IdentityServer.UserService
{
    public class UserResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            context.Result = new GrantValidationResult();

            return Task.CompletedTask;
        }
    }
}