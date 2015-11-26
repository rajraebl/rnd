using System;
using System.IO;
using System.ServiceModel.Web;
using System.Web.Hosting;

namespace WcfRestReturnImage
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public Stream GetImage()
        {
            FileStream fs = new FileStream(HostingEnvironment.MapPath("~/app_data/NewFeaturesInCSharp6.png"), FileMode.Open);
            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
            return fs;
        }
    }
}
