using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ExceptionHandling.Filters
{
    public class BasicAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext context)
        {// If this request was gievn credential in header then we can capture it from the context
            var authHeader = context.Request.Headers.Authorization;

            //If the authHeader is empty
            if (authHeader != null)
            {//check if the sceme is what we expect and that the credentials have bben send as header parameter
                if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(authHeader.Parameter))
                {
                    //this parameter would  be a base64 encoded string
                    var rawCredential = authHeader.Parameter;
                    var encoding = Encoding.GetEncoding("iso-8859-1");
                    var credentials = encoding.GetString( Convert.FromBase64String(rawCredential));
                    //asuming that credentilas are in format of username:password
                    //char delimiter = ':';
                    var split = credentials.Split(':');
                    //bcz we are sending uname and pwd over the wire better we do all things over https
                    var uname = split[0];
                    var pwd = split[1];

                    if (uname == "ola" && pwd == "pola")
                    {
                        var principla = new GenericPrincipal(new GenericIdentity(uname), null);
                        Thread.CurrentPrincipal = principla; // now the system know who the current user is
                        return; //i have validated credential. dont need anymore processing. let the call go wherever it was  going to.
                    }

                }
            }

            //IF AUTHORIZATION FAILS FAIL THE REQUEST
            HandleUnathorisedRequest(context);
        }

        void HandleUnathorisedRequest(HttpActionContext context)
        {
            context.Response = context.Request.CreateResponse(HttpStatusCode.Unauthorized);
            //we should inform the user where to go to login
            //location says where a user can go to get authenticate himself
            context.Response.Headers.Add("WWW-Authenticate", "Basic Scheme='myApp' location='http://localhost:8901/account/login'");
        }
    }
}