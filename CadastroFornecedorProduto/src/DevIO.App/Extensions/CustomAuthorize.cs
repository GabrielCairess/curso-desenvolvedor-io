using Microsoft.AspNetCore.Http;
using System.Linq;

namespace DevIO.App.Extensions
{
    public class CustomAuthorize
    {
        public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }
    }
}
