using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Owin;
using Thinktecture.IdentityServer.AccessTokenValidation;

[assembly: OwinStartup(typeof(AngularApp.Startup))]
namespace AngularApp
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration();
			config.EnableCors();
			ConfigureOAuth(app);
			
			WebApiConfig.Register(config);
			app.UseWebApi(config);
		}

		public void ConfigureOAuth(IAppBuilder app)
		{
			//TokenGeneration
			app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
			{
				Authority = "https://localhost:44333/core",
				AuthenticationMode = AuthenticationMode.Active,
				
			});
		}
	}
}