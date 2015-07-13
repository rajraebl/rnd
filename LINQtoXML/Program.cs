using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQtoXML
{
    class Program
    {
        static string fileName = Path.GetFullPath("employees.xml");

        static void Main(string[] args)
        {

            //ReadXmlViaXElement();
            ReadXmlViaXDocument();
            Console.Read();

        }

        private static void ReadXmlViaXDocument()
        {
            XDocument xElement = XDocument.Load(fileName);

            IEnumerable<XElement> employees = xElement.Elements();

            foreach (var employee in employees)
            {
                cc(employee.ToString());
            }
        }

        private static void ReadXmlViaXElement()
        {
            XElement xElement = XElement.Load(fileName);

            IEnumerable<XElement> employees = xElement.Elements();

            foreach (var employee in employees)
            {
                cc(employee.ToString());
            }


        }

        private static void cc(string s)
        {

            Console.WriteLine(s);
        }
        private static void ccc(string s)
        {
            Console.WriteLine("-------" + s);
        }

    }
}
