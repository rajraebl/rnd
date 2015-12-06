using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RU1.Models
{
    public interface IStudentRepository:IDisposable
    {
        IEnumerable<Student> getStudents();
        Student getStudent(int id);
        void addStudent(Student s);
        void updateStudent(Student s);
        void deleteStudent(int id);
        void save();
        
    }
}