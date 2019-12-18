using AutoMapper;
using RithV.FX.EntityDTO.Security;

namespace RithV.FX.WebAPI.Config
{
    public static class AutoMapperExtensions
    {
        public static void Bidirectional<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            Mapper.CreateMap<TDestination, TSource>();
        }
    }

    /// <summary>
    /// Do a bidiretional mapping
    /// </summary>
    public static class AutoMapperExt
    {
        internal static void Mapp()
        {
            Mapper.CreateMap<Entity.tblUser, Users>().Bidirectional();
            Mapper.CreateMap<Entity.tblRole, Roles>().Bidirectional();
            Mapper.CreateMap<Entity.tblWebPart, WebParts>().Bidirectional();

            //Mapper.CreateMap<Entity.tblUsertoRole, Roles>().Bidirectional();
            //Mapper.CreateMap<Data.Model.AccountHeads, Model.AccountHeadsDTO>().Bidirectional();
            //Mapper.CreateMap<Data.Model.ParentAccountHeads, Model.ParentAccountHeadDTO>().Bidirectional();
            //Mapper.CreateMap<Data.Model.JobTypes, Model.JobTypesDTO>().Bidirectional();
            //Mapper.CreateMap<Data.Model.Accounts, Model.AccountsDTO>().Bidirectional();

            //Mapper.CreateMap<Data.Model.Authorization.Role, Data.Model.Authorization.Role>().Bidirectional();
            //Mapper.CreateMap<Data.Model.Authorization.OpenSession, Model.UserSession>().Bidirectional();




        }
    }
}