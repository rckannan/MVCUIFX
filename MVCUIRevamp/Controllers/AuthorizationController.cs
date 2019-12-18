using Microsoft.Practices.ServiceLocation;
using RithV.FX.Auth;
using RithV.FX.Base;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace RithV.FX.Controllers
{
    public class AuthorizationController : Controller
    {
        protected readonly IServiceLocator _serviceLocator;
        protected readonly IHttpClientObject _httpClientObject;
        protected readonly IHttpClientHelper _clientHelper;
        private UserDetail _currentUser;

        protected string BaseUri
        {
            get;
            private set;
        }
        public UserDetail CurrentUser
        {
            get
            {
                UserDetail user;
                if ((user = this._currentUser) == null)
                {
                    user = (this._currentUser = base.HttpContext.User.UserStatsIdentity().UserInfoDetail);
                }
                return user;
            }
        }
        protected override HttpNotFoundResult HttpNotFound(string statusDescription)
        {
            return base.HttpNotFound(statusDescription);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session != null && filterContext.HttpContext.Session.IsNewSession)
            {
                string text = filterContext.HttpContext.Request.Headers["Cookie"];
                if (text != null && text.IndexOf("_sessionId", StringComparison.Ordinal) >= 0)
                {
                    filterContext.Result = base.RedirectToAction("SessionExpired", "Authorization");
                    return;
                }
            }
            base.OnActionExecuting(filterContext);
        }

        public AuthorizationController(IServiceLocator serviceLocator, IHttpClientObject httpClientObject, IHttpClientHelper clientHelper)
        {
            this._serviceLocator = serviceLocator;
            this._httpClientObject = httpClientObject;
            this._clientHelper = clientHelper;
        }
        private void GetBaseUrl()
        {
            string text = ConfigurationManager.AppSettings["BaseURL"];
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("baseurl");
            }
            this.BaseUri = text;
        }
        protected T Using<T>() where T : class
        {
            T instance = this._serviceLocator.GetInstance<T>();
            if (instance == null)
            {
                throw new NullReferenceException("Unable to resolve type with service locator; type " + typeof(T).Name);
            }
            return instance;
        }
        public ActionResult SessionExpired()
        {
            ViewBag.Message = "Oops, Your session has expired.";
            return View();
        }
    }
}