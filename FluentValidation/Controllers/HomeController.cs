using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//http://www.c-sharpcorner.com/UploadFile/3d39b4/Asp-Net-mvc-validation-using-fluent-validation/
using FluentValidation.Models;
using FluentValidation.Results;

namespace FluentValidation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student s)
        {
            StudentValidator v = new StudentValidator();
            ValidationResult r = v.Validate(s);

            if (r.IsValid)
            {
                ViewBag.F = s.FirstName;
                ViewBag.L = s.LastName;
            }
            else
            {
                foreach (var err in r.Errors)
                {
                    ModelState.AddModelError(err.PropertyName, err.ErrorMessage);
                    
                }
            }
            return View(s);
        }

        public ActionResult AddStudent()
        {
            return View();
        }
    }
}
