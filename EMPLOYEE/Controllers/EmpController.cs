using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using EMPLOYEE.Models;

namespace EMPLOYEE.Controllers
{
    public class EmpController : Controller
    {
        //
        // GET: /Emp/

        EmpContext db = new EmpContext();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getAll()
        {
            Thread.Sleep(700);
            return Json(db.tblEmp.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteEmp(int empId)
        {
            //Thread.Sleep(700);
            var emp = db.tblEmp.Find(empId);
            db.tblEmp.Remove(emp);
            db.SaveChanges();
            return Json("Employee Deleted", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddUpdateEmp(Employee emp)
        {
            var msg = "";
            if (emp.Id == 0)
            {
                msg = "Added";
                db.tblEmp.Add(emp);
            }
            else
            {
                var vm = db.tblEmp.Find(emp.Id);
                vm.Name = emp.Name;
                vm.Email = emp.Email;
                vm.Mobile = emp.Mobile;
                msg = "Edited";
            }
        

            db.SaveChanges();
            return Json(msg + " successfully!!", JsonRequestBehavior.AllowGet);
        }

    }
}
