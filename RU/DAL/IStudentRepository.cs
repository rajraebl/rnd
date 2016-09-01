using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RU.Models;

namespace RU.DAL
{
    public interface IStudentRepository :IDisposable
    {
        IEnumerable<Student> GetStudents();

        Student GetStudentById(int id);

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(int id);

        void Save();
        //
    }
}