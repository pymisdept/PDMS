using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Security.Claims;

namespace HR_EPMS
{
    public partial class Main : System.Web.UI.Page
    {
        private static readonly string uatMode = ConfigurationManager.AppSettings["UATMODE"];
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Request.IsAuthenticated && uatMode == "false")
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
                new AuthenticationProperties { RedirectUri = "/" },
                OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
            var p1 = "width:" + Math.Round((25.00 / 100.00),2) * 100+"%";
            prbar1.Attributes.Add("style", p1);
            prbar1.Attributes.Add("aria-valuenow","50");
        }
    }
}