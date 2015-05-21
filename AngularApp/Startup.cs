using Autofac;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AngularApp.Startup))]
namespace AngularApp
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// Configure IoC
			var builder = AutofacConfig.Configure(app);
			IContainer container = builder.Build();

			app.UseAutofacMiddleware(container)
				.RunMvc(container)
				.RunWebApi(container);
		}

		
	}
}