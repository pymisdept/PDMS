using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Web.UI;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Security.Claims;
using System.Data.SqlClient;

namespace HR_EPMS
{
    public partial class LoginPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
                new AuthenticationProperties { RedirectUri = "/" },
                OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
            else {
                String constr = ConfigurationManager.ConnectionStrings["cnCareer"].ConnectionString;
                var userClaims = HttpContext.Current.User.Identity as System.Security.Claims.ClaimsIdentity;
                string Pre_username = userClaims?.FindFirst("preferred_username")?.Value;
                string sql = "select * from aduser_allow where Email = '" + Pre_username + "'";

                SqlConnection myconn = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand(sql, myconn);
                myconn.Open();


                cmd.Connection = myconn;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    Response.Redirect("/Main");
                }
                else
                {
                    Response.Redirect("/Acknowledge");
                    //HttpContext.Current.GetOwinContext().Authentication.SignOut(
                    //OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);

                }

                
                    //myconn.Close();
                    //}
                    //else
                    //{ myconn.Close(); }
            }

        }

        public void LogOff()
        {
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