using Microsoft.Practices.ServiceLocation;
using RithV.FX.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RithV.FX.Controllers
{
    [System.Web.Http.Authorize]
    public class RolesController : AuthorizationController
    {
        public RolesController(IServiceLocator serviceLocator, IHttpClientObject httpClientObject, IHttpClientHelper clientHelper)
            : base(serviceLocator, httpClientObject, clientHelper)
        {
        }

        public async Task<ViewResult> Fetch()
        {
            ResultValue<IEnumerable<EntityDTO.Security.Roles>> resultValue = await this._clientHelper.GetAsync<IEnumerable<EntityDTO.Security.Roles>>("api/Roles");
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

        public async Task<ViewResult> Edit(long id)
        {
            ResultValue<EntityDTO.Security.Roles> resultValue = await this._clientHelper.GetAsync<EntityDTO.Security.Roles>("api/Roles/" + id.ToString(CultureInfo.InvariantCulture));
            ViewResult result;
            if (resultValue.Code == HttpStatusCode.Found)
            {
                result = base.View(resultValue.Result);
            }
            else
            {
                base.TempData["APIError"] = "Error in reteriving Data - " + id.ToString(CultureInfo.InvariantCulture) + " - " + resultValue.Code + " - " + resultValue.Exceptions;
                result = base.View();
            }
            return result;
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EntityDTO.Security.Roles data)
        {
            ViewResult result;
            try
            {
                if (base.ModelState.IsValid)
                {
                    ResultValue<EntityDTO.Security.Roles> resultValue = await this._clientHelper.PutAsync<EntityDTO.Security.Roles>("api/Roles/" + data.Key.ToString(CultureInfo.InvariantCulture), data);
                    if (resultValue.Code == HttpStatusCode.OK)
                    {
                        base.TempData["Success"] = "Successfully Saved....";
                        return base.RedirectToAction("Fetch");
                    }
                    else
                    {
                        base.TempData["APIError"] = string.Concat(new object[]
                        {
                            "Oops! Error in saving record. Error Code : ",
                            resultValue.Code,
                            " Error : ",
                            resultValue.Exceptions
                        });
                        result = base.View();
                    }
                }
                else
                {
                    base.ModelState.AddModelError(string.Empty, "Oops! Error in saving record.");
                    result = base.View();
                }
            }
            catch (Exception ex)
            {
                base.ModelState.AddModelError(string.Empty, "Oops! Error in saving record : " + ex.Message);
                result = base.View();
            }
            return result;
        }

        public ViewResult Create()
        {
            return base.View(new RithV.FX.EntityDTO.Security.Roles());
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EntityDTO.Security.Roles data)
        {
            ViewResult result;
            try
            {
                if (base.ModelState.IsValid)
                {
                    //var reqObject = new RequestObject<EntityDTO.Security.Roles>()
                    //{
                    //    IsFilter = false,
                    //    ReqObject = data
                    //};
                    ResultValue<EntityDTO.Security.Roles> resultValue = await this._clientHelper.PostAsync<EntityDTO.Security.Roles>("api/Roles", data);
                    if (resultValue.Code == HttpStatusCode.Created)
                    {
                        base.TempData["Success"] = "Successfully Saved....";
                        return base.RedirectToAction("Fetch");
                    }
                    else
                    {
                        base.TempData["APIError"] = string.Concat(new object[]
                        {
                            "Oops! Error in saving record. Error Code : ",
                            resultValue.Code,
                            " Error : ",
                            resultValue.Exceptions
                        });
                        result = base.View();
                    }
                }
                else
                {
                    base.ModelState.AddModelError(string.Empty, "Oops! Error in saving record.");
                    result = base.View();
                }
            }
            catch (Exception ex)
            {
                base.ModelState.AddModelError(string.Empty, "Oops! Error in saving record : " + ex.Message);
                result = base.View();
            }
            return result;
        }

        public async Task<ActionResult> Delete(long id)
        {

            ResultValue<EntityDTO.Security.Roles> resultValue = await this._clientHelper.DeleteAsync<EntityDTO.Security.Roles>("api/Roles/" + id.ToString(CultureInfo.InvariantCulture));

            if (resultValue.Code == HttpStatusCode.OK)
            {
                base.TempData["Success"] = "Successfully Deleted....";
                return base.RedirectToAction("Fetch");
            }
            else
            {
                base.TempData["APIError"] = resultValue.Code + " - " + resultValue.Exceptions;
                return base.RedirectToAction("Fetch");
            }

        }
    }
}
