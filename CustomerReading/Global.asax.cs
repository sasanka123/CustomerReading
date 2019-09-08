using Autofac;
using Autofac.Integration.Mvc;
using CustomerReading.Bussiness;
using CustomerReading.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CustomerReading
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();
            string webConfig = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            builder.Register(ctx => new DataConnectionFactory(webConfig)).As<DataConnectionFactory>().InstancePerDependency();
            builder.RegisterType<CustomerDataService>().As<ICustomerDataService>();
            builder.RegisterType<UserDataService>().As<IUserDataService>();
            builder.RegisterType<CustomerRepo>().As<CustomerRepo>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepo>().As<UserRepo>().InstancePerLifetimeScope();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
