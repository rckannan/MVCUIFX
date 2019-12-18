using NHibernate;
using RithV.FX.Entity;
using RithV.FX.EntityDTO.Security;
using RithV.FX.WebAPI.Infra.Base;

namespace RithV.FX.WebAPI.Controllers
{
    public class UsersController : TemplateController<Users, RithV.FX.Entity.tblUser>
    {
        private readonly IDateTime _date;
        public UsersController(ISession session, ITMapper<Users, Entity.tblUser> mapper,
             IHttpTFetcher<Entity.tblUser> fetcher, IDateTime date)
            : base(session, mapper, fetcher)
        {
            _date = date;
        }
    }
}