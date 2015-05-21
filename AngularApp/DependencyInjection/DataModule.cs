using System.Configuration;
using Autofac;
using Core.DataAccess;
using Core.Repositories;
using Core.Services;
using Infrastructure.DataAccess;
using Infrastructure.Repositories;
using Infrastructure.Services;

namespace AngularApp.DependencyInjection
{
	public class DataModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{			
			builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerRequest();
			builder.RegisterType<StudentService>().As<IStudentService>().InstancePerRequest();

			builder.RegisterType<TeacherRepository>().As<ITeacherRepository>().InstancePerRequest();
			builder.RegisterType<TeacherService>().As<ITeacherService>().InstancePerRequest();

			builder.RegisterType<ClassRepository>().As<IClassRepository>().InstancePerRequest();
			builder.RegisterType<ClassService>().As<IClassService>().InstancePerRequest();

			builder.Register(dbfac => new DbConnectionFactory(ConfigurationManager.ConnectionStrings["DapperTest"].ToString()))
				.As<IDbConnectionFactory>().InstancePerRequest();

			base.Load(builder);
		}
	}
}