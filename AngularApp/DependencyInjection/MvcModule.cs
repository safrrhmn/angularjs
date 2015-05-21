using Autofac;
using Autofac.Integration.Mvc;

namespace AngularApp.DependencyInjection
{
	public class MvcModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterModule(new AutofacWebTypesModule());
			builder.RegisterFilterProvider();
			builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerRequest();
		}
	}
}