using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XSLT_Play.Controllers
{
    public class HomeController : Controller
    {
        //static string xsltFileName = Path.GetFullPath("XSLT_Tabular.xslt");
        //Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data"), TransformFileName);
        //
        // GET: /Home/
        string fileName = HostingEnvironment.MapPath("~/Employees.xml");
        string xsltFileName = HostingEnvironment.MapPath("~/XSLT_Tabular.xslt");
        private string xsltFunctionFileNAme = HostingEnvironment.MapPath("~/XSLT_Tabular_Function.xslt");
        private string xsltParam = HostingEnvironment.MapPath("~/xsltParam.xslt");
        string xsltSortFileName = HostingEnvironment.MapPath("~/xsltSortFileName.xslt");
        string FilterFile = HostingEnvironment.MapPath("~/Filter.xslt");
        string XSLTFormFile = HostingEnvironment.MapPath("~/XSLTForm.xslt");
        string CalenderFile = HostingEnvironment.MapPath("~/Calender.xslt");
        
        public ActionResult Index()
        {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);

            XslTransform xslTransform = new XslTransform();
            xslTransform.Load(xsltFileName);

            //XmlTextWriter xmlTextWriter = new XmlTextWriter(Server.MapPath("~/op.xml"), System.Text.Encoding.Default);

            Stream s = new MemoryStream();
            
            XmlTextWriter xmlTextWriter = new XmlTextWriter(s, System.Text.Encoding.ASCII);

            xslTransform.Transform(xmlDocument.CreateNavigator(), null, xmlTextWriter, null);
            //xmlTextWriter.Close();

            s.Position = 0;
            var kk = new StreamReader(s).ReadToEnd();
            ViewBag.data = kk;
            xmlTextWriter.Close();
            s.Close();
            //Response.Write();
            return View();
        }

        //
        // GET: /Home/Details/5

        public ActionResult Index1()
        {
            XmlDocument x = new XmlDocument();
            x.Load(fileName);

            XslTransform xt = new XslTransform();
            xt.Load(xsltFunctionFileNAme);

            Stream s = new MemoryStream();

            XmlTextWriter xmlTextWriter = new XmlTextWriter(s,System.Text.Encoding.ASCII);

            xt.Transform(x.CreateNavigator(), null, xmlTextWriter, null);
            s.Position = 0;
            var kk = new StreamReader(s).ReadToEnd();
            ViewBag.data = kk;
            s.Close();
            xmlTextWriter.Close();

            return View();
        }


        public ActionResult Variable()
        {
            XmlDocument x = new XmlDocument();
            x.Load(fileName);

            XslTransform xt = new XslTransform();
            xt.Load(xsltParam);

            Stream s = new MemoryStream();

            //XmlTextWriter xmlTextWriter = new XmlTextWriter(s, System.Text.Encoding.ASCII);
            XsltArgumentList argument = new XsltArgumentList();
            //argument.AddParam("ttlrcrds","",7);

            xt.Transform(x.CreateNavigator(), argument, s, null);
            s.Position = 0;
            var kk = new StreamReader(s).ReadToEnd();
            ViewBag.data = kk;
            s.Close();
            //xmlTextWriter.Close();

            return View();
        }


        public ActionResult Sort()
        {
            XmlDocument x = new XmlDocument();
            x.Load(fileName);

            XslTransform xt = new XslTransform();
            xt.Load(xsltSortFileName);

            Stream s = new MemoryStream();

            xt.Transform(x.CreateNavigator(), null, s, null);
            s.Position = 0;
            var kk = new StreamReader(s).ReadToEnd();
            ViewBag.data = kk;
            s.Close();

            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Filter()
        {
            XmlDocument x = new XmlDocument();
            x.Load(fileName);

            XslTransform xt = new XslTransform();
            xt.Load(FilterFile);

            Stream s = new MemoryStream();

            xt.Transform(x.CreateNavigator(), null, s, null);
            s.Position = 0;
            var kk = new StreamReader(s).ReadToEnd();
            ViewBag.data = kk;
            s.Close();

            return View();
        }

        public ActionResult XSLTForm()
        {
            XmlDocument x = new XmlDocument();
            x.Load(fileName);

            XslTransform xt = new XslTransform();
            xt.Load(XSLTFormFile);

            Stream s = new MemoryStream();

            xt.Transform(x.CreateNavigator(), null, s, null);
            s.Position = 0;
            var kk = new StreamReader(s).ReadToEnd();
            ViewBag.data = kk;
            s.Close();

            return View();
        }
        public ActionResult Calender()
        {
            XmlDocument x = new XmlDocument();
            x.Load(HostingEnvironment.MapPath("~/calender.xml"));

            XslTransform xt = new XslTransform();
            xt.Load(CalenderFile);

            Stream s = new MemoryStream();

            xt.Transform(x.CreateNavigator(), null, s, null);
            s.Position = 0;
            var kk = new StreamReader(s).ReadToEnd();
            ViewBag.data = kk;
            s.Close();

            return View();
        }



        public ActionResult XsltValidation()
        {
            XPathDocument x = new XPathDocument(HostingEnvironment.MapPath("~/XsltValidationIP.xml"));
            XslTransform xt = new XslTransform();
            xt.Load(HostingEnvironment.MapPath("~/XsltValidation.xslt"));

            XmlTextWriter tw = new XmlTextWriter(HostingEnvironment.MapPath("~/XsltValidationOP.xml"), null);


            xt.Transform(x, null, tw);
            tw.Close();
            StreamReader s = new StreamReader(HostingEnvironment.MapPath("~/XsltValidationOP.xml"));

            var kk = s.ReadToEnd();
            ViewBag.data = kk;
            s.Close();
            return View();
        }

        public ActionResult XsltValidationWithExternalMethod()
        {
            //XPathDocument x = new XPathDocument(HostingEnvironment.MapPath("~/XsltValidationWithExternalMethodIP.xml"));
            //XslTransform xt = new XslTransform();
            //xt.Load(HostingEnvironment.MapPath("~/XsltValidation.xslt"));

            //XmlTextWriter tw = new XmlTextWriter(HostingEnvironment.MapPath("~/XsltValidationOP.xml"), null);


            //xt.Transform(x, null, tw);
            //tw.Close();
            //StreamReader s = new StreamReader(HostingEnvironment.MapPath("~/XsltValidationOP.xml"));

            //var kk = s.ReadToEnd();
            //ViewBag.data = kk;


            XPathDocument x = new XPathDocument(HostingEnvironment.MapPath("~/XsltValidationWithExternalMethodIP.xml"));
            XslTransform xt = new XslTransform();
            xt.Load(pp("~/XsltValidationWithExternalMethod.xslt"));

            XmlTextWriter xtw = new XmlTextWriter(pp("~/XsltValidationWithExternalMethodOP.xml"), null);


            XsltArgumentList xal = new XsltArgumentList();
            HomeController hc = new HomeController();

            //XSLT extension objects are added to the XsltArgumentList object using the AddExtensionObject method. 
            //A qualified name and namespace URI are associated with the extension object at that time.
            xal.AddExtensionObject("urn:actl-xslt",hc); // via this u can inject any class object that may have ur utility methods to do some work

            xt.Transform(x, xal, xtw);
            xtw.Close();

            StreamReader s = new StreamReader(pp("~/XsltValidationWithExternalMethodOP.xml"));

            ViewBag.data = s.ReadToEnd();
            s.Close();

            return View();
        }

        public string validateUser(string u, string p)
        {
            string op = string.Empty;
            if (u == "raje")
                op = "<success><msg>success></msg><succCode>007</succCode></success>";
            else
            {
                op = "<error><errmsg>UserName is not valid</errmsg><errcode>701</errcode></error>";
            }
            return op;
        }


        public ActionResult XsltValidationMultipleTests()
        {
            ViewBag.data = ProcessorWrapper("XsltValidationMultipleTests");

            //ViewBag.data = kk;
            return View();
        }

private dynamic ProcessorWrapper(string fileName)
{

    XPathDocument x = new XPathDocument(HostingEnvironment.MapPath("~/" + fileName + ".xml"));
    XslTransform xt = new XslTransform();
    xt.Load(HostingEnvironment.MapPath("~/" + fileName + ".xslt"));

    XmlTextWriter tw = new XmlTextWriter(HostingEnvironment.MapPath("~/" + fileName + "op.xml"), null);


    xt.Transform(x, null, tw);
    tw.Close();
    StreamReader s = new StreamReader(HostingEnvironment.MapPath("~/"+ fileName+ "op.xml"));

    var kk = s.ReadToEnd();
    s.Close();
    return kk;
}

        

        static string pp(string ipPath)
        {
            var opPath = HostingEnvironment.MapPath(ipPath);
            return opPath;
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
