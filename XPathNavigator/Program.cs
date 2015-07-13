using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

//http://www.codeproject.com/Articles/52079/Using-XPathNavigator-in-C
namespace XPathNavigatornmsp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string fileName = Path.GetFullPath("books.xml");

                XPathDocument xpd = new XPathDocument(fileName);
                XPathNavigator xNav = xpd.CreateNavigator();

                //NavigateXML(xNav);
                //FindAllTitles(xNav);
                FindBooksByfILTER(xNav);
                Console.Read();
            }
            catch(XmlException ex)
            {
            }
        }

        private static void FindBooksByfILTER(XPathNavigator xNav)
        {
            var filter = "Fantasy";

            String Q = "//book/genre[@ genre=\'" + filter + "\']";
            XPathNodeIterator it = xNav.Select(Q);

            while(it.MoveNext())
                cc(it.Current.Value);

        }

        private static void FindAllTitles(XPathNavigator xNav)
        {
            //<?xml version="1.0"?>
            //<books>
            //  <book id="bk101">
            //    <author>Gambardella, Matthew</author>
            //    <title>XML Developer's Guide</title>
            //    <genre>Computer</genre>
            //    <price>44.95</price>
            //    <publish_date>2000-10-01</publish_date>
            //    <description>
            //      An in-depth look at creating applications
            //      with XML.
            //    </description>
            //  </book>
            ccc("All titles NODE in xml are");
            XPathNodeIterator it = xNav.Select("//book/title");
            while (it.MoveNext())
            {
                cc(it.Current.Value);
            }

            ccc("All ids ATTRIBUTE in xml are");
            it = xNav.Select("//book/@id");
            while (it.MoveNext())
            {
                cc(it.Current.Value);
            }


        }

        private static void NavigateXML(XPathNavigator xNav)
        {
//            <?xml version="1.0"?>
//<books>
//  <book id="bk101">
//    <author>Gambardella, Matthew</author>
//    <title>XML Developer's Guide</title>
//    <genre>Computer</genre>
//    <price>44.95</price>
//    <publish_date>2000-10-01</publish_date>
//    <description>
//      An in-depth look at creating applications
//      with XML.
//    </description>
//  </book>

            Console.WriteLine("==========XPathDocument has a data model that is read-only=============");

            xNav.MoveToRoot();
            xNav.MoveToFirstChild();
            xNav.MoveToFirstChild();
            cc("displaying attribute");

            do
            {
                xNav.MoveToFirstAttribute();
                cc(xNav.Name + "=" + xNav.Value);
                xNav.MoveToParent();

                xNav.MoveToFirstChild();
                cc(xNav.Name + "=" + xNav.Value);

                while (xNav.MoveToNext())
                    ccc(xNav.Name + "=" + xNav.Value);
                xNav.MoveToParent();
            } while (xNav.MoveToNext()); 


            var kk = xNav.ToString();


        }

        private static void cc(string s)
        {
            Console.WriteLine(s);
        }
        private static void ccc(string s)
        {
            Console.WriteLine("-------"+s);
        }

    }
}
