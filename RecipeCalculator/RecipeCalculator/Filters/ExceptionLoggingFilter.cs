using System;
using System.Linq;
using System.Web.Mvc;
using log4net;
using System.Web;
using System.Net;

namespace RecipeCalculator.Filter
{
    public class ExceptionLoggingFilter: IExceptionFilter
    {
        private readonly ILog _logger;

        public ExceptionLoggingFilter()
        {
            _logger = LogManager.GetLogger(typeof(ExceptionLoggingFilter));
        }

        public ExceptionLoggingFilter(string loggerName)
        {
            _logger = LogManager.GetLogger(loggerName);
        }

        public void OnException(ExceptionContext filterContext)
        {
            if(filterContext.ExceptionHandled ||
                !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }
            var statusCode = (int)HttpStatusCode.InternalServerError;
            if (filterContext.Exception is HttpException)
            {
                statusCode = (new HttpException(null, filterContext.Exception)).GetHttpCode();
                _logger.Error("HttpException: status: " + statusCode.ToString(),  filterContext.Exception);
            }
            else if(filterContext.Exception is UnauthorizedAccessException)
            {
                statusCode = (int)HttpStatusCode.Forbidden;
                _logger.Error("UnauthorizedAccessException: status: " + statusCode.ToString(), filterContext.Exception);
            }

            //if ajax return JSON else view
            if(filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        error = true,
                        message = filterContext.Exception.Message
                    }
                };
                _logger.Error(filterContext.Result.ToString());
            }
            else
            {
                filterContext.Result = CreateActionResult( filterContext, statusCode);
            }
            _logger.Error(filterContext.Exception.ToString());
             // Prepare the response code.
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = statusCode;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }

        protected virtual ActionResult CreateActionResult(ExceptionContext filterContext, int statusCode)
        {
            var ctx = new ControllerContext(filterContext.RequestContext, filterContext.Controller);
            var statusCodeName = ((HttpStatusCode) statusCode).ToString();

            var viewName = SelectFirstView(ctx, 
                string.Format("~/Views/Error/{0}.cshtml", statusCodeName),
                "~/Views/Error/Error.cshtml",
                statusCodeName,
                "Error");

            var controllerName = (string) filterContext.RouteData.Values["controller"];
            var actionName = (string) filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            var result = new ViewResult
            {
                ViewName = viewName,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model)
            };
            result.ViewBag.StatusCode = statusCode;
            string error = string.Format("controller: {0}, action: {1}, statusCode: {2}",
                controllerName, actionName, statusCodeName);
            _logger.Error(error);
            return result;
        }

        protected string SelectFirstView(ControllerContext ctx, params string[] viewNames)
        {
            return viewNames.First(view => ViewExists(ctx, view));
        }

        protected bool ViewExists(ControllerContext ctx, string name)
        {
            var result = ViewEngines.Engines.FindView(ctx, name, null);
            return result.View != null;
        }
    }
}
