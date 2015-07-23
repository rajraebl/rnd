using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace nmsphttpWebRequest
{
    //http://www.codeproject.com/Articles/18034/HttpWebRequest-Response-in-a-Nutshell-Part
    class Program
    {
        static void Main(string[] args)
        {
            //GetCall();
            //GetCallWithParam();
            //PostCall();
            PostCallWith();
            Console.Read();
        }

        private static void PostCall()
        {
            string dataToBePosted = "=x1";
            byte[] buffer = Encoding.ASCII.GetBytes(dataToBePosted);

            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("http://localhost:24512/api/user");
            rq.Method = "POST";
            rq.ContentType = "application/x-www-form-urlencoded";
            rq.ContentLength = buffer.Length;


            Stream PostData = rq.GetRequestStream();
            PostData.Write(buffer, 0, buffer.Length);
            PostData.Close();

            HttpWebResponse rs = rq.GetResponse() as HttpWebResponse;

            ccc(rs.Server);
            ccc(rs.StatusCode);

            ccc(new StreamReader(rs.GetResponseStream()).ReadToEnd());
        }

        private static void PostCallWith()
        {
            string dataToBePosted = "value=4&Id=5&Name=Rajesh";
            byte[] buffer = Encoding.ASCII.GetBytes(dataToBePosted);

            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("http://localhost:24512/api/user/?value=3");
            rq.Method = "POST";
            rq.ContentType = "application/x-www-form-urlencoded";
            rq.ContentLength = buffer.Length;


            Stream PostData = rq.GetRequestStream();
            PostData.Write(buffer, 0, buffer.Length);
            PostData.Close();

            HttpWebResponse rs = rq.GetResponse() as HttpWebResponse;

            ccc(rs.Server);
            ccc(rs.StatusCode);

            ccc(new StreamReader(rs.GetResponseStream()).ReadToEnd());
        }


        private static void GetCallWithParam()
        {

            HttpWebRequest wr = WebRequest.CreateHttp(string.Format("http://localhost:24512/api/user?{0}","var1=ola&id=5")) as HttpWebRequest;

            wr.Method = "GET";


            HttpWebResponse webResponse = (HttpWebResponse)wr.GetResponse();

            ccc(webResponse.StatusCode);
            cc(webResponse.Server);

            Stream Response = webResponse.GetResponseStream();

            StreamReader sr = new StreamReader(Response);

            cc(sr.ReadToEnd());


        }

        private static void GetCall()
        {

            HttpWebRequest wr = WebRequest.CreateHttp("http://localhost:24512/api/user") as HttpWebRequest;
            wr.Method = "GET";

            HttpWebResponse webResponse = (HttpWebResponse)wr.GetResponse();
            Stream Response = webResponse.GetResponseStream();

            StreamReader sr = new StreamReader(Response);

            ccc(webResponse.StatusCode);
            cc(webResponse.Server);

            cc(sr.ReadToEnd());

        }

        private static void cc(object s)
        {

            Console.WriteLine(s);
        }
        private static void ccc(object s)
        {
            Console.WriteLine("-------" + s);
        }

    }
}
