using System;
using System.Security.Principal;
using System.Web.Security;

namespace RithV.FX.Auth
{
    public static class Extensions
    {
        public static UserStatsIdentity UserStatsIdentity(this IPrincipal principal)
        {
            return (UserStatsIdentity)principal.Identity;
        }
    }

    public class UserStatsIdentity : IIdentity
    {
        public string Name
        {
            get;
            private set;
        }
        public string AuthenticationType => "UserStatsIdentity";

        public UserDetail UserInfoDetail
        {
            get;
            private set;
        }
        public bool IsAuthenticated => true;

        public string DisplayName
        {
            get;
            private set;
        }
        public string Email
        {
            get;
            private set;
        }
        public long UserId
        {
            get;
            private set;
        }
        public UserStatsIdentity(string name, string displayName, long userId, string emailId)
        {
            this.Name = name;
            this.DisplayName = displayName;
            this.UserId = userId;
            this.Email = emailId;
        }
        public UserStatsIdentity(string name, UserDetail userInfo) : this(name, userInfo.Username, userInfo.UserId, userInfo.Email)
        {
            if (userInfo == null)
            {
                throw new ArgumentNullException("userInfo");
            }
            this.UserId = userInfo.UserId;
        }
        public UserStatsIdentity(FormsAuthenticationTicket ticket) : this(ticket.Name, UserDetail.FromString(ticket.UserData))
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("ticket");
            }
            this.UserInfoDetail = UserDetail.FromString(ticket.UserData);
        }
    }
}
