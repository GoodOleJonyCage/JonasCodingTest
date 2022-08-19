using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace WebApi.Attributes
{
    public class LogApiRequestAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        /// <summary>
        /// For Web API controllers
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            var request = actionExecutedContext.Request;
            var response = actionExecutedContext.Response;
            var actionContext = actionExecutedContext.ActionContext;

            // Log API Call
             
        }
    }
}