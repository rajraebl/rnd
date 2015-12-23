using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace ExceptionHandling.Filters
{
    /*http://www.asp.net/web-api/overview/error-handling/exception-handling
     * 
     An exception filter is executed when a controller method throws any unhandled exception that is not an HttpResponseException exception. 
     * The HttpResponseException type is a special case, because it is designed specifically for returning an HTTP response.
     * There are several ways to register a Web API exception filter:

By action
By controller
Globally
     */
    public class NotImplementedFilterAttribute :ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if(context.Exception is NotImplementedException)
            context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
        }
    }
}