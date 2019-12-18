using NHibernate;
using RithV.FX.WebAPI.Infra.Base;

namespace RithV.FX.WebAPI.Controllers
{
    public class RolesController : TemplateController<EntityDTO.Security.Roles, Entity.tblRole>
    {
        public RolesController(ISession session, ITMapper<EntityDTO.Security.Roles, Entity.tblRole> mapper,
            IHttpTFetcher<Entity.tblRole> fetcher)
            : base(session, mapper, fetcher)
        {

        }

    }
}
