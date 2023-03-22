using CleanArchitHomework.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace CleanArchitHomework.Presentation.MVC.Factory
{
    public class CustomClaimsFactory
    {
        public CustomClaimsFactory(UserManager<User> userManager, IOptions<IdentityOptions> optionsAccessor)
            : base()
        {
        }

        //protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        //{
        //    var identity = await base.GenerateClaimsAsync(user);
        //    identity.AddClaim(new Claim("firstname", user.FirstName));
        //    identity.AddClaim(new Claim("lastname", user.LastName));

        //    var roles = await UserManage.GetRolesAsync(user);
        //    foreach (var role in roles)
        //    {
        //        identity.AddClaim(new Claim(ClaimTypes.Role, role));
        //    }

        //    return identity;
        //}
    }
}
