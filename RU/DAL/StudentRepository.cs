using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using RU.Models;

namespace RU.DAL
{
    public class StudentRepository : IStudentRepository, IDisposable
    {
        RUContext db = new RUContext();

        public StudentRepository(RUContext context)
        {
            db = context;
        }
        public IEnumerable<Models.Student> GetStudents()
        {
            return db.StudentSet.ToList();
        }

        public Models.Student GetStudentById(int id)
        {
            return db.StudentSet.Find(id);
        }

        public void AddStudent(Models.Student student)
        {
            db.StudentSet.Add(student);
        }

        public void UpdateStudent(Models.Student student)
        {
            db.Entry(student).State = EntityState.Modified;
        }

        public void DeleteStudent(int id)
        {
            Student student = db.StudentSet.Find(id);
            db.StudentSet.Remove(student);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        // Flag: Has Dispose already been called?
        private bool disposed = false;

        //It should provide one public, non-virtual Dispose() method and a protected virtual Dispose(Boolean disposing) method.
//The Dispose() method must call Dispose(true) and should suppress finalization for performance.
//The base type should not include any finalizers.
        //They can provide a finalizer if needed. The finalizer must call Dispose(false).
        // If you are inheriting from another class that // also implements IDisposable, don't forget to call base.Dispose() as well.

        //// Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected  virtual void Dispose(bool explicitlyDisposing)
        {
            if (!disposed)
            {
                if (explicitlyDisposing) //// Free managed objects here.
                {
                    db.Dispose();
                }

                // Free any unmanaged objects here.
                //
            }

            this.disposed = true;
        }
    }
}

/*
 You need to use the Disposable Pattern like this:

private bool _disposed = false;

protected virtual void Dispose(bool disposing)
{
    if (!_disposed)
    {
        if (disposing)
        {
            // Dispose any managed objects
            // ...
        }

        // Now disposed of any unmanaged objects
        // ...

        _disposed = true;
    }
}

public void Dispose()
{
    Dispose(true);
    GC.SuppressFinalize(this);  
}

// Destructor
~YourClassName()
{
    Dispose(false);
}
 */