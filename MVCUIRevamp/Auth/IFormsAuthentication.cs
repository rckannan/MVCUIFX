using System.Web;
using System.Web.Security;
namespace RithV.FX.Auth
{
    public interface IFormsAuthentication
    {
        void Signout();
        void SetAuthCookie(string userName, bool persistent);
        void SetAuthCookie(HttpContextBase httpContext, FormsAuthenticationTicket authenticationTicket);
        void SetAuthCookie(HttpContext httpContext, FormsAuthenticationTicket authenticationTicket);
        FormsAuthenticationTicket Decrypt(string encryptedTicket);
    }
}
