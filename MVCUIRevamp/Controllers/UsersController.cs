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
    public class UsersController : AuthorizationController
    {
        public UsersController(IServiceLocator serviceLocator, IHttpClientObject httpClientObject, IHttpClientHelper clientHelper)
            : base(serviceLocator, httpClientObject, clientHelper)
        {
        }

        public async Task<ViewResult> Fetch()
        {
            ResultValue<IEnumerable<EntityDTO.Security.Users>> resultValue = await this._clientHelper.GetAsync<IEnumerable<EntityDTO.Security.Users>>("api/Users");
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
            ResultValue<EntityDTO.Security.Users> resultValue = await this._clientHelper.GetAsync<EntityDTO.Security.Users>("api/Users/" + id.ToString(CultureInfo.InvariantCulture));
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
        public async Task<ViewResult> Edit(EntityDTO.Security.Users data)
        {
            ViewResult result;
            try
            {
                if (base.ModelState.IsValid)
                {
                    ResultValue<EntityDTO.Security.Users> resultValue = await this._clientHelper.PutAsync<EntityDTO.Security.Users>("api/Users/" + data.Key.ToString(CultureInfo.InvariantCulture), data);
                    if (resultValue.Code == HttpStatusCode.OK)
                    {
                        base.TempData["Success"] = "Successfully Saved....";
                        result = base.View(resultValue.Result);
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
        //public ActionResult Create()
        //{
        //    return base.View(new RegisterModel());
        //}
        //[System.Web.Mvc.HttpPost]
        //public async Task<ViewResult> Create(RegisterModel data)
        //{
        //    ViewResult result;
        //    try
        //    {
        //        if (base.ModelState.IsValid)
        //        {
        //            ResultValue<RegisterModel> resultValue = await this._clientHelper.PostAsync<RegisterModel>("api/Users", data);
        //            if (resultValue.Code == HttpStatusCode.Created)
        //            {
        //                base.TempData["Success"] = "Successfully Saved....";
        //                result = base.View(resultValue.Result);
        //            }
        //            else
        //            {
        //                base.TempData["Error"] = string.Concat(new object[]
        //                {
        //                    "Oops! Error in saving record. Error Code : ",
        //                    resultValue.Code,
        //                    " Error : ",
        //                    resultValue.Exceptions
        //                });
        //                result = base.View();
        //            }
        //        }
        //        else
        //        {
        //            base.ModelState.AddModelError(string.Empty, "Error In model");
        //            result = base.View();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        base.ModelState.AddModelError(string.Empty, "Login error : " + ex.Message);
        //        result = base.View();
        //    }
        //    return result;
        //}
    }
}