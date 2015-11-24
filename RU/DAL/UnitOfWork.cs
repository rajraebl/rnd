using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*
 The unit of work class serves one purpose: to make sure that when you use multiple repositories, they share a single database context. 
 * That way, when a unit of work is complete you can call the SaveChanges method on that instance of the context and be assured that all related changes will be coordinated. 
 * All that the class needs is a Save method and a property for each repository and dbcontext class. 
 * Each repository property returns a repository instance that has been instantiated using the same database context instance as the other repository instances.
 */
using RU.Models;

namespace RU.DAL
{
    public class UnitOfWork : IDisposable
    {
        //variables for the database context and each repository
        RUContext context = new RUContext();
        private GenericRepository<Department> departmentRepository;
        //private GenericRepository<Course> courseRepository;
        private CourseRepository courseRepository;

        // instantiates the repository, passing in the context instance. As a result, all repositories share the same context instance.
        public GenericRepository<Department> DepartmentRepository
        {
            get
            {
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Department>(context);
                }
                return departmentRepository;
            }
        }

        // instantiates the repository, passing in the context instance. As a result, all repositories share the same context instance.
        //public GenericRepository<Course> CourseRepository
        public CourseRepository CourseRepository
        {
            get
            {
                if (this.courseRepository == null)
                {
                    //this.courseRepository = new GenericRepository<Course>(context);
                    this.courseRepository = new CourseRepository(context);
                }
                return courseRepository;
            }
        }

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

        protected virtual void Dispose(bool explicitDisposing)
        {
            if (!disposed)
            {
                if (explicitDisposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
    }
}