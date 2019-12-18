using NHibernate;
using RithV.FX.Entity;
using RithV.FX.EntityDTO.Security;
using RithV.FX.WebAPI.Infra.Base;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace RithV.FX.WebAPI.Controllers
{
    public class WebPartsController : TemplateController<WebParts, RithV.FX.Entity.tblWebPart>
    {
        private readonly IDateTime _date;
        public WebPartsController(ISession session, ITMapper<WebParts, Entity.tblWebPart> mapper,
             IHttpTFetcher<Entity.tblWebPart> fetcher, IDateTime date)
            : base(session, mapper, fetcher)
        {
            _date = date;
        }

        /// <summary>
        /// User ID as param to get all mapped Roles & Menus related
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns></returns>
        public override HttpResponseMessage Get(long id)
        {
            var respObj = _session
                .QueryOver<tblWebPart>()
                .Where(x => x.fldUser_ID == id)
                .List()
                .Select(_mapper.CreateMapper).AsQueryable();
            return Request.CreateResponse(HttpStatusCode.Found, respObj);
        }
    }
}