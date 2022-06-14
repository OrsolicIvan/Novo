using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APARTMENTS.Extensions
{
    public static class ClaimsPrincipleExtension
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Name);
        }
        public static int GetUserId(this ClaimsPrincipal user) { return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value); }
    }
}
