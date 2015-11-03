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

        //The update-database command runs the Up method to create the database and then it runs the Seed method to populate the database.
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
            var students = new List<Student>
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
            //The first parameter passed to the AddOrUpdate method specifies the property to use to check if a row already exists.
            students.ForEach(s => context.StudentSet.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();
            var courses = new List<Course>
            {
                new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3, },
                new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3, },
                new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3, },
                new Course {CourseID = 1045, Title = "Calculus",       Credits = 4, },
                new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4, },
                new Course {CourseID = 2021, Title = "Composition",    Credits = 3, },
                new Course {CourseID = 2042, Title = "Literature",     Credits = 4, }
            };
            courses.ForEach(s => context.CourseSet.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").StudentID, 
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID, 
                    Grade = Grade.A 
                },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID, 
                    Grade = Grade.C 
                 },                            
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID, 
                    Grade = Grade.B
                 },
                 new Enrollment { 
                     StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment { 
                     StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID, 
                    Grade = Grade.B 
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Anand").StudentID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Anand").StudentID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                    Grade = Grade.B         
                 },
                new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Barzdukas").StudentID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B         
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Li").StudentID,
                    CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                    Grade = Grade.B         
                 },
                 new Enrollment { 
                    StudentID = students.Single(s => s.LastName == "Justice").StudentID,
                    CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                    Grade = Grade.B         
                 }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.EnrollmentSet.Where(
                    s =>
                         s.Student.StudentID == e.StudentID &&
                         s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.EnrollmentSet.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
