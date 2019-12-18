using Microsoft.Practices.ServiceLocation;
using RithV.FX.Base;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RithV.FX.Controllers
{
    [Authorize]
    public class HomeController : AuthorizationController
    {
        public HomeController(IServiceLocator serviceLocator, IHttpClientObject httpClientObject, IHttpClientHelper clientHelper)
            : base(serviceLocator, httpClientObject, clientHelper)
        {
            //var usr = CurrentUser.UserId;
        }

        [ChildActionOnly]
        [OutputCache(Duration = 30)]
        public async Task<ViewResult> FetchMenus()
        {
            ResultValue<IEnumerable<EntityDTO.Security.WebParts>> resultValue = await this._clientHelper.GetAsync<IEnumerable<EntityDTO.Security.WebParts>>("api/WebParts/" + CurrentUser.UserId.ToString(CultureInfo.InvariantCulture));
            ViewResult result;
            if (resultValue.Code == HttpStatusCode.Found)
            {
                result = base.View(resultValue.Result);
            }
            else
            {
                base.TempData["APIError"] = resultValue.Code + " - " + resultValue.Exceptions;
                result = base.View();
            }
            return result;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test1()
        {
            ViewBag.Message = "Your Test 1.";

            return View();
        }

        public ActionResult Test2()
        {
            ViewBag.Message = "Your Test 2.";

            return View();
        }

        public ActionResult Test3()
        {
            ViewBag.Message = "Your Test 3.";

            return View();
        }

        public ActionResult Test4()
        {
            ViewBag.Message = "Your Test 4.";

            return View();
        }
    }
}