using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ui_gridWithMVC.Controllers
{
    public class uiGridController : Controller
    {
        //
        // GET: /uiGrid/

        public ActionResult Index()
        {
            return View();
        }

        public void GenerateXml()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.GetAsync("http://localhost:32060/myapiprefix/GetStudents").Result;

            response.EnsureSuccessStatusCode();

            JArray contents = response.Content.ReadAsAsync<JArray>().Result;

            var doc = new XElement("Student");
            //XElement and XAttribute are the two  very important classes available in System.Xml.Linq.dll assembly. Using these two classes you can do lot of things in the LINQ to XML world.
            foreach (var item in contents)
            {
                doc.Add(new XElement("EMPLOYEE_INFO"
                    , new XAttribute("FirstName", item["FirstName"])
                    , new XAttribute("LastName", item["LastName"])
                    , new XAttribute("Gender", item["Gender"]), new XElement("Bio", new XAttribute("Class", item["Class"])
                                                                                    , new XAttribute("School", item["School"])
                                                                                    , new XAttribute("Domicile", item["Domicile"]))));
            }


            string fileName = "C#_EmployeeInfo_" + string.Format("{0:yyyy_MM_dd}", DateTime.Now) + ".xml";
            Response.ContentType = "text/xml";
            Response.AddHeader("content-disposition", "attachment; filename=\"" + fileName + "\"");
            Response.Write(doc);
            Response.End();
        }

    }
}
