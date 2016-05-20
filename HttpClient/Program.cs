using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HttpClientForRestCall
{
    class Program
    {
        static string apiUrl = "http://api.worldbank.org/countries?format=json";

        static void Main(string[] args)
        {
            //https://blogs.msdn.microsoft.com/henrikn/2012/02/16/httpclient-is-here/

            Console.WriteLine("Api Call started. Press enter to go ahead......");
            Console.ReadLine();

            NewWay();

            //OldWay();
            //NewWayCopy();

            //WebRequestWay();

            //Fifthway();

            //sisthWay();
            Console.ReadLine();

        }

        private async static void NewWay()
        {
            var httpclient = new HttpClient();

            //Send a request asynchronously continue when complete
            HttpResponseMessage response = await httpclient.GetAsync(apiUrl);
            
            // Check that response was successful or throw exception
            response.EnsureSuccessStatusCode();
       
            // Read response asynchronously as JsonValue and write out top facts for each country
            //you can read header as well as content from the response. chose whatever you want . we chose the content below
            JArray content = await response.Content.ReadAsAsync<JArray>();

            Console.WriteLine("First 50 countries listed by The World Bank...");
            int i = 0;

            foreach (var country in content[1])
            {
                Console.Write(++i);
                Console.WriteLine("     {0}, CountryCode: {1}, Capital: {2}, Lattitude:{3}, Longitude:{4}", country["name"],
                          country["iso2Code"],
                           country["capitalCity"],
                           country["latitude"],
                           country["longitude"]);

            }
        }

        private static async void NewWayCopy()
        {
            HttpClient hc = new HttpClient();
            HttpResponseMessage httpResponse = await hc.GetAsync(apiUrl);

            httpResponse.EnsureSuccessStatusCode();

            JArray content = await httpResponse.Content.ReadAsAsync<JArray>();

            foreach (var country in content[1])
            {
                Console.WriteLine(country["name"]);
            }
        }

        public static void OldWay()
        {
            // Create an HttpClient instance
            var httpClient = new HttpClient();

            // Send a request asynchronously continue when complete
            httpClient.GetAsync(apiUrl).ContinueWith(
                (apiRequestTask) =>
                {
                    // Get HTTP response from completed task.
                    HttpResponseMessage response = apiRequestTask.Result;

                    // Check that response was successful or throw exception
                    response.EnsureSuccessStatusCode();

                    // Read response asynchronously as JsonValue and write out top facts for each country
                    response.Content.ReadAsAsync<JArray>().ContinueWith(
                        (readtask) =>
                        {
                            Console.WriteLine("First 50 countries listed by The World Bank...");
                            int i = 0;
                            foreach (var country in readtask.Result[1])
                            {
                                Console.Write(++i);
                                Console.WriteLine("     {0}, CountryCode: {1}, Capital: {2}, Lattitude:{3}, Longitude:{4}", country["name"],
                                          country["iso2Code"],
                                           country["capitalCity"],
                                           country["latitude"],
                                           country["longitude"]);
                            }
                        }
                    );
                }
            );
        }

        public static void WebRequestWay()
        {
            /*
             string URL = "http://localhost:32319/ServiceEmployeeLogin.svc/getattendance";
    WebRequest wrGETURL;
    wrGETURL = WebRequest.Create(URL + "/" + Server.UrlEncode("24-06-2014"));
    wrGETURL.Method = "POST";
    wrGETURL.ContentType = @"application/json; charset=utf-8";
    HttpWebResponse webresponse = wrGETURL.GetResponse() as HttpWebResponse;

    Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
    // read response stream from response object
    StreamReader loResponseStream = new StreamReader(webresponse.GetResponseStream(), enc);

    // read string from stream data
    strResult = loResponseStream.ReadToEnd();
    // close the stream object
    loResponseStream.Close();
    // close the response object
    webresponse.Close();
             */

        }

        public static void Fifthway()
        {
            /*
             HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json"; 
            request.ContentLength = DATA.Length;
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            requestWriter.Write(DATA);
            requestWriter.Close();

             try {
                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();
                Console.Out.WriteLine(response);
                responseReader.Close();
            } catch (Exception e) {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }
             */
        }

        public static void sixthway()
        {
            const string URL = "https://sub.domain.com/objects.json";
            string urlParameters = "?api_key=123";

            
        /*
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                foreach (var d in dataObjects)
                {
                    Console.WriteLine("{0}", d.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }  
        */}
        }

        }


    

