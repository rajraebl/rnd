using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RU1.Models
{
    public class StudentRepository: IStudentRepository, IDisposable
    {
        RU1Context db;
        public StudentRepository(RU1Context _db)
        {
            db = _db;
        }

        public IEnumerable<Student> getStudents()
        {
            return db.tblStudent.ToList();
        }

        public Student getStudent(int id)
        {
            return db.tblStudent.Find(id);
        }

        public void addStudent(Student s)
        {
            db.tblStudent.Add(s);
        }

        public void updateStudent(Student s)
        {
            db.Entry(s).State = System.Data.EntityState.Modified;
        }

        public void deleteStudent(int id)
        {
            var stu = getStudent(id);
            db.Entry(stu).State = System.Data.EntityState.Deleted;
        }

        public void save()
        {
            db.SaveChanges();
        }

        bool disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool explicitlyDisposing)
        {
            if (!disposed)
            {
                if (explicitlyDisposing) {
                    db.Dispose();
                }

            }
            disposed = true;

        }
    }
}