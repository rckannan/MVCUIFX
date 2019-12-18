using AutoMapper;
using NHibernate;
using NHibernate.Linq;
using RithV.FX.WebAPI.Infra.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.OData.Query;

namespace RithV.FX.WebAPI.Infra.Base
{
    /// <summary>
    /// This is template controller, must be inherited inorder to create a controller. Developer can either override the methods to write any specifics, otherwise, use as its.
    /// </summary>
    /// <typeparam name="TDto">Name of DTO class</typeparam>
    /// <typeparam name="TEntity">Name of Entity class</typeparam>
    [LoggingNHibernateSession]
    public class TemplateController<TDto, TEntity> : ApiController
        where TDto : class
        where TEntity : class
    {
        protected readonly IHttpTFetcher<TEntity> _fetcher;
        protected readonly ITMapper<TDto, TEntity> _mapper;
        protected readonly ISession _session;

        public TemplateController(ISession session, ITMapper<TDto, TEntity> mapper, IHttpTFetcher<TEntity> fetcher)
        {
            _fetcher = fetcher;
            _mapper = mapper;
            _session = session;
        }

        public virtual HttpResponseMessage Get()
        {
            var respObj = _session
                .QueryOver<TEntity>()
                .List()
                .Select(_mapper.CreateMapper).AsQueryable();
            return Request.CreateResponse(HttpStatusCode.Found, respObj);
        }

        public virtual HttpResponseMessage Get(long id)
        {
            TEntity obj = _fetcher.GetItem(id);
            if (obj == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError(String.Format("Item {0} not found", id)));
            }
            return Request.CreateResponse(HttpStatusCode.Found, _mapper.CreateMapper(obj));
        }

#pragma warning disable 618
        [Queryable(AllowedQueryOptions = AllowedQueryOptions.Skip | AllowedQueryOptions.Top | AllowedQueryOptions.All | AllowedQueryOptions.Filter | AllowedQueryOptions.OrderBy | AllowedQueryOptions.Select, PageSize = 50)]
#pragma warning restore 618
        public virtual IQueryable<TEntity> Get(string query) => _session.Query<TEntity>();

        public virtual HttpResponseMessage Post(HttpRequestMessage request, TDto reqobj)
        {
            //if  request is a ger request, then filter the data based on fiter and send it back.
            //otherwise, normal save request.
            try
            {
                //if (reqobj.IsFilter)
                //{
                //    var criteria = _session.CreateCriteria<TEntity>();
                //    FilterCriteria.GenerateFilters(reqobj.Filters, ref criteria);
                //    var retob = criteria.List<TEntity>().Select(_mapper.CreateMapper).AsEnumerable();
                //    var response = request.CreateResponse(HttpStatusCode.Created, retob);
                //    return response;
                //}
                //else
                //{
                var modelobj = Mapper.Map<TDto, TEntity>(reqobj);
                _session.SaveOrUpdate(modelobj);
                var newCategory = _mapper.CreateMapper(modelobj);
                var response = request.CreateResponse(HttpStatusCode.Created, newCategory);
                return response;
                //}
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError(ex.Message));
            }
        }


        //public virtual HttpResponseMessage Post(HttpRequestMessage request, RequestObject<TDto> reqobj)
        //{
        //    //if  request is a ger request, then filter the data based on fiter and send it back.
        //    //otherwise, normal save request.
        //    try
        //    {
        //        if (reqobj.IsFilter)
        //        {
        //            var criteria = _session.CreateCriteria<TEntity>();
        //            FilterCriteria.GenerateFilters(reqobj.Filters, ref criteria);
        //            var retob = criteria.List<TEntity>().Select(_mapper.CreateMapper).AsEnumerable();
        //            var response = request.CreateResponse(HttpStatusCode.Created, retob);
        //            return response;
        //        }
        //        else
        //        {
        //            var modelobj = Mapper.Map<TDto, TEntity>(reqobj.ReqObject);
        //            _session.SaveOrUpdate(modelobj);
        //            var newCategory = _mapper.CreateMapper(modelobj);
        //            var response = request.CreateResponse(HttpStatusCode.Created, newCategory);
        //            return response;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError(ex.Message));
        //    } 
        //} 

        public virtual HttpResponseMessage Delete(long id)
        {
            try
            {
                var obj = _session.Get<TEntity>(id);
                if (obj != null)
                {
                    _session.Delete(obj);
                }
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError(ex.Message));
            }
        }

        public virtual HttpResponseMessage Delete()
        {
            try
            {
                IList<TEntity> objcollection = _session.QueryOver<TEntity>().List<TEntity>();
                foreach (TEntity mc in objcollection)
                {
                    _session.Delete(mc);
                }
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError(ex.Message));
            }
        }

        private object BindProperties(object modelclass, object webDtoClass)
        {
            foreach (PropertyInfo prop in modelclass.GetType().GetProperties())
            {
                PropertyInfo wcprop = webDtoClass.GetType().GetProperty(prop.Name);
                if (wcprop != null)
                {
                    var wcvalue = wcprop.GetValue(webDtoClass, null);
                    typeof(TEntity).GetProperty(prop.Name).SetValue(modelclass, wcvalue);
                }
            }
            return modelclass;
        }

        public virtual HttpResponseMessage Put(long id, TDto reqObj)
        {
            try
            {
                TEntity objValue = _fetcher.GetItem(id);

                var obj = (TEntity)BindProperties(objValue, reqObj);

                _session.SaveOrUpdate(obj);

                return Request.CreateResponse(HttpStatusCode.OK, _mapper.CreateMapper(obj));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError(ex.Message));
            }

        }
    }
}
