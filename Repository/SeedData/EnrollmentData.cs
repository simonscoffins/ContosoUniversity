using System.Collections.Generic;
using System.Linq;
using Model;

namespace Repository.SeedData {


    public static class EnrollmentData {

        private static ContosoUniversityContext _context;

        public static void Seed(ContosoUniversityContext context) {

            _context = context;
            CreateEnrollmentData();
        }


        private static void CreateEnrollmentData() {

            var students = _context.Students.ToList();
            var courses = _context.Courses.ToList();


            var enrollments = new List<Enrollment> {

                new Enrollment { StudentId = students.Single(s => s.LastName == "Alexander").Id, CourseId = courses.Single(c => c.Title == "Chemistry" ).Id, Grade = Grade.A },

                new Enrollment { StudentId = students.Single(s => s.LastName == "Alexander").Id, CourseId = courses.Single(c => c.Title == "Microeconomics" ).Id, Grade = Grade.C },                            

                new Enrollment { StudentId = students.Single(s => s.LastName == "Alexander").Id, CourseId = courses.Single(c => c.Title == "Macroeconomics" ).Id, Grade = Grade.B },

                new Enrollment { StudentId = students.Single(s => s.LastName == "Alonso").Id, CourseId = courses.Single(c => c.Title == "Calculus" ).Id, Grade = Grade.B },

                new Enrollment { StudentId = students.Single(s => s.LastName == "Alonso").Id, CourseId = courses.Single(c => c.Title == "Trigonometry" ).Id, Grade = Grade.B },

                new Enrollment { StudentId = students.Single(s => s.LastName == "Alonso").Id, CourseId = courses.Single(c => c.Title == "Composition" ).Id, Grade = Grade.B },

                new Enrollment { StudentId = students.Single(s => s.LastName == "Anand").Id, CourseId = courses.Single(c => c.Title == "Chemistry" ).Id }, 
                                
                new Enrollment { StudentId = students.Single(s => s.LastName == "Anand").Id, CourseId = courses.Single(c => c.Title == "Microeconomics").Id, Grade = Grade.B },

                new Enrollment { StudentId = students.Single(s => s.LastName == "Barzdukas").Id, CourseId = courses.Single(c => c.Title == "Chemistry").Id, Grade = Grade.B },
                
                new Enrollment { StudentId = students.Single(s => s.LastName == "Li").Id, CourseId = courses.Single(c => c.Title == "Composition").Id, Grade = Grade.B },

                new Enrollment { StudentId = students.Single(s => s.LastName == "Justice").Id, CourseId = courses.Single(c => c.Title == "Literature").Id, Grade = Grade.B }
            };

            _context.Enrollments.AddRange(enrollments);
            _context.SaveChanges();
        }

    }
}