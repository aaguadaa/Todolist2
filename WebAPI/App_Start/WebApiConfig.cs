using Data.Contracts;
using Data.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using Business.Contracts;
using Business.Implementation;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //SimpleInjectorInitializer.Initialize();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            var container = new SimpleInjector.Container();
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            //User
            container.Register<IUserService, UserService>();
            container.Register<IUserRepository, UserRepository>();
            //Project
            container.Register<IProjectService, ProjectService>();
            container.Register<IProjectRepository, ProjectRepository>();

            //Task
            container.Register<ITaskService, TaskService>();
            container.Register<ITaskRepository, TaskRepository>();

            //Role
            container.Register<IRoleService, RoleService>();
            container.Register<IRoleRepository, RoleRepository>();
           

            container.Verify();
            //config.DependencyResolver = new SimpleInjectorWebApiDependecyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver =
        new SimpleInjectorWebApiDependencyResolver(container);

        }
    }
}
