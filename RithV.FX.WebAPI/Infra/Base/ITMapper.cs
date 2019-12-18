using AutoMapper;

namespace RithV.FX.WebAPI.Infra.Base
{
    public interface ITMapper<out TDto, in TEntity> where TDto : class where TEntity : class
    {
        TDto CreateMapper(TEntity modelclass);
    }

    public class TMapper<TDto, TEntity> : ITMapper<TDto, TEntity>
        where TDto : class, new() where TEntity : class
    {
        public TDto CreateMapper(TEntity modelclass)
        {
            //var newObj = new TWc();

            //foreach (PropertyInfo prop in modelclass.GetType().GetProperties())
            //{
            //    PropertyInfo wcprop = newObj.GetType().GetProperty(prop.Name);
            //    if (wcprop != null)
            //    {
            //        object mcvalue = prop.GetValue(modelclass, null);
            //        typeof (TWc).GetProperty(prop.Name).SetValue(newObj, mcvalue);
            //    }
            //}  
            return Mapper.Map<TEntity, TDto>(modelclass);
        }
    }
}