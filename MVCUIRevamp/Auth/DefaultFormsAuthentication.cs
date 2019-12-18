using System;
using System.Web;
using System.Web.Security;
namespace RithV.FX.Auth
{
    public class DefaultFormsAuthentication : IFormsAuthentication
    {
        public void SetAuthCookie(string userName, bool persistent)
        {
            FormsAuthentication.SetAuthCookie(userName, persistent);
        }
        public void Signout()
        {
            FormsAuthentication.SignOut();
        }
        public void SetAuthCookie(HttpContextBase httpContext, FormsAuthenticationTicket authenticationTicket)
        {
            string value = FormsAuthentication.Encrypt(authenticationTicket);
            httpContext.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, value)
            {
                Expires = this.CalculateCookieExpirationDate()
            });
        }
        private DateTime CalculateCookieExpirationDate()
        {
            return DateTime.Now.Add(FormsAuthentication.Timeout);
        }
        public void SetAuthCookie(HttpContext httpContext, FormsAuthenticationTicket authenticationTicket)
        {
            string value = FormsAuthentication.Encrypt(authenticationTicket);
            httpContext.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, value)
            {
                Expires = this.CalculateCookieExpirationDate()
            });
        }
        public FormsAuthenticationTicket Decrypt(string encryptedTicket)
        {
            return FormsAuthentication.Decrypt(encryptedTicket);
        }
    }
}
