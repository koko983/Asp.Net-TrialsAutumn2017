using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrialsAutumn2017.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolDbContext>
    {
        protected override void Seed(SchoolDbContext context)
        {
            var students = new List<Student>
            {
                new Student{FirstName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new Student{FirstName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
            
            var courses = new List<Course>
            {
                new Course{Title="Chemistry",},
                new Course{Title="Microeconomics",},
                new Course{Title="Macroeconomics",},
                new Course{Title="Calculus",},
                new Course{Title="Trigonometry",},
                new Course{Title="Composition",},
                new Course{Title="Literature",}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment{StudentId=1,CourseId=1050,Grade=99},
                new Enrollment{StudentId=1,CourseId=4022,Grade=99},
                new Enrollment{StudentId=1,CourseId=4041,Grade=99},
                new Enrollment{StudentId=2,CourseId=1045,Grade=99},
                new Enrollment{StudentId=2,CourseId=3141,Grade=99},
                new Enrollment{StudentId=2,CourseId=2021,Grade=99},
                new Enrollment{StudentId=3,CourseId=1050},
                new Enrollment{StudentId=4,CourseId=1050,},
                new Enrollment{StudentId=4,CourseId=4022,Grade=84},
                new Enrollment{StudentId=5,CourseId=4041,Grade=84},
                new Enrollment{StudentId=6,CourseId=1045},
                new Enrollment{StudentId=7,CourseId=3141,Grade=100},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}