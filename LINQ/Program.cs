using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DB();
            var kk = from studentrow in db.tblStudent join schoolRow in db.tblSchool on studentrow.SchoolId equals schoolRow.Id select new { studentName= studentrow.Name,schoolName = schoolRow.Name};

            foreach (var item in kk)
            {
                Console.WriteLine("{0} studied at {1}", item.studentName, item.schoolName);
            }

            Console.Read();

        }

        

    }

    public class DB
    {
        public IList<School> tblSchool
        {
            get
            {
                return new List<School> 
                { 
                new School{ Id=1, Name="Vidya Mandir Red"}
                ,new School{ Id=2, Name="Vidya Mandir Blue"}
                };
            }
            set { tblSchool = value; } 
        }

        public List<Student> tblStudent
        {
            get
            {
                return new List<Student> { 
                    new Student{ Id=1, Age =20, Name="Rajesh", SchoolId=1}
                    ,new Student{ Id=2, Age =21, Name="Rakesh", SchoolId=1}
                    ,new Student{ Id=3, Age =22, Name="Ramesh", SchoolId=1}
                    ,new Student{ Id=4, Age =22, Name="SLJ", SchoolId=2}
                    ,new Student{ Id=5, Age =22, Name="Rita", SchoolId=2}
                };
        }
            set        {                tblStudent = value;}
        }
    }
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
        public int SchoolId { get; set; }
    }
}
