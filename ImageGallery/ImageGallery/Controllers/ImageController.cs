using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ImageGallery;
namespace ImageGallery.Controllers
{
    public class ImageController : ApiController
    {
        ImageDBEntities db = new ImageDBEntities();
        // GET api/image
        public IEnumerable<ImageDetail> Get()
        {
            return db.ImageDetails.AsEnumerable();
        }

        // GET api/image/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/image
        public void Post([FromBody]ImageDetail imageDetail)
        {
            db.ImageDetails.Add(imageDetail);
        }

        // PUT api/image/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/image/5
        public void Delete(int id)
        {
        }
    }
}
