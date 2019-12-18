namespace RithV.FX.WebAPI.Infra.Base
{
    public interface IHttpTFetcher<TEntity> where TEntity : class
    {
        TEntity GetItem(long id);
    }
}