using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Projet_2022.Models.Entities;
using System.Security.Claims;

namespace Projet_2022.Data.Extensions
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
            identity.AddClaim(new Claim("FirstName", user.FirstName ?? ""));
            identity.AddClaim(new Claim("LastName", user.LastName ?? ""));
            identity.AddClaim(new Claim("Email", user.Email ?? ""));
            identity.AddClaim(new Claim("City", user.City ?? ""));
            identity.AddClaim(new Claim("Zipcode", user.Zipcode ?? ""));
            identity.AddClaim(new Claim("Phone", user.Phone ?? ""));
            return identity;
        }
    }
}
