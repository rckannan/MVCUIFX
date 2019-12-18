using NHibernate;
using RithV.FX.Entity;
using RithV.FX.EntityDTO;
using RithV.FX.EntityDTO.Security;
using RithV.FX.WebAPI.Infra.ActionFilters;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RithV.FX.WebAPI.Controllers
{
    [LoggingNHibernateSession]
    public class AuthController : ApiController
    {
        private readonly ISession _session;
        private readonly IDateTime _dateTime;
        public AuthController(ISession session, IDateTime dateTime)
        {
            _session = session;
            _dateTime = dateTime;
        }

        public HttpResponseMessage Post(HttpRequestMessage request, LoginModel reqobj)
        {
            try
            {
                var usr = _session.QueryOver<tblUser>().Where(x => x.fldUserName == reqobj.UserName).Where(x => x.fldUserType == 1);
                if (usr.RowCount() == 0) return request.CreateErrorResponse(HttpStatusCode.Unauthorized, new HttpError("Logged user is not available. Please contact administrator."));
                else
                {
                    //var tok = new Token(reqobj.UserName, request.GetClientIP());
                    if (usr.SingleOrDefault().fldPassword != reqobj.Password) return request.CreateErrorResponse(HttpStatusCode.Unauthorized, new HttpError("Supplied password has issues."));

                    if (!(usr.SingleOrDefault().fldActiveUser)) return request.CreateErrorResponse(HttpStatusCode.Unauthorized, new HttpError("Logged user is inactive. Please contact administrator."));

                    var respobj = new UserDetail()
                    {
                        UserId = usr.SingleOrDefault().Key,
                        Username = reqobj.UserName,
                        Email = usr.SingleOrDefault().fldEmailAddress,
                        UserSession = _dateTime.DateNow
                    };
                    return request.CreateResponse(HttpStatusCode.OK, respobj);
                }
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }

    }

}