using Microsoft.Practices.ServiceLocation;
using RithV.FX.Base;

namespace RithV.FX.Helper
{
    public class DataCacheExtrns : IDataCacheExtrns
    {
        protected readonly IServiceLocator _serviceLocator;
        protected readonly IHttpClientObject _httpClientObject;
        protected readonly IHttpClientHelper _clientHelper;
        public DataCacheExtrns(IServiceLocator serviceLocator, IHttpClientObject httpClientObject, IHttpClientHelper clientHelper)
        {
            this._serviceLocator = serviceLocator;
            this._httpClientObject = httpClientObject;
            this._clientHelper = clientHelper;
        }
        //public async Task<IEnumerable<DropDownClass>> GetCustomers()
        //{
        //    IEnumerable<DropDownClass> enumerable;
        //    if (!ApiDataCache.Update("Customer", out enumerable))
        //    {
        //        ResultValue<IEnumerable<CustomersDTO>> resultValue = await this._clientHelper.GetAsync<IEnumerable<CustomersDTO>>("api/Customers");
        //        enumerable =
        //            from dat in resultValue.Result
        //            select new DropDownClass
        //            {
        //                Key = dat.Key,
        //                Value = dat.CustomerName
        //            };
        //        ApiDataCache.Create("Customer", enumerable);
        //    }
        //    else
        //    {
        //        ApiDataCache.Update("Customer", out enumerable);
        //    }
        //    return enumerable;
        //}
        //public async Task<IEnumerable<DropDownClass>> GetAccountHead()
        //{
        //    IEnumerable<DropDownClass> enumerable;
        //    if (!ApiDataCache.Update("AccountHead", out enumerable))
        //    {
        //        ResultValue<IEnumerable<AccountHeadsDTO>> resultValue = await this._clientHelper.GetAsync<IEnumerable<AccountHeadsDTO>>("api/AccountHeads");
        //        enumerable =
        //            from dat in resultValue.Result
        //            select new DropDownClass
        //            {
        //                Key = dat.Key,
        //                Value = dat.AccountHead
        //            };
        //        ApiDataCache.Create("AccountHead", enumerable);
        //    }
        //    else
        //    {
        //        ApiDataCache.Update("AccountHead", out enumerable);
        //    }
        //    return enumerable;
        //}

    }
}