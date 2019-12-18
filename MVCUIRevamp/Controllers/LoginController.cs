using Newtonsoft.Json;
using RithV.FX.Auth;
using RithV.FX.Base;
using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace RithV.FX.Controllers
{
    [System.Web.Mvc.Authorize]
    public class LoginController : Controller
    {
        private readonly IFormsAuthentication _formsAuthentication;
        private readonly IHttpClientObject _httpClientObject;
        public LoginController(IFormsAuthentication formsAuthentication, IHttpClientObject httpClientObject)
        {
            this._formsAuthentication = formsAuthentication;
            this._httpClientObject = httpClientObject;
        }

        [System.Web.Mvc.AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.ReturnUrl = "/";
            _formsAuthentication.Signout();
            return View(new LoginModel());
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel collection, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var apiClientContex = _httpClientObject.GetClient();

                    var uri = apiClientContex.BaseUri + "api/auth";

                    var content = new ObjectContent(collection.GetType(), collection, new JsonMediaTypeFormatter());

                    HttpResponseMessage response = await apiClientContex.HttpClient.PostAsync("api/auth", content);
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            ViewBag.mess = "Successfully logged in....";
                            var strm = await response.Content.ReadAsStreamAsync();
                            var decomp = new GZipStream(strm, CompressionMode.Decompress, leaveOpen: false);

                            var serializer = new JsonSerializer();
                            var jsonTextReader = new JsonTextReader(new StreamReader(decomp));
                            var ob = serializer.Deserialize<UserDetail>(jsonTextReader);

                            //Set Auth info in HTTP Context
                            _formsAuthentication.SetAuthCookie(this.HttpContext,
                                                                   UserAuthenticationTicketBuilder.CreateAuthenticationTicket(
                                                                       ob));

                            //Create a HttpClient for this user
                            //var newclient = _httpClientObject.GetClient(collection.UserName, collection.Password, apiClientContex.BaseUri.AbsoluteUri, "LocalClient");

                            //Redirect to respective URL
                            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length >= 1 && returnUrl.StartsWith("/")
                               && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                            }

                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine(ex.Message);
                            ModelState.AddModelError(string.Empty, ex.Message);
                        }

                    }
                    else
                    {
                        var strm = await response.Content.ReadAsStreamAsync();
                        var decomp = new GZipStream(strm, CompressionMode.Decompress, leaveOpen: false);

                        var serializer = new JsonSerializer();
                        var jsonTextReader = new JsonTextReader(new StreamReader(decomp));
                        var ob = serializer.Deserialize<HttpError>(jsonTextReader);
                        ModelState.AddModelError(string.Empty, "Login error : " + response.ReasonPhrase + " - " + ob.Message);
                    }

                }

                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Login error : " + ex.Message);
                return View();
            }
        }

        [System.Web.Mvc.AllowAnonymous]
        public ActionResult LoginWindows()
        {
            ViewBag.ReturnUrl = "/";
            _formsAuthentication.Signout();
            return View(new LoginModelWoPass());
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginWindows(LoginModelWoPass collection, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var apiClientContex = _httpClientObject.GetClient();

                    var uri = apiClientContex.BaseUri + "api/authWin";

                    var content = new ObjectContent(collection.GetType(), collection, new JsonMediaTypeFormatter());

                    HttpResponseMessage response = await apiClientContex.HttpClient.PostAsync("api/authWin", content);
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            ViewBag.mess = "Successfully logged in....";
                            var strm = await response.Content.ReadAsStreamAsync();
                            var decomp = new GZipStream(strm, CompressionMode.Decompress, leaveOpen: false);

                            var serializer = new JsonSerializer();
                            var jsonTextReader = new JsonTextReader(new StreamReader(decomp));
                            var ob = serializer.Deserialize<UserDetail>(jsonTextReader);

                            //Set Auth info in HTTP Context
                            _formsAuthentication.SetAuthCookie(this.HttpContext,
                                                                   UserAuthenticationTicketBuilder.CreateAuthenticationTicket(
                                                                       ob));

                            //Create a HttpClient for this user
                            //var newclient = _httpClientObject.GetClient(collection.UserName, collection.Password, apiClientContex.BaseUri.AbsoluteUri, "LocalClient");

                            //Redirect to respective URL
                            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length >= 1 && returnUrl.StartsWith("/")
                               && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                            }

                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine(ex.Message);
                            ModelState.AddModelError(string.Empty, ex.Message);
                        }

                    }
                    else
                    {
                        var strm = await response.Content.ReadAsStreamAsync();
                        var decomp = new GZipStream(strm, CompressionMode.Decompress, leaveOpen: false);
                        var serializer = new JsonSerializer();
                        var jsonTextReader = new JsonTextReader(new StreamReader(decomp));
                        var ob = serializer.Deserialize<HttpError>(jsonTextReader);
                        ModelState.AddModelError(string.Empty, "Login error : " + response.ReasonPhrase + " - " + ob.Message);
                    }

                }

                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Login error : " + ex.Message);
                return View();
            }
        }

        public ActionResult Logout()
        {
            _formsAuthentication.Signout();
            return RedirectToAction("Login");
        }


    }
}