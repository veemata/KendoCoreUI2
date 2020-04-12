using MH.PLCM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MH.PLCM.Utils
{
    public class MhUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public MhUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,
                         IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("ContactName", user.ContactName ?? "[Click to edit profile]"));
            identity.AddClaim(new Claim("Company", user.Company.ToString() ?? "[Click to edit profile]"));
            identity.AddClaim(new Claim("Location", user.Location.ToString() ?? "[Click to edit profile]"));
            identity.AddClaim(new Claim("Department", user.Department.ToString() ?? "[Click to edit profile]"));
            identity.AddClaim(new Claim("ContributionLevel", user.ContributionLevel.ToString() ?? "[Click to edit profile]"));

            return identity;
        }
    }

}

