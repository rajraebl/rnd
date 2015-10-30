using System.Collections.Generic;
using RU.Models;

namespace RU.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RU.Models.RUContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RU.Models.RUContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var StudentSet = new List<Student>
            {
                new Student { FirstName = "Carson",   LastName = "Alexander", 
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstName = "Meredith", LastName = "Alonso",    
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Arturo",   LastName = "Anand",     
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstName = "Gytis",    LastName = "Barzdukas", 
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Yan",      LastName = "Li",        
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Peggy",    LastName = "Justice",   
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstName = "Laura",    LastName = "Norman",    
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstName = "Nino",     LastName = "Olivetto",  
                    EnrollmentDate = DateTime.Parse("2005-08-11") }
            };
            StudentSet.ForEach(s => context.StudentSet.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var CourseSet = new List<Course>
            {
                new Course {CourseId = 1050, Title = "Chemistry",      Credits = 3, },
                new Course {CourseId = 4022, Title = "Microeconomics", Credits = 3, },
                new Course {CourseId = 4041, Title = "Macroeconomics", Credits = 3, },
                new Course {CourseId = 1045, Title = "Calculus",       Credits = 4, },
                new Course {CourseId = 3141, Title = "Trigonometry",   Credits = 4, },
                new Course {CourseId = 2021, Title = "Composition",    Credits = 3, },
                new Course {CourseId = 2042, Title = "Literature",     Credits = 4, }
            };
            CourseSet.ForEach(s => context.CourseSet.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var EnrollmentSet = new List<Enrollment>
            {
                new Enrollment { 
                    StudentId = StudentSet.Single(s => s.LastName == "Alexander").StudentId, 
                    CourseId = CourseSet.Single(c => c.Title == "Chemistry" ).CourseId, 
                    Grade = Grade.A 
                },
                 new Enrollment { 
                    StudentId = StudentSet.Single(s => s.LastName == "Alexander").StudentId,
                    CourseId = CourseSet.Single(c => c.Title == "Microeconomics" ).CourseId, 
                    Grade = Grade.C 
                 },                            
                 new Enrollment { 
                    StudentId = StudentSet.Single(s => s.LastName == "Alexander").StudentId,
                    CourseId = CourseSet.Single(c => c.Title == "Macroeconomics" ).CourseId, 
                    Grade = Grade.B
                 },
                 new Enrollment { 
                     StudentId = StudentSet.Single(s => s.LastName == "Alonso").StudentId,
                    CourseId = CourseSet.Single(c => c.Title == "Calculus" ).CourseId, 
                    Grade = Grade.B 
                 },
                 new Enrollment { 
                     StudentId = StudentSet.Single(s => s.LastName == "Alonso").StudentId,
                    CourseId = CourseSet.Single(c => c.Title == "Trigonometry" ).CourseId, 
                    Grade = Grade.B 
                 },
                 new Enrollment {
                    StudentId = StudentSet.Single(s => s.LastName == "Alonso").StudentId,
                    CourseId = CourseSet.Single(c => c.Title == "Composition" ).CourseId, 
                    Grade = Grade.B 
                 },
                 new Enrollment { 
                    StudentId = StudentSet.Single(s => s.LastName == "Anand").StudentId,
                    CourseId = CourseSet.Single(c => c.Title == "Chemistry" ).CourseId
                 },
                 new Enrollment { 
                    StudentId = StudentSet.Single(s => s.LastName == "Anand").StudentId,
                    CourseId = CourseSet.Single(c => c.Title == "Microeconomics").CourseId,
                    Grade = Grade.B         
                 },
                new Enrollment { 
                    StudentId = StudentSet.Single(s => s.LastName == "Barzdukas").StudentId,
                    CourseId = CourseSet.Single(c => c.Title == "Chemistry").CourseId,
                    Grade = Grade.B         
                 },
                 new Enrollment { 
                    StudentId = StudentSet.Single(s => s.LastName == "Li").StudentId,
                    CourseId = CourseSet.Single(c => c.Title == "Composition").CourseId,
                    Grade = Grade.B         
                 },
                 new Enrollment { 
                    StudentId = StudentSet.Single(s => s.LastName == "Justice").StudentId,
                    CourseId = CourseSet.Single(c => c.Title == "Literature").CourseId,
                    Grade = Grade.B         
                 }
            };

            foreach (Enrollment e in EnrollmentSet)
            {
                var enrollmentInDataBase = context.EnrollmentSet.Where(
                    s =>
                         s.Student.StudentId == e.StudentId &&
                         s.Course.CourseId == e.CourseId).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.EnrollmentSet.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
