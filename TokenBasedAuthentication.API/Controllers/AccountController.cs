using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using TokenBasedAuthentication.API.Models;

namespace TokenBasedAuthentication.API.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository repo;

        public AccountController()
        {
            repo = new AuthRepository();
        }


        public async Task<IHttpActionResult> Register(UserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IdentityResult result = await repo.RegisterUserAsync(model);
            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult!=null)
            {
                return errorResult;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            throw new NotImplementedException();
        }

    }
}
