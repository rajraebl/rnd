using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace xslt1
{
    class Program
    {//http://www.codeproject.com/Articles/17117/XSLT-Unleashed
        static string fileName = Path.GetFullPath("employees.xml");
        static string xsltFileName = Path.GetFullPath("XSLTFile1.xslt");

        static void Main(string[] args)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);

            XslTransform processor = new XslTransform();
            processor.Load(xsltFileName);

            XmlTextWriter op = new XmlTextWriter("output.xml", System.Text.Encoding.UTF8);

            processor.Transform(xmlDocument.CreateNavigator(), null, op, null);
            op.Close();
        }
    }
}
