using Autofac;
using Autofac.Integration.Mvc;
using Owin;
using System.Web.Mvc;

namespace AngularApp
{
	public static class MvcConfig
	{
		/// <summary>
		/// OWIN MVC IoC Setup
		/// </summary>
		/// <param name="app"></param>
		/// <param name="container"></param>
		/// <returns></returns>
		public static IAppBuilder RunMvc(this IAppBuilder app, IContainer container)
		{
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

			return app.UseAutofacMvc();
		}
	}
}