using System.Linq;
using System.Security.Claims;

namespace DNELms.Services
{
    public static class ClaimsExtensions
    {
        public static string UserId(this ClaimsPrincipal user)
        {
            return user.Claims.First(s => s.Type == "sub")?.Value;
        }
        public static string UserEmail(this ClaimsPrincipal user)
        {
            return user.Claims.First(s => s.Type == "email")?.Value;
        }
        public static string UserRole(this ClaimsPrincipal user)
        {
            return user.Claims.First(s => s.Type == "role")?.Value;
        }
        public static string UserPhoneNumber(this ClaimsPrincipal user)
        {
            return user.Claims.First(s => s.Type == "phone_number")?.Value;
        }
        public static string UserUsername(this ClaimsPrincipal user)
        {
            return user.Claims.First(s => s.Type == "preferred_username")?.Value;
        }
        public static string UserPNVerified(this ClaimsPrincipal user)
        {
            return user.Claims.First(s => s.Type == "phone_number_verified")?.Value;
        }
        public static string UserEMVerified(this ClaimsPrincipal user)
        {
            return user.Claims.First(s => s.Type == "email_verified")?.Value;
        }
    }
}
