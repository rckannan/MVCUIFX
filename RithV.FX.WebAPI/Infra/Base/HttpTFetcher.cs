using NHibernate;

namespace RithV.FX.WebAPI.Infra.Base
{
    public class HttpTFetcher<TEntity> : IHttpTFetcher<TEntity> where TEntity : class
    {
        private readonly ISession _session;

        public HttpTFetcher(ISession session)
        {
            _session = session;
        }

        public TEntity GetItem(long id)
        {
            var obj = _session.Get<TEntity>(id);
            //if (obj == null)
            //{
            //    throw new HttpResponseException(
            //        new HttpResponseMessage
            //        {
            //            StatusCode = HttpStatusCode.NotFound,
            //            ReasonPhrase = string.Format("Item {0} not found", id)
            //        });
            //}

            return obj;
        }
    }
}