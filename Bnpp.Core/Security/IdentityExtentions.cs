using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Security
{
    public static class IdentityExtentions
    {
        //public static string GetUserName(this IIdentity identity)
        //{
        //    ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
        //    Claim claim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);

        //    return claim?.Value ?? string.Empty;
        //}
        //public static string GetUserAvatar(this IIdentity identity)
        //{
        //    ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
        //    Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Actor);

        //    return claim?.Value ?? string.Empty;
        //}
    }
}
