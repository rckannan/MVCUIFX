using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RithV.FX.WebAPI.Infra.ActionFilters
{
    public class LoggingNHibernateSessionAttribute : ActionFilterAttribute
    {
        private readonly IActionExceptionHandler _actionExceptionHandler;
        private readonly IActionLogHelper _actionLogHelper;
        private readonly IActionTransactionHelper _actionTransactionHelper;

        public LoggingNHibernateSessionAttribute(IActionExceptionHandler actionExceptionHandler,
            IActionLogHelper actionLogHelper, IActionTransactionHelper actionTransactionHelper)
        {
            _actionExceptionHandler = actionExceptionHandler;
            _actionLogHelper = actionLogHelper;
            _actionTransactionHelper = actionTransactionHelper;
        }

        public LoggingNHibernateSessionAttribute() :
            this(WebContainerManager.Get<IActionExceptionHandler>(),
                WebContainerManager.Get<IActionLogHelper>(),
                WebContainerManager.Get<ActionTransactionHelper>())
        {
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            _actionTransactionHelper.EndTransaction(actionExecutedContext);
            _actionTransactionHelper.CloseSession();
            _actionExceptionHandler.HandleException(actionExecutedContext);
            _actionLogHelper.LogExit(actionExecutedContext.ActionContext.ActionDescriptor);
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    actionContext.ModelState);
            }
            _actionLogHelper.LogEntry(actionContext.ActionDescriptor);
            _actionTransactionHelper.BeginTransaction();
        }
    }
}