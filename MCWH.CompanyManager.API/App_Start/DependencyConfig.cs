using Autofac;
using System.Web.Http;
using System.Reflection;
using MCWH.Infrastructure;
using MCWH.CompanyManager.Data;
using Autofac.Integration.WebApi;

namespace MCWH.CompanyManager.API
{
    public class DependencyConfig
    {
        public static void SetupDependencies()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                    .OnActivated(x => x.Instance.AddContext(nameof(CompanyEntities), new CompanyEntities()))
                    .InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.Load("MCWH.CompanyManager.Data"))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.Load("MCWH.CompanyManager.Service"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiModelBinderProvider();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }
    }
}