using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparable
{
    class Program
    {
        static void Main(string[] args)
        {
            var mm = GetStudents();
            var ll = mm.OrderBy(x => x.LastName);

            var s = mm.Where(x => x.Id == 1).FirstOrDefault();

            LoadAddress(s);

            var m = s;


            var jj = "ola pola";
            LoadAddress(jj);
            var str = jj;
        }


        public static  List<Student> GetStudents()
        {
            List<Student> students=new List<Student>();

            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student { Id= i, FirstName = "FirstNAme" + i, LastName = (10-i).ToString() + "LastName"  });
            }

            return students;
        }

        public static void  LoadAddress(Student s){
            s.MyAddress = new Address();
            s.MyAddress.add1 = "g-210";
        }
        public static void LoadAddress(string s)
        {
            //here u r disconnecting it. by giving it a new value;
            s = "g-210";
        }

    }

    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Address MyAddress { get; set; }
    }

    public class Address
    {
        public string add1 { get; set; }
        public string add2 { get; set; }
    }
}
