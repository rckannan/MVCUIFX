using AutoMapper;
using FluentNHibernate.Cfg.Db;
using log4net;
using NHibernate;
using NHibernate.Context;
using Ninject;
using Ninject.Activation;
using Ninject.Web.Common;
using RithV.FX.Entity;
using RithV.FX.WebAPI.Config;
using RithV.FX.WebAPI.Infra.ActionFilters;
using RithV.FX.WebAPI.Infra.Base;
using RithV.FX.WebAPI.Infra.Compression;
using RithV.FX.WebAPI.Infra.Security;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;

namespace RithV.FX.WebAPI
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel kernal)
        {
            AddBindings(kernal);

            var resolver = new NinjectDependancyResolver(kernal);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            var jSettings = new Newtonsoft.Json.JsonSerializerSettings();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = jSettings;
        }

        private void AddBindings(IKernel kernal)
        {
            Log4netConfigure(kernal);

            ConfigureNHibernate(kernal);

            kernal.Rebind<IMappingEngine>().ToMethod(context => Mapper.Engine);


            //Do binging now
            kernal.Bind<IDateTime>().To<DateTimeAdapter>();
            kernal.Bind<IDatabaseValueParser>().To<DatabaseValueParser>();
            kernal.Bind<IExceptionMessageFormatter>().To<ExceptionMessageFormatter>();

            kernal.Bind<ISqlCommandFactory>().To<SqlCommandFactory>();
            //kernal.Bind<IMySqlCommandFactory>().To<MySqlCommandFactory>();
            //kernal.Bind<IUserRepositary>().To<UserRepositary>();

            kernal.Bind<IMembershipInfoProviders>().To<MembershipInfoProviders>();
            //kernal.Bind<ICryptoService>().To<CryptoService>().InSingletonScope();

            kernal.Bind<IActionExceptionHandler>().To<ActionExceptionHandler>();
            kernal.Bind<IActionLogHelper>().To<ActionLogHelper>();
            kernal.Bind<IActionTransactionHelper>().To<ActionTransactionHelper>();


            //kernal.Bind<ISystemAuthonticationCache>().To<SystemAuthonticationCache>();
            //kernal.Bind<ClaimsAuthorizationManager>().To<AuthorizationManager>();

            kernal.Bind<ICompressor>().To<GZipCompressor>();
            ////kernal.Bind<IQuerierResponse>().To<QuerierResponse>().InThreadScope(); 

            kernal.Bind(typeof(ITMapper<,>)).To(typeof(TMapper<,>));
            kernal.Bind(typeof(IHttpTFetcher<>)).To(typeof(HttpTFetcher<>));

            kernal.Bind<IUserSession>().ToMethod(CreateUserSession).InRequestScope();

            AutoMapperExt.Mapp();

        }

        private void ConfigureNHibernate(IKernel kernal)
        {

            var sessionFactory = FluentNHibernate.Cfg.Fluently.Configure()
                .CurrentSessionContext("web").Mappings(z => z.FluentMappings.AddFromAssemblyOf<SqlCommandFactory>())
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(
                        x => x.FromConnectionStringWithKey("DefaultConnections")))
                .BuildSessionFactory();



            //var sessionFactory = FluentNHibernate.Cfg.Fluently.Configure()
            //   .CurrentSessionContext("web").Mappings(z => z.FluentMappings.AddFromAssemblyOf<MySqlCommandFactory>())
            //   .Database(
            //       MySQLConfiguration.Standard.ConnectionString(
            //           x => x.FromConnectionStringWithKey("DefaultConnections")))
            //   .BuildSessionFactory();


            //var os = System.Configuration.ConfigurationManager.ConnectionStrings.CurrentConfiguration;
            //var objs = MsSqlConfiguration.MsSql2008.ConnectionString(x => x.FromConnectionStringWithKey("DefaultConnection"));
            //var dddd = obj1.Database(objs);
            //var dddd = FluentNHibernate.Cfg.Fluently.Configure()
            //    .CurrentSessionContext("web").Mappings(z => z.FluentMappings.AddFromAssemblyOf<SqlCommandFactory>());
            //var obj2 = dddd
            //  .Database(
            //      MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source=.\SQLEXPRESS;Initial Catalog=TestAPI;User ID=sa;password=kannan"));
            //var obj2 = dddd
            //  .Database(
            //      MsSqlConfiguration.MsSql2012.ConnectionString(x => x.FromConnectionStringWithKey("DefaultConnections")));
            //var sessionFactory = obj2.BuildSessionFactory(); 

            kernal.Bind<ISessionFactory>().ToConstant(sessionFactory);

            kernal.Bind<ISession>().ToMethod(CreateSession);

            kernal.Bind<ICurrentSessionContextAdapter>().To<CurrentSessionContextAdapter>();
        }

        private void Log4netConfigure(IKernel kernal)
        {
            log4net.Config.XmlConfigurator.Configure();
            var logmgr = LogManager.GetLogger("RithV.FX");
            kernal.Bind<ILog>().ToConstant(logmgr);
        }

        private ISession CreateSession(IContext context)
        {
            var sessionfactory = context.Kernel.Get<ISessionFactory>();
            if (CurrentSessionContext.HasBind(sessionfactory))
                return sessionfactory.GetCurrentSession();
            var session = sessionfactory.OpenSession();
            CurrentSessionContext.Bind(session);
            return sessionfactory.GetCurrentSession();
        }

        private IUserSession CreateUserSession(IContext ctxContext)
        {
            return new UserSession(Thread.CurrentPrincipal as GenericPrincipal);
        }

    }
}