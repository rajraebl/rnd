using FileUpload.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Home/Details/5

        public ActionResult Upload(HttpPostedFileBase fileFieldName, FormCollection formData)
        {
            //UploadsViewModel vm = Session["uploads"] == null ? new UploadsViewModel() : Session["uploads"] as UploadsViewModel;




            if (fileFieldName != null)
            {
                File Upload = new File();
                Upload.FilePath = Server.MapPath("~/Uploads/" + fileFieldName.FileName);
                Upload.FileName = fileFieldName.FileName;
                UploadsViewModel.Uploads.Add(Upload);
                fileFieldName.SaveAs((Upload.FilePath));
            }
            return PartialView("_Upload", UploadsViewModel.Uploads);
        }
        public ActionResult Uploads()
        {
            //UploadsViewModel vm = Session["uploads"] == null ? new UploadsViewModel() : Session["uploads"] as UploadsViewMod
            return PartialView("_Upload", UploadsViewModel.Uploads);
        }

    }
}
