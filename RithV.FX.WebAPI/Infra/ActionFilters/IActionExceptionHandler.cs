using log4net;
using RithV.FX.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace RithV.FX.WebAPI.Infra.ActionFilters
{
    public interface IActionExceptionHandler
    {
        void HandleException(HttpActionExecutedContext actionExecutedContext);
    }

    public class ActionExceptionHandler : IActionExceptionHandler
    {
        private readonly IExceptionMessageFormatter _exceptionMessageFormatter;
        private readonly ILog _logger;

        public ActionExceptionHandler(ILog logger, IExceptionMessageFormatter exceptionMessageFormatter)
        {
            _logger = logger;
            _exceptionMessageFormatter = exceptionMessageFormatter;
        }

        public bool ExceptionHandled { get; private set; }

        public void HandleException(HttpActionExecutedContext actionExecutedContext)
        {
            var exception = actionExecutedContext.Exception;
            if (exception == null) return;
            ExceptionHandled = true;

            _logger.Error("Error Occured : ", exception);

            string exceptionreason = _exceptionMessageFormatter.GetCompleteException(exception);
            actionExecutedContext.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = exceptionreason
            };
        }
    }
}