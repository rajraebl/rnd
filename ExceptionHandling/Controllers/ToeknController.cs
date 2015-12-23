using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace ExceptionHandling.Controllers
{
    public class TokenController : ApiController
    {
        private List<User> Users; 
        public TokenController()
        {
            Users = new List<User>();
            for (int i = 0; i < 1; i++)
            {
                Users.Add(new User() { AppId = "bXlhcGlrZXk=", Secret = "mrjBP2CQnOVhfPGrsZG2e+yDdylIMDkr/ALrCTV2arM=" });
            }
        }

          public HttpResponseMessage Post([FromBody]TokenRequestModel model)
           {
               var user = Users.Where(x => x.AppId == model.ApiKey).Single();
               if (user != null)
               {
                   var secret = user.Secret;
                   var key = Convert.FromBase64String(secret);
                   var provider = new System.Security.Cryptography.HMACSHA256(key);
                   var hash = provider.ComputeHash(Encoding.UTF8.GetBytes(user.AppId));
                   var signature = Convert.ToBase64String(hash);

                   if (signature == model.Signature)
                   {
                       var rawTokenInfo = string.Concat(user.AppId + DateTime.UtcNow.ToString("d"));
                       var rawTokenByte = Encoding.UTF8.GetBytes(rawTokenInfo);

                       var token = provider.ComputeHash(rawTokenByte);
                       var authToken = new AuthToken()
                       {
                           Token = Convert.ToBase64String( token),
                           Expiration = DateTime.UtcNow.AddDays(7), //this token will b valid fro next 7 days
                           ApiUser = user //user that owns this token, means this token only valid for this user.
                       };

                       //save this token in DB

                       return Request.CreateResponse(HttpStatusCode.Created, authToken);
                   }
               }

               return Request.CreateResponse(HttpStatusCode.BadRequest);
           }
    }

    public class User
    {
        public string AppId { get; set; }
        public string Secret { get; set; }
    }
}
