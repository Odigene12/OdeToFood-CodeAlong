using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly); //We are registering all of our controllers
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly); //We are registering all of our API controllers
            builder.RegisterType<InMemoryRestaurantData>() //We are registering our InMemoryRestaurantData component
                   .As<IRestaurantData>() //This is saying that whenever something needs an IRestaurantData, create a single instance of that to be used.
                   .SingleInstance();

            var container = builder.Build(); //We are contructing an AutoFac container here
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //The container will be used throughout the whole MVC5 application
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container); //Will work for all future web api controllers
        }
    }
}