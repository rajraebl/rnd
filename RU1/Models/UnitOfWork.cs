using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RU1.Models
{
    public class UnitOfWork:IDisposable 
    {
        RU1Context context = new RU1Context();
        private GenericRepository<Department> departmentRepo;
        private GenericRepository<Course> courseRepo;

        public GenericRepository<Department> DepartmentRepo { 
            get {
                if (departmentRepo == null)
                departmentRepo = new GenericRepository<Department>(context);
            return departmentRepo;
        } }

        public GenericRepository<Course> CourseRepo { get {
            if (courseRepo == null)
                courseRepo = new GenericRepository<Course>(context);

            return courseRepo;
        } }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool explicitlyDisposing)
        {
            if (!disposed) {
                if (explicitlyDisposing)
                {
                    context.Dispose();
                }

            }
            disposed = true;
        }
    }
}