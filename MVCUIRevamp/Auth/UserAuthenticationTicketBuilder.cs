using System;
using System.Web.Security;

namespace RithV.FX.Auth
{
    public class UserAuthenticationTicketBuilder
    {
        public static FormsAuthenticationTicket CreateAuthenticationTicket(UserDetail user)
        {
            return new FormsAuthenticationTicket(1, user.Username, DateTime.Now.ToLocalTime(), DateTime.Now.ToLocalTime().Add(FormsAuthentication.Timeout), false, user.ToString());
        }
    }
}
