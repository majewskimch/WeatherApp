using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using WeatherApp.Repository;
using WeatherApp.Services;

namespace WeatherApp.App_Start
{
    public class AutofacConfig
    {
        public static IContainer Container { get; private set; }

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterDependency(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterDependency(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<WeatherService>().As<IWeatherService>().InstancePerRequest();
            builder.RegisterType<WeatherRepository>().As<IWeatherRepository>().InstancePerRequest();

            Container = builder.Build();

            return Container;
        }
    }
}