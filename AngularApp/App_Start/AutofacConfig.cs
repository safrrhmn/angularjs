using System.Reflection;
using Autofac;
using Owin;


namespace AngularApp
{
	public class AutofacConfig
	{
		public static ContainerBuilder Configure(IAppBuilder app)
		{
			var builder = new ContainerBuilder();

			builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

			return builder;
		}
	}
}