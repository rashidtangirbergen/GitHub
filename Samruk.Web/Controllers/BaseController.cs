using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Samruk.Web.Models;

namespace Samruk.Web.Controllers {
    public abstract class BaseController : Controller {
        public ApplicationUser GetAuthUser() {
            var userManager = this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(User.Identity.Name);
            return user;
        }
    }
}