using NHibernate;
using RithV.FX.Entity;
using RithV.FX.EntityDTO;
using RithV.FX.WebAPI.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace RithV.FX.WebAPI.Infra.Security
{
    public class MembershipInfoProviders : IMembershipInfoProviders
    {
        private const string BasicScheme = "Basic";
        private const string ChallengeAuthenticationHeaderName = "WWW-Authenticate";
        private const char AuthorizationHeaderSeparator = ':';
        private readonly ISessionFactory _session;

        public MembershipInfoProviders(ISessionFactory session)
        {
            _session = session;
        }

        public ValidUserContext ValidateUser(string username, string password, string userdata)
        {
            var userCtx = new ValidUserContext();
            tblAPIUser user;
            using (ISession session = _session.OpenSession())
            {
                user = session.QueryOver<tblAPIUser>().List().FirstOrDefault(x => x.fldUserName == username);
            }

            if (user != null && IsUserValid(user, password))
            {
                GenericIdentity identity = CreateIdentity(username, user, userdata);
                userCtx.Principal = new GenericPrincipal(
                    identity,
                    null);
            }

            return userCtx;
        }

        public bool ValidateUser(string username, string password, out UserDetail detail)
        {
            bool userCtx = false;
            tblAPIUser user;
            detail = new UserDetail();
            using (ISession session = _session.OpenSession())
            {
                user = session.QueryOver<tblAPIUser>().List().FirstOrDefault(x => x.fldUserName == username);
            }

            if (user != null && IsUserValid(user, password))
            {
                userCtx = true;

                detail.Username = user.fldUserName;
                detail.UserId = user.Key;
                detail.UserSession = DateTime.UtcNow;
            }

            return userCtx;
        }

        private GenericIdentity CreateIdentity(string p, tblAPIUser modelUser, string userkey)
        {
            var identity = new GenericIdentity(p, BasicScheme);
            identity.AddClaim(new Claim(ClaimTypes.Sid, modelUser.Key.ToString(CultureInfo.InvariantCulture)));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, modelUser.fldUserName));
            identity.AddClaim(new Claim(ClaimTypes.UserData, userkey));
            return identity;
        }

        private bool IsUserValid(tblAPIUser user, string password)
        {
            if (isPasswordValid(user, password))
            {
                return user.fldActiveUser;
            }
            return false;
        }

        private bool isPasswordValid(tblAPIUser user, string password)
        {
            return string.Equals(user.fldPassword, password);
        }

    }
}