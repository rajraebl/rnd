using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 http://www.codeproject.com/Articles/307452/common-use-of-Template-Design-pattern-Design-pat#_Toc312826646
    Create the template or the main process by creating a parent abstract class.
    Create the sub-processes by defining abstract methods and functions.
    Create a method which defines the sequence of how the sub-process methods will be called. This method should be defined as a normal method so that child methods cannot override it.
    Finally create the child classes which can alter the abstract methods or sub-process to define a new implementation.

 * One scenario where we see the Template pattern very much visible is in the ASP.NET page life cycle. 
 * For instance, in the ASP.NET page life cycle, we have various events like Init, Load, Validate, Prerender, Render, etc. 
 * The sequence is fixed, but we can override the implementation for each of these events as per our needs.
 */
namespace DesignPatterns
{
    public class TemplatePattern
    {
        public static void TemplatePatternMain()
        {
            SqlServerDataParser p1 = new SqlServerDataParser();
            p1.Process();
            Console.WriteLine("---------------------------------");
            FileDataParser p2 = new FileDataParser();
            p2.Process();
        }
    }

    public abstract class GeneralDataParserTemplate
    {
        protected abstract void Load();
        protected abstract void Parse();

        protected virtual void Dump()
        {
            Console.WriteLine("Dump Data in Reporting WareHouse");
        }

        public void Process()
        {
            Load();
            Parse();
            Dump();
        }

    }

    public class SqlServerDataParser :GeneralDataParserTemplate
    {
        protected override void Load()
        {
            Console.WriteLine("Connect to sql and Load dataset");
        }

        protected override void Parse()
        {
            Console.WriteLine("Loop through the dataset");
        }
    }

    public class FileDataParser : GeneralDataParserTemplate
    {

        protected override void Load()
        {
            Console.WriteLine("Load the data from Xml File");
        }

        protected override void Parse()
        {
            Console.WriteLine("Parse all the node via Linq to xml");
        }
    }


}
