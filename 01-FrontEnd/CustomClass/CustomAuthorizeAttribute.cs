using Persistence.DatabaseContext;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.CustomClass
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        ApplicationDbContext context = new ApplicationDbContext(); // my entity  
        private readonly string[] allowedroles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            foreach (var role in allowedroles)
            {
                var rol = context.Roles.Where(m => m.Name == role).ToList(); // checking active users with allowed roles.  
                if (rol.Count() > 0)
                {
                    authorize = true; /* return true if Entity has current user(active) with specific role */
                }
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}