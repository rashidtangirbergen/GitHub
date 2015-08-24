using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Samruk.Web.Helpers {
    public static class Extensions {
        public static IEnumerable<string> GetRoles(this HttpContext context, string username) {
            if (string.IsNullOrEmpty(username)) {
                return new string[0];
            }
            var userManager = context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(username);
            if (user == null) {
                return new string[0];
            }
            var roles = userManager.GetRoles(user.Id);
            return roles;
        }

        public static bool IsAdministrator(this HttpContext context, string username) {
            return GetRoles(context, username).Any(x => x == SiteConstants.Administrator);
        }
        public static bool IsAuditor(this HttpContext context, string username) {
            return GetRoles(context, username).Any(x => x == SiteConstants.Auditor);
        }
        public static bool IsUser(this HttpContext context, string username) {
            return GetRoles(context, username).Any(x => x == SiteConstants.User);
        }
    }
}