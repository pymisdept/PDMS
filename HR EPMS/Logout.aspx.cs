using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Claims;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;


namespace HR_EPMS
{
    public partial class LogoutPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userClaims = HttpContext.Current.User.Identity as System.Security.Claims.ClaimsIdentity;
            string username = userClaims?.FindFirst("name")?.Value;

            if (Request.IsAuthenticated)
            {
                ClaimsPrincipal _currentUser = (System.Web.HttpContext.Current.User as ClaimsPrincipal);

                // Get the user's token cache and clear it.
                string userObjectId = _currentUser.Claims.First(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value;

                //SessionTokenCache tokenCache = new SessionTokenCache(userObjectId, HttpContext);
                HttpContext.Current.GetOwinContext().Authentication.SignOut(OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
            }

            //SDKHelper.SignOutClient();

            HttpContext.Current.GetOwinContext().Authentication.SignOut(
              OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);

        }
    }
}