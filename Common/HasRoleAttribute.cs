using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline5K.Common;
using Common;
using System.Web.Routing;

namespace ShopOnline5K.Common
{
    public class HasRoleAttribute : AuthorizeAttribute
    {
        public string PermissionID { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserLogin)HttpContext.Current.Session[Common.CommonContants.USER_SESSION];
            if (session == null)
            {
                return false;
            }

            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.userName); // Call another method to get rights of the user from DB

            if (privilegeLevels.Contains(this.PermissionID) || session.group_id == CommonContant.ADMIN_GROUP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var session = (UserLogin)HttpContext.Current.Session[Common.CommonContants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Areas/Admin/Views/Login/index.cshtml"
                };
            }
            else
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Areas/Admin/Views/Shared/_401.cshtml"
                };
            }
           
        }
        private List<string> GetCredentialByLoggedInUser(string userName)
        {
            var role = (List<string>)HttpContext.Current.Session[Common.CommonContants.SESSION_ROLE];
            return role;
        }
    }
}