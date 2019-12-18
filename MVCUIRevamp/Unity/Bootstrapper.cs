using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Mvc;
using System.Configuration;
using System.Web.Mvc;

namespace RithV.FX.Unity
{
    public static class Bootstrapper
    {
        public static IUnityContainer GetContainer { get; set; }

        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            //container.RegisterType(typeof(IHttpClientHelper<>), typeof(HttpClientHelper<>));    
            GetContainer = container;
            return container;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            var section
                     = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //section.Configure(container);
            container.LoadConfiguration("containers");
        }


    }
}