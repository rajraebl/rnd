using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TokenBasedAuthentication.API.Models
{
    public class AuthRepository :IDisposable
    {
        private AuthContext ctx;
        private UserManager<IdentityUser> userManager; 

        public AuthRepository()
        {
            this.ctx = new AuthContext();
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(ctx));
        }

        public IdentityUser FindUser(string uName, string pwd)
        {
            IdentityUser user = userManager.Find(uName, pwd);
            return user;
        }

        public async Task<IdentityUser> FindUserAsync(string uName, string pwd)
        {
            IdentityUser user = await userManager.FindAsync(uName, pwd);
            return user;
        }


        public IdentityResult RegisterUser(UserModel model)
        {
            IdentityUser user = new IdentityUser(model.UserName);

            var result = userManager.Create(user, model.Password);
            return result;
        }
        public async Task<IdentityResult> RegisterUserAsync(UserModel model)
        {
            IdentityUser user = new IdentityUser(model.UserName);

            var result = await userManager.CreateAsync(user, model.Password);
            return result;
        }



        private bool disposed;
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool explicitlyDisposing)
        {
            if (explicitlyDisposing)
            {
                if (!disposed)
                {
                    ctx.Dispose();
                    userManager.Dispose();
                    disposed = true;
                }
            }
        }
    }
}