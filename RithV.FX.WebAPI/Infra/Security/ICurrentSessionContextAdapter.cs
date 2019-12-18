using NHibernate;
using NHibernate.Context;

namespace RithV.FX.WebAPI.Infra.Security
{
    public interface ICurrentSessionContextAdapter
    {
        bool HasBind(ISessionFactory session);
        ISession UnBind(ISessionFactory session);
    }

    public class CurrentSessionContextAdapter : ICurrentSessionContextAdapter
    {
        public bool HasBind(ISessionFactory session)
        {
            return CurrentSessionContext.HasBind(session);
        }

        public ISession UnBind(ISessionFactory session)
        {
            return CurrentSessionContext.Unbind(session);
        }
    }
}