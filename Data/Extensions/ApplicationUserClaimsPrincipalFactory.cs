using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Projet_2022.Models.Entities;
using System.Security.Claims;

namespace ScrumandPoker.Data.Extensions
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Email", user.Email ?? ""));
            identity.AddClaim(new Claim("Name", user.FirstName+" "+user.LastName ?? ""));
            identity.AddClaim(new Claim("Id", user.Id ?? ""));
            return identity;
        }
    }
}
