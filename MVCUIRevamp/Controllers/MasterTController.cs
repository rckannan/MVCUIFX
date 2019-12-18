
using Microsoft.Practices.ServiceLocation;
using RithV.FX.Base;
using RithV.FX.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RithV.FX.Controllers
{
    [System.Web.Http.Authorize]
    public class MasterTController<T> : AuthorizationController where T : IDtoObjectModel
    {

        internal readonly IDataCacheExtrns DataCacheExtrns;
        internal IEnumerable<DropDownClass> _dropdown1;
        internal IEnumerable<DropDownClass> _dropdown2;
        internal IEnumerable<DropDownClass> _dropdown3;
        internal IEnumerable<DropDownClass> _dropdown4;
        internal IEnumerable<DropDownClass> _dropdown5;
        private readonly string _requestpath;

        internal MasterTController(IServiceLocator serviceLocator, IHttpClientObject httpClientObject, IHttpClientHelper clientHelper, string requestpath, IDataCacheExtrns dataCacheExtrns)
            : base(serviceLocator, httpClientObject, clientHelper)
        {
            this._requestpath = requestpath;
            this.DataCacheExtrns = dataCacheExtrns;
            this.Initilizeme();
        }

        internal void Initilizeme()
        {
            //throw new NotImplementedException();
        }

        public async Task<ActionResult> Fetch()
        {
            ResultValue<IEnumerable<T>> resultValue = await this._clientHelper.GetAsync<IEnumerable<T>>(this._requestpath);
            ActionResult result;
            if (resultValue.Code == HttpStatusCode.OK)
            {
                result = base.View(resultValue.Result);
            }
            else
            {
                base.TempData["Error"] = "Error in reteriving Data.";
                result = base.View();
            }
            return result;
        }

        public ActionResult Create()
        {
            if (this._dropdown1 != null)
            {
                ViewBag.Dropdown1 = _dropdown1;
            }
            if (this._dropdown2 != null)
            {
                ViewBag.Dropdown2 = _dropdown2;
            }
            if (this._dropdown3 != null)
            {
                ViewBag.Dropdown3 = _dropdown3;
            }
            if (this._dropdown4 != null)
            {
                ViewBag.Dropdown4 = _dropdown4;
            }
            if (this._dropdown5 != null)
            {
                ViewBag.Dropdown5 = _dropdown5;
            }
            return base.View((default(T) == null) ? Activator.CreateInstance<T>() : default(T));
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(T data)
        {
            ActionResult result;
            try
            {
                if (base.ModelState.IsValid)
                {
                    ResultValue<T> resultValue = await this._clientHelper.PostAsync<T>(this._requestpath, data);
                    if (resultValue.Code == HttpStatusCode.Created)
                    {
                        base.TempData["Success"] = "Successfully Saved....";
                        result = base.RedirectToAction("Fetch");
                    }
                    else
                    {
                        base.TempData["Error"] = string.Concat(new object[]
                        {
                            "Oops! Error in saving record. Error Code : ",
                            resultValue.Code,
                            " Error : ",
                            resultValue.Exceptions
                        });
                        result = base.RedirectToAction("Fetch");
                    }
                }
                else
                {
                    base.ModelState.AddModelError(string.Empty, "Error In model");
                    if (this._dropdown1 != null)
                    {
                        ViewBag.Dropdown1 = _dropdown1;
                    }
                    if (this._dropdown2 != null)
                    {
                        ViewBag.Dropdown2 = _dropdown2;
                    }
                    if (this._dropdown3 != null)
                    {
                        ViewBag.Dropdown3 = _dropdown3;
                    }
                    if (this._dropdown4 != null)
                    {
                        ViewBag.Dropdown4 = _dropdown4;
                    }
                    if (this._dropdown5 != null)
                    {
                        ViewBag.Dropdown5 = _dropdown5;
                    }
                    result = base.View(data);
                }
            }
            catch (Exception ex)
            {
                base.ModelState.AddModelError(string.Empty, "Login error : " + ex.Message);
                result = base.View();
            }
            return result;
        }

        public async Task<ViewResult> Edit(long id)
        {
            ResultValue<T> resultValue = await this._clientHelper.GetAsync<T>(this._requestpath + "/" + id.ToString(CultureInfo.InvariantCulture));
            ViewResult result;
            if (resultValue.Code == HttpStatusCode.OK)
            {
                if (this._dropdown1 != null)
                {
                    ViewBag.Dropdown1 = _dropdown1;
                }
                if (this._dropdown2 != null)
                {
                    ViewBag.Dropdown2 = _dropdown2;
                }
                if (this._dropdown3 != null)
                {
                    ViewBag.Dropdown3 = _dropdown3;
                }
                if (this._dropdown4 != null)
                {
                    ViewBag.Dropdown4 = _dropdown4;
                }
                if (this._dropdown5 != null)
                {
                    ViewBag.Dropdown5 = _dropdown5;
                }
                result = base.View(resultValue.Result);
            }
            else
            {
                base.TempData["Error"] = "Error in reteriving Data - " + id.ToString(CultureInfo.InvariantCulture);
                result = base.View();
            }
            return result;
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(T data)
        {
            ActionResult result;
            try
            {
                if (base.ModelState.IsValid)
                {
                    ResultValue<T> resultValue = await this._clientHelper.PutAsync<T>(this._requestpath + "/" + data.Key.ToString(CultureInfo.InvariantCulture), data);
                    if (resultValue.Code == HttpStatusCode.OK)
                    {
                        base.TempData["Success"] = "Successfully Saved....";
                        result = base.RedirectToAction("Fetch");
                    }
                    else
                    {
                        base.TempData["Error"] = string.Concat(new object[]
                        {
                            "Oops! Error in saving record. Error Code : ",
                            resultValue.Code,
                            " Error : ",
                            resultValue.Exceptions
                        });
                        result = base.RedirectToAction("Fetch");
                    }
                }
                else
                {
                    base.ModelState.AddModelError(string.Empty, "Error In model");
                    if (this._dropdown1 != null)
                    {
                        ViewBag.Dropdown1 = _dropdown1;
                    }
                    if (this._dropdown2 != null)
                    {
                        ViewBag.Dropdown2 = _dropdown2;
                    }
                    if (this._dropdown3 != null)
                    {
                        ViewBag.Dropdown3 = _dropdown3;
                    }
                    if (this._dropdown4 != null)
                    {
                        ViewBag.Dropdown4 = _dropdown4;
                    }
                    if (this._dropdown5 != null)
                    {
                        ViewBag.Dropdown5 = _dropdown5;
                    }
                    result = base.View(data);
                }
            }
            catch (Exception ex)
            {
                base.ModelState.AddModelError(string.Empty, "Error : " + ex.Message);
                result = base.View("Fetch");
            }
            return result;
        }

    }
}