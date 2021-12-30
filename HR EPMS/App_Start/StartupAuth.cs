using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HR_EPMS
{
	public partial class Startup
	{
		string clientId = System.Configuration.ConfigurationManager.AppSettings["ClientId"];

		// RedirectUri is the URL where the user will be redirected to after they sign in.
		string redirectUri = System.Configuration.ConfigurationManager.AppSettings["RedirectUri"];

		// Tenant is the tenant ID (e.g. contoso.onmicrosoft.com, or 'common' for multi-tenant)
		static string tenant = System.Configuration.ConfigurationManager.AppSettings["Tenant"];

		// Authority is the URL for authority, composed by Microsoft identity platform endpoint and the tenant name (e.g. https://login.microsoftonline.com/contoso.onmicrosoft.com/v2.0)
		string authority = String.Format(System.Globalization.CultureInfo.InvariantCulture, System.Configuration.ConfigurationManager.AppSettings["Authority"], tenant);

		public void ConfigureAuth(IAppBuilder app)
		{
			app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

			app.UseCookieAuthentication(new CookieAuthenticationOptions());

			app.UseOpenIdConnectAuthentication(
			new OpenIdConnectAuthenticationOptions
			{
				ClientId = clientId,
				Authority = authority,
				PostLogoutRedirectUri = redirectUri,

				Notifications = new OpenIdConnectAuthenticationNotifications()
				{

					//AuthenticationFailed = (context) =>
					//{
					//	return System.Threading.Tasks.Task.FromResult(0);
					//},
					AuthenticationFailed = (context) =>
					{
						AuthenticationFailedNotification<Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> authFailed;
						authFailed = context;
						if (authFailed.Exception.Message.Contains("IDX21323"))
						{
							authFailed.HandleResponse();
							authFailed.OwinContext.Authentication.Challenge();
						}

						return System.Threading.Tasks.Task.FromResult(true);
					},
					SecurityTokenValidated = (context) =>
					{
						var claims = context.AuthenticationTicket.Identity.Claims;
						var groups = from c in claims
									 where c.Type == "groups"
									 select c;

						foreach (var group in groups)
						{
							context.AuthenticationTicket.Identity.AddClaim(new Claim(ClaimTypes.Role, group.Value));
						}
						return Task.FromResult(0);
					}
				}

			}
			);

			// This makes any middleware defined above this line run before the Authorization rule is applied in web.config
			app.UseStageMarker(PipelineStage.Authenticate);
		}

		private static string EnsureTrailingSlash(string value)
		{
			if (value == null)
			{
				value = string.Empty;
			}

			if (!value.EndsWith("/", StringComparison.Ordinal))
			{
				return value + "/";
			}

			return value;
		}
	}
}