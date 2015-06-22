using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace imgGallery.Controllers
{
    public class ImageController : ApiController
    {
        ImageDBEntities db = new ImageDBEntities();
        // GET api/image
        public IEnumerable<ImageDetail> Get()
        {
            return db.ImageDetails.ToList();
        }

        // GET api/image/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/image
        //public void Post([FromBody]string value)
        //{
        //}

       [System.Web.Http.HttpPost]
        //public JsonResult UploadFile([FromBody]HttpPostedFile file)
        public JsonResult UploadFile()
        {
            string Message, fileName;
            Message = fileName = string.Empty;
            bool flag = false;
            if (HttpContext.Current.Request.Files != null)
            {
                var file = HttpContext.Current.Request.Files[0];
                fileName = file.FileName;
                try
                {
                    file.SaveAs(Path.Combine(HttpContext.Current.Server.MapPath("~/content/Images"), fileName));
                    Message = "File uploaded";
                    flag = true;
                }
                catch (Exception)
                {
                    Message = "File upload failed! Please try again";
                }
            }
            return new JsonResult { Data = new { Message = Message, Status = flag } };
        }


        public HttpResponseMessage Post(ImageDetail id)
        {
            db.ImageDetails.Add(id);
            db.SaveChanges();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, id);
            return response;
        }
    }
}
