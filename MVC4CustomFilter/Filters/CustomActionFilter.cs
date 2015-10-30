using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4CustomFilter.Models;

namespace MVC4CustomFilter.Filters
{
    //BOTH WAYS WORK............................
    
    /*
    public class CustomActionFilter:ActionFilterAttribute,IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            db.ActionLogs.Add(new ActionLog(){action=filterContext.ActionDescriptor.ActionName
                ,controller=filterContext.Controller.ToString()
                ,ip=filterContext.HttpContext.Request.UserHostAddress
                ,timestamp = filterContext.HttpContext.Timestamp.ToLongDateString()
            });
            this.OnActionExecuting(filterContext); // "THIS" KEYWORD SAYS THAT METHOD OF OBJECT OF THE CLASS
        }
    }
  */

    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            db.ActionLogs.Add(new ActionLog()
            {
                action = filterContext.ActionDescriptor.ActionName
                ,
                controller = filterContext.Controller.ToString()
                ,
                ip = filterContext.HttpContext.Request.UserHostAddress
                ,
                timestamp = filterContext.HttpContext.Timestamp.ToLongDateString()
            });
            base.OnActionExecuting(filterContext); //IF IN PLACE OF BASE WE USE THIS KEYWORD IT WILL BE INFININTE RECURSIVE CALL
        }

    }

}