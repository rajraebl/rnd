using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WSH.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //string uri = "http://localhost:56002/CalService";
            string uri = "http://localhost:8030/Service1.svc";
            var data = @"<s:Envelope xmlns:s='http://schemas.xmlsoap.org/soap/envelope/'>";
            //data = data + "<s:Header>";
           // data = data + "  <Action s:mustUnderstand='1' xmlns='http://schemas.microsoft.com/ws/2005/05/addressing/none'>http://tempuri.org/ICalcService/Substract</Action>";
           // data = data + "</s:Header>";
            data = data + "<s:Body>";
            data = data + "  <Substract xmlns='http://tempuri.org/'>";
            data = data + "    <a>3</a>";
            data = data + "    <b>23</b>";
            data = data + "  </Substract>";
            data = data + "</s:Body>";
            data = data + "</s:Envelope>";

            //SendBySoapRequest(data, "http://localhost:56002/CalService", 5000);

            var postData = "";

            /* postData = postData + "<soap:Envelope xmlns:soap='http://www.w3.org/2003/05/soap-envelope' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>";
             postData = postData + "<soap:Body>";
             postData = postData + "<EvaluateFlat xmlns = 'http://webservice.allsecur.fr'>";
             postData = postData + partnerRequest.InnerXml;
             postData = postData + "</EvaluateFlat>";
             postData = postData + "</soap:Body>";
             postData = postData + "</soap:Envelope>";
            
             var req = (HttpWebRequest)WebRequest.Create(uri);
             req.Method = "POST";
             */
            //var response = Send(req, data, "application/soap+xml; action='urn:Substract';charset=ISO-8859-15", Encoding.GetEncoding("ISO-8859-15"));
            //var response = Send(req, data, "text/xml;charset=\"utf-8\"", Encoding.GetEncoding("utf-8"));

            //var m = Send(uri, data, "text/xml;charset=utf-8",null,"ICalcService/Substract");
            //var m = Send(uri, data, "text/xml;charset=utf-8", null, "ICalcService/Substract");
            var m = Send("http://localhost:56002/CalService", data, "text/xml;charset=utf-8", null, "ICalcService/Substract");

            Console.WriteLine(m);
            Console.Read();

        }


        public static string Send(string uri, string dataToSend, string strContentType, Encoding encodingType, string soapActionHeader)
        {
            HttpWebRequest reqs = (HttpWebRequest)WebRequest.Create(uri);
            reqs.Headers.Add("SOAPAction", "http://tempuri.org/"+ soapActionHeader ); //required to tell the method to call on server. should be prefixed by interface
            //reqs.Headers.Add("To", uri);
            reqs.ContentType = strContentType; //required to match the content type wanted by server
            //reqs.Accept = "text/xml";
            reqs.Method = "POST"; //this verb is required if sending the content-body to server
            var bytes = Encoding.UTF8.GetBytes(dataToSend);
            reqs.ContentLength = bytes.Length;


            //GET THE REQUESTSTREAM(PIPELINE TO REACH TO SERVER) OF REQUEST OBJECT, THEN WRITE ALL DATA TO THAT STREAM THEN MAKE CALL TO GET RESPONSE
            using (Stream stm = reqs.GetRequestStream())
            {
                using (StreamWriter stmw = new StreamWriter(stm))
                {
                    stmw.Write(dataToSend);
                }
            }

            var res = "";
            WebResponse response = reqs.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                res = sr.ReadToEnd().Trim();
            }
            return res;
        }

        public static string Sendx(HttpWebRequest webRequest1, string dataToSend, string strContentType, Encoding encodingType)
        {

            //Convert our string to a byte array in the <<specified encoding Type>>

            var bytes = encodingType.GetBytes(dataToSend);

            webRequest1.ContentType = strContentType;
            //webRequest1.ContentLength = bytes.Length;
            try
            {
                //write bytes to server
                using (var os = webRequest1.GetRequestStream())
                {
                    os.Write(bytes, 0, bytes.Length);
                    os.Close();
                }

                //Get the response
                using (var webResponse = (HttpWebResponse)webRequest1.GetResponse())
                {
                    if (webResponse != null)
                    {
                        using (var sr = new StreamReader(webResponse.GetResponseStream(), encodingType))
                        {
                            //return the data as string

                            return sr.ReadToEnd().Trim();

                        }
                    }
                    else //we got no response, we return null
                        return null;
                }
            }

            catch (WebException ex)
            {

                //Cast web exception to HTTPWebResponse

                using (var errResp = ex.Response as HttpWebResponse)
                {
                    //Check if response is null

                    if (errResp == null)
                    {

                        return null;

                        //throw new WebException("Response was null");

                    }

                    using (var reader = new StreamReader(errResp.GetResponseStream()))
                    {

                        //Retrieve SOAP exception

                        return reader.ReadToEnd().Trim();
                    }
                }
            }
        }

        public static string SendBySoapRequest(string data, string uri, int timeout)
        {
            string response = null;

            var req = (HttpWebRequest)WebRequest.Create(uri);
            req.ContentType = "text/xml;charset=UTF-8";
            //req.Headers.Add("SOAPAction", "\"\"");
            req.Method = "POST";
            var bytes = Encoding.UTF8.GetBytes(data);
            req.ContentLength = bytes.Length;
            var stm = req.GetRequestStream();
            stm.Write(bytes, 0, bytes.Length);
            stm.Close();
            using (var resp = req.GetResponse())
            {
                stm = resp.GetResponseStream();
                if (stm != null)
                {
                    var r = new StreamReader(stm, Encoding.UTF8);
                    response = r.ReadToEnd();
                    stm.Close();
                }
            }
            return response;
            //return
            //    "<RETOUR_TARIF>  <TYPEFLUX>0</TYPEFLUX>  <TYPE>COTA</TYPE>  <PRODUIT>moto</PRODUIT>  <ASSUREUR>AMT</ASSUREUR>  <DESCRIPTION_ERREUR>Requête terminée avec succès</DESCRIPTION_ERREUR>  <ListeContactTechnique>    <NOM> EXPLOITATION APRIL WAF</NOM>    <PRENOM> </PRENOM>    <EMAIL>exploitation@april-waf.com</EMAIL>    <TEL>04 26 07 73 50</TEL>  </ListeContactTechnique>  <ListeTarifsFormules>    <BASIQUE>      <ANNUEL>502.49</ANNUEL>      <SEMESTRIEL>263.66</SEMESTRIEL>      <MENSUEL>46.01</MENSUEL>    </BASIQUE>    <BASIQUE_PLUS>      <ANNUEL>578.54</ANNUEL>      <SEMESTRIEL>305.15</SEMESTRIEL>      <MENSUEL>55.98</MENSUEL>    </BASIQUE_PLUS>    <COLLISION>      <ANNUEL>635.83</ANNUEL>      <SEMESTRIEL>335.23</SEMESTRIEL>      <MENSUEL>61.23</MENSUEL>    </COLLISION>    <TOUS_RISQUES>      <ANNUEL>703.5</ANNUEL>      <SEMESTRIEL>370.75</SEMESTRIEL>      <MENSUEL>67.43</MENSUEL>    </TOUS_RISQUES>  </ListeTarifsFormules>  <ListeTarifsGarantiesBase>    <anyType xsi:type=\"GARANTIE_BASE\">      <FRACTIONNEMENT>ANNUEL</FRACTIONNEMENT>      <GARANTIE>AMT RC</GARANTIE>      <PRIME_TOTALE>71,2</PRIME_TOTALE>      <PRIME_HT>53,3</PRIME_HT>      <COMAPP1>12</COMAPP1>      <TAXE>17,9</TAXE>    </anyType>  </ListeTarifsGarantiesBase>  <ListeTarifsGarantiesOption>    <anyType xsi:type=\"GARANTIE_OPTION\">      <GARANTIE>ASSI ZK</GARANTIE>      <PRIME_TOTALE>23,92</PRIME_TOTALE>      <PRIME_HT />      <TAXE />      <COMAPP1>5,25</COMAPP1>    </anyType>  </ListeTarifsGarantiesOption>  <FRANCHISE_DOUBLEE>400</FRANCHISE_DOUBLEE>  <ListeProtections>    <anyType xsi:type=\"PROTECTION\">      <PROTECTION1>Antivol Homologue de type U</PROTECTION1>      <PROTECTION2>Gravage</PROTECTION2>    </anyType>  </ListeProtections></RETOUR_TARIF>";
        }

    

    }
}
