using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity.Mvc;
using RithV.FX.Auth;
using RithV.FX.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.WebPages;

namespace RithV.FX
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Microsoft.Practices.Unity.IUnityContainer _unityContainer;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AuthConfig.RegisterAuth();
            IDisplayMode displayMode = DisplayModeProvider.Instance.Modes.FirstOrDefault((IDisplayMode x) => x.DisplayModeId == DisplayModeProvider.MobileDisplayModeId);
            if (displayMode != null)
            {
                DisplayModeProvider.Instance.Modes.Remove(displayMode);
            }
            MvcApplication.InitializeDependencyInjectionContainer();
        }

        private static void InitializeDependencyInjectionContainer()
        {
            MvcApplication._unityContainer = Bootstrapper.Initialise();
            Microsoft.Practices.Unity.UnityServiceLocator serviceLocator = new Microsoft.Practices.Unity.UnityServiceLocator(MvcApplication._unityContainer);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
            DependencyResolver.SetResolver(new UnityDependencyResolver(MvcApplication._unityContainer));
        }
        public override void Init()
        {
            base.PostAuthenticateRequest += new EventHandler(this.MvcApplication_PostAuthenticateRequest);
            base.EndRequest += new EventHandler(this.EndRequestHandler);
            base.Init();
        }

        private static bool IsValidAuthCookie(HttpCookie authCookie)
        {
            return !string.IsNullOrEmpty(authCookie?.Value);
        }
        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie httpCookie = base.Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (MvcApplication.IsValidAuthCookie(httpCookie))
            {
                IFormsAuthentication instance = ServiceLocator.Current.GetInstance<IFormsAuthentication>();
                FormsAuthenticationTicket formsAuthenticationTicket = instance.Decrypt(httpCookie.Value);
                UserStatsIdentity identity = new UserStatsIdentity(formsAuthenticationTicket);
                base.Context.User = new GenericPrincipal(identity, null);
                instance.SetAuthCookie(base.Context, formsAuthenticationTicket);
            }
        }
        private void MvcApplication_PostAuthenticateRequests(object sender, EventArgs e)
        {
        }
        private void EndRequestHandler(object sender, EventArgs e)
        {
            IEnumerable<UnityHttpContextPerRequestLifetimeManager> enumerable = (
                from r in MvcApplication._unityContainer.Registrations
                select r.LifetimeManager).OfType<UnityHttpContextPerRequestLifetimeManager>().ToArray<UnityHttpContextPerRequestLifetimeManager>();
            foreach (UnityHttpContextPerRequestLifetimeManager current in enumerable)
            {
                current.Dispose();
            }
        }
    }
}
