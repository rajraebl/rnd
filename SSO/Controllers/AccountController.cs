using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SSO.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/


        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userName, string password, string returnUrl)
        {
            //if (isValidCredential(userName, password))
            if(FormsAuthentication.Authenticate(userName,password))
            {
                FormsAuthentication.SetAuthCookie(userName, false);
                if (!string.IsNullOrEmpty(returnUrl))
                {
                   return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");    
                }
                
            }
            else
            {
                ModelState.AddModelError("", "Invalid login details");

                ViewBag.returnUrl = returnUrl;
                return View();
            }
        }

        private bool isValidCredential(string userName, string password)
        {
            if (userName == "rajesh")
                return true;
            return false;
        }

    }
}
