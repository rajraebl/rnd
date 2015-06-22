using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MvcApplication.Handlers
{
    public class CustomActionResult :ActionResult
    {
        public object data { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.Write(JsonConvert.SerializeObject(data));
        }
    }
}