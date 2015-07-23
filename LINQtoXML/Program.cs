using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQtoXML
{
    class Program
    {//http://www.dotnetcurry.com/ShowArticle.aspx?ID=564

        static string fileName = Path.GetFullPath("employees.xml");

        static void Main(string[] args)
        {

            //ReadXmlViaXElement();
            //ReadXmlViaXDocument(); //will include Employees root tag as well
            //ReadSingleElement();
            //ReadMultipleElements();
            
            //ReadXMLWithFilter();

            //ReadNestedElement();

            //Sorting();

            //PositionedElement();
            //RunTimeAdd();

            RemoveAttribute();

            Console.Read();

        }

        private static void RemoveAttribute()
        {
            XElement xEle = XElement.Load(fileName);

            var phone = xEle.Elements("Employee").Elements("Phone").ToList();

            foreach (var xElement in phone)
            {
                xElement.RemoveAttributes(); // remove all attribute availbale the Phone element (Type=Home)
            }

            cc(xEle.ToString());

            ccc("-----------------");

            XElement y = XElement.Load(fileName);

            var addressElements = y.Elements("Employee");//.ToList();

            foreach (var addressElement in addressElements)
            {
                addressElement.SetElementValue("Address", null); //Delete an Element
            }

            cc(y.ToString());

        }

        private static void RunTimeAdd()
        {
            XElement xEle = XElement.Load(fileName);
            xEle.Add(new XElement("Employee",
                new XElement("EmpId", 5),
                new XElement("Name", "George")));

            Console.Write(xEle);
        }

        private static void PositionedElement()
        {
            XDocument x = XDocument.Load(fileName);

            var kk = x.Descendants("Employee").ElementAt(0); // will give 1st Employee from list
            cc(kk.ToString());

            var emps = x.Descendants("Employee").Take(2); // first 2 from the list
            foreach (var emp in emps)
                cc(emp.ToString());

            var emps1 = x.Descendants("Employee").Skip(1).Take(2); // 2nd and 3rd Element using LINQ to XML
            foreach (var emp in emps1)
                cc(emp.ToString());

        }

        private static void Sorting()
        {
            XElement x = XElement.Load(fileName);

            IEnumerable<string> codes = from _phones in x.Elements()
                                         let ph = _phones.Element("Address").Element("Zip").Value
                                         orderby ph descending 
                                         select ph;
            foreach (string zp in codes)
                Console.WriteLine(zp);
        }

        private static void ReadNestedElement()
        {
            XElement x = XElement.Load(fileName);

            var addressess = from address in x.Elements("Employee")
                             where address.Element("Address").Element("City").Value == "Alta"
                select address;

            foreach (var femp in addressess)
            {
                cc(femp.ToString());
            }


            ccc("List of all zipCode");

            foreach (var VARIABLE in x.Descendants("Zip"))
            {
                cc(VARIABLE.ToString());
            }
            ccc("List of all Phones");

            foreach (var VARIABLE in x.Descendants("Phone"))
            {
                cc(VARIABLE.ToString());
            }

        }

        private static void ReadXMLWithFilter()
        {
            XElement x = XElement.Load(fileName);

            var filteredEmps = from emp in x.Elements()
                               where (string)emp.Element("Sex") == "Female"
                select emp;

            foreach (var femp in filteredEmps)
            {
                //cc(femp.ToString());
            }

            var attributeFilteredEmps = from AttributeFilteredEmps in x.Elements()
                                        where AttributeFilteredEmps.Element("Phone").Attribute("Type").Value == "Home"
                                        select AttributeFilteredEmps;

            foreach (var femp in attributeFilteredEmps)
            {
                cc(femp.ToString());
            }

        }

        private static void ReadMultipleElements()
        {
            XElement x = XElement.Load(fileName);

            IEnumerable<XElement> emps = x.Elements();

            foreach (var emp in emps)
            {
                cc(emp.Element("Name").Value);
                cc(emp.Element("EmpId").Value);
            }
        }

        private static void ReadSingleElement()
        {
            XDocument x = XDocument.Load(fileName);

            IEnumerable <XElement> elements = x.Root.Elements();

            foreach (var emps in elements)
            {
                cc(emps.Element("Name").Value);
            }

        }

        private static void ReadXmlViaXDocument()
        {
            XDocument xElement = XDocument.Load(fileName);

            IEnumerable<XElement> employees = xElement.Elements(); //xElement.Root.Elements();

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
