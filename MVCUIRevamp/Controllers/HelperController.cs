using Microsoft.Practices.ServiceLocation;
using RithV.FX.Base;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace RithV.FX.Controllers
{
    public class HelperController : AuthorizationController
    {
        public HelperController(IServiceLocator serviceLocator, IHttpClientObject httpClientObject, IHttpClientHelper clientHelper)
            : base(serviceLocator, httpClientObject, clientHelper)
        {
            //var usr = CurrentUser.UserId;
        }

        //[ChildActionOnly]
        //[OutputCache(Duration = 30)]
        public IEnumerable<RithV.FX.EntityDTO.Security.WebParts> FetchMenus()
        {
            ResultValue<IEnumerable<EntityDTO.Security.WebParts>> resultValue = this._clientHelper.GetAsync<IEnumerable<EntityDTO.Security.WebParts>>("api/WebParts/" + CurrentUser.UserId.ToString(CultureInfo.InvariantCulture)).Result;

            if (resultValue.Code == HttpStatusCode.Found)
            {
                return resultValue.Result;
            }
            else
            {
                base.TempData["APIError"] = resultValue.Code + " - " + resultValue.Exceptions;
                return null;
            }
            return null;
        }

    }
}