namespace RU2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RU2.Models;
    using RU2.DAL;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<RU2.DAL.RU2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RU2.DAL.RU2Context context)
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
                new Student { FirstMidName = "Carson",   LastName = "Alexander", 
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso",    
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Arturo",   LastName = "Anand",     
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Gytis",    LastName = "Barzdukas", 
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Yan",      LastName = "Li",        
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Peggy",    LastName = "Justice",   
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstMidName = "Laura",    LastName = "Norman",    
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Nino",     LastName = "Olivetto",  
                    EnrollmentDate = DateTime.Parse("2005-08-11") }
            };
         students.ForEach(s => context.tblStudent.AddOrUpdate(p => p.LastName, s));
         context.SaveChanges();

         var courses = new List<Course>
            {
                new Course {CourseId = 1050, Title = "Chemistry",      Credits = 3, },
                new Course {CourseId = 4022, Title = "Microeconomics", Credits = 3, },
                new Course {CourseId = 4041, Title = "Macroeconomics", Credits = 3, },
                new Course {CourseId = 1045, Title = "Calculus",       Credits = 4, },
                new Course {CourseId = 3141, Title = "Trigonometry",   Credits = 4, },
                new Course {CourseId = 2021, Title = "Composition",    Credits = 3, },
                new Course {CourseId = 2042, Title = "Literature",     Credits = 4, }
            };
         courses.ForEach(s => context.tblCourse.AddOrUpdate(p => p.Title, s));
         context.SaveChanges();

         var enrollments = new List<Enrollment>
            {
                new Enrollment { 
                    StudentId = students.Single(s => s.LastName == "Alexander").StudentId, 
                    CourseId = courses.Single(c => c.Title == "Chemistry" ).CourseId, 
                    Grade = Grade.A 
                },
                 new Enrollment { 
                    StudentId = students.Single(s => s.LastName == "Alexander").StudentId,
                    CourseId = courses.Single(c => c.Title == "Microeconomics" ).CourseId, 
                    Grade = Grade.C 
                 },                            
                 new Enrollment { 
                    StudentId = students.Single(s => s.LastName == "Alexander").StudentId,
                    CourseId = courses.Single(c => c.Title == "Macroeconomics" ).CourseId, 
                    Grade = Grade.B
                 },
                 new Enrollment { 
                     StudentId = students.Single(s => s.LastName == "Alonso").StudentId,
                    CourseId = courses.Single(c => c.Title == "Calculus" ).CourseId, 
                    Grade = Grade.B 
                 },
                 new Enrollment { 
                     StudentId = students.Single(s => s.LastName == "Alonso").StudentId,
                    CourseId = courses.Single(c => c.Title == "Trigonometry" ).CourseId, 
                    Grade = Grade.B 
                 },
                 new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Alonso").StudentId,
                    CourseId = courses.Single(c => c.Title == "Composition" ).CourseId, 
                    Grade = Grade.B 
                 },
                 new Enrollment { 
                    StudentId = students.Single(s => s.LastName == "Anand").StudentId,
                    CourseId = courses.Single(c => c.Title == "Chemistry" ).CourseId
                 },
                 new Enrollment { 
                    StudentId = students.Single(s => s.LastName == "Anand").StudentId,
                    CourseId = courses.Single(c => c.Title == "Microeconomics").CourseId,
                    Grade = Grade.B         
                 },
                new Enrollment { 
                    StudentId = students.Single(s => s.LastName == "Barzdukas").StudentId,
                    CourseId = courses.Single(c => c.Title == "Chemistry").CourseId,
                    Grade = Grade.B         
                 },
                 new Enrollment { 
                    StudentId = students.Single(s => s.LastName == "Li").StudentId,
                    CourseId = courses.Single(c => c.Title == "Composition").CourseId,
                    Grade = Grade.B         
                 },
                 new Enrollment { 
                    StudentId = students.Single(s => s.LastName == "Justice").StudentId,
                    CourseId = courses.Single(c => c.Title == "Literature").CourseId,
                    Grade = Grade.B         
                 }
            };

         foreach (Enrollment e in enrollments)
         {
            var enrollmentInDataBase = context.tblEnrollment.Where(
                s =>
                     s.Student.StudentId == e.StudentId &&
                     s.Course.CourseId == e.CourseId).SingleOrDefault();
            if (enrollmentInDataBase == null)
            {
               context.tblEnrollment.Add(e);
            }
         }
         context.SaveChanges();
      }
        }
    }

