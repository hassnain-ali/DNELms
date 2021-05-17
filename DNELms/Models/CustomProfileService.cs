using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace DNELms.Models
{
    public class CustomProfileService : IProfileService
    {
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory;
        UserManager<ApplicationUser> userManager;
        public CustomProfileService(IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory,
            UserManager<ApplicationUser> _userManager)
        {
            userClaimsPrincipalFactory = _userClaimsPrincipalFactory;
            userManager = _userManager;
        }
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject;//.GetSubjectId();
            //var user = InMemoryConfig.GetUsers()
            //    .Find(u => u.SubjectId.Equals(sub));
            //var user = await userManager.FindByEmailAsync("");
            //var claimsFact = await userClaimsPrincipalFactory.CreateAsync(user);
            context.IssuedClaims.AddRange(sub.Claims);
            return Task.CompletedTask;
        }
        public Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject;///.GetSubjectId();
            //var user = InMemoryConfig.GetUsers()
            //    .Find(u => u.SubjectId.Equals(sub));
            context.IsActive = sub != null && sub.Claims.Count() > 0;//user != null;
            return Task.CompletedTask;
        }
    }
}
