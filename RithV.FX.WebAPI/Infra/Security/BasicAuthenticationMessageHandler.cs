using NHibernate;
using RithV.FX.WebAPI.Infra.Compression;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace RithV.FX.WebAPI.Infra.Security
{
    public class BasicAuthenticationMessageHandler : DelegatingHandler
    {
        private const string BasicScheme = "Basic";
        private const string ChallengeAuthenticationHeaderName = "WWW-Authenticate";
        private const char AuthorizationHeaderSeparator = ':';

        private readonly IMembershipInfoProviders _membershipInfoProvider;
        private readonly ISessionFactory _sessionFactory;
        private readonly ICompressor _compressor;
        //private readonly ISystemAuthonticationCache _systemAuthonticationCache;

        private const string Origin = "Origin";
        private const string AccessControlRequestMethod = "Access-Control-Request-Method";
        private const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
        private const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        private const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
        private const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";
        private const string AccessControlAllowCredentials = "Access-Control-Allow-Credentials";

        public BasicAuthenticationMessageHandler(IMembershipInfoProviders membershipInfoProvider, ISessionFactory sessionFactory,
            ICompressor compressor)
        {
            _membershipInfoProvider = membershipInfoProvider;
            _sessionFactory = sessionFactory;
            _compressor = compressor;
            //_systemAuthonticationCache = systemAuthonticationCache;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {

            string username = string.Empty;
            string password = string.Empty;

            var authHeader = request.Headers.Authorization;
            if (authHeader == null) return UnAuthorizedResponce();
            //if (request.Content == null)
            //        return UnAuthorizedResponce();
            //    else
            //    {
            //        //validate for security token

            //    }
            else
            {
                //validate for the auth header
                if (authHeader.Scheme != BasicScheme) return UnAuthorizedResponce();

                var basevalue = authHeader.Parameter;
                var bytecredentials = Convert.FromBase64String(basevalue);
                var credentials = Encoding.ASCII.GetString(bytecredentials);
                var orgcredentials = credentials.Split(AuthorizationHeaderSeparator);

                if (orgcredentials.Count() != 2) return UnAuthorizedResponce();

                username = orgcredentials[0].Trim();
                password = orgcredentials[1].Trim();
            }
            // _membershipInfoProvider.CreateUser(username,  "kannan","arrorkannan@live.com");

            //Generate UserKey with IP
            var userkey = String.Format("UserId${0}||IP${1}||{2}", username, request.GetClientIP(), password);
            var usercontext = _membershipInfoProvider.ValidateUser(username, password, userkey);
            usercontext.IPAddress = request.GetClientIP();

            var sessopendate = DateTime.UtcNow;
            usercontext.SessionOpenTime = usercontext.SessionLastUpdated = sessopendate;

            if (!usercontext.IsValid()) return UnAuthorizedResponce();

            Thread.CurrentPrincipal = usercontext.Principal;

            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = usercontext.Principal;
            }

            return base.SendAsync(request, cancellationToken)
                .ContinueWith<HttpResponseMessage>((responseToCompleteTask) =>
                {
                    var response = responseToCompleteTask.Result;
                    if (response.RequestMessage != null && response.RequestMessage.Headers.AcceptEncoding.Any())
                    {
                        ICompressor compressor = new GZipCompressor();
                        if (null != response.Content)
                        {
                            response.Content = new CompressedContent(response.Content, _compressor);
                        }
                    }
                    //response.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First());
                    //response.Headers.Add(AccessControlAllowHeaders, "*");
                    //response.Headers.Add(AccessControlAllowCredentials, "true");
                    //response.Headers.Add("Authorization", "Basic S2FubmFuOmthbm5hbg==");
                    //response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, x-requested-with");
                    //response.Headers.Add("Access-Control-Allow-Origin", "*"); 
                    return response;
                },
                TaskContinuationOptions.OnlyOnRanToCompletion)
            ;
        }

        private Task<HttpResponseMessage> UnAuthorizedResponce()
        {
            var responce = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            responce.Headers.Add(ChallengeAuthenticationHeaderName, BasicScheme);

            var taskcompletionsrc = new TaskCompletionSource<HttpResponseMessage>();
            taskcompletionsrc.SetResult(responce);
            return taskcompletionsrc.Task;
        }
    }


    public class CultureHandler : DelegatingHandler
    {
        private ISet<string> supportedCultures = new HashSet<string>()
        {
            "en-us", "en", "fr-fr", "fr"

        };
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var list = request.Headers.AcceptLanguage;
            if (list != null && list.Count > 0)
            {
                var headerValue = list.OrderByDescending(e => e.Quality ?? 1.0D)
                    .Where(e => !e.Quality.HasValue ||
                        e.Quality.Value > 0.0D)
                        .FirstOrDefault(e => supportedCultures
                            .Contains(e.Value, StringComparer.OrdinalIgnoreCase));

                // Case 1: We can support what client has asked for             
                if (headerValue != null)
                {
                    Thread.CurrentThread.CurrentUICulture =
                        CultureInfo.GetCultureInfo(headerValue.Value);
                }

                // Case 2: Client will accept anything we support except             
                // the ones explicitly specified as not preferred by setting q=0             

                if (list.Any(e => e.Value == "*" &&
                                  (!e.Quality.HasValue || e.Quality.Value > 0.0D)))
                {
                    var culture = supportedCultures.FirstOrDefault(sc => !list.Any(e =>
                        e.Value.Equals(sc, StringComparison.OrdinalIgnoreCase) && e.Quality.HasValue &&
                        e.Quality.Value == 0.0D));
                    if (culture != null)
                        Thread.CurrentThread.CurrentUICulture =
                            CultureInfo.GetCultureInfo(culture);

                }
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}