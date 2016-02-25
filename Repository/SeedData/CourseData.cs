using System.Collections.Generic;
using System.Linq;
using DomainModel;

namespace Repository.SeedData {
    public class CourseData {

        private static ContosoUniversityContext _context;

        public static void Seed(ContosoUniversityContext context) {

            _context = context;
            CreateCourseData();
        }


        private static void CreateCourseData() {

            var departments = _context.Departments.ToList();

            var courses = new List<Course> {
                new Course {Id = 1050, Title = "Chemistry",      Credits = 3, DepartmentId = departments.Single( s => s.Name == "Engineering").Id, Instructors = new List<Instructor>() },

                new Course {Id = 4022, Title = "Microeconomics", Credits = 3, DepartmentId = departments.Single( s => s.Name == "Economics").Id, Instructors = new List<Instructor>() },

                new Course {Id = 4041, Title = "Macroeconomics", Credits = 3, DepartmentId = departments.Single( s => s.Name == "Economics").Id, Instructors = new List<Instructor>() },

                new Course {Id = 1045, Title = "Calculus",       Credits = 4, DepartmentId = departments.Single( s => s.Name == "Mathematics").Id, Instructors = new List<Instructor>() },
               
                new Course {Id = 3141, Title = "Trigonometry",   Credits = 4, DepartmentId = departments.Single( s => s.Name == "Mathematics").Id, Instructors = new List<Instructor>() },

                new Course {Id = 2021, Title = "Composition",    Credits = 3, DepartmentId = departments.Single( s => s.Name == "English").Id, Instructors = new List<Instructor>() },

                new Course {Id = 2042, Title = "Literature",     Credits = 4, DepartmentId = departments.Single( s => s.Name == "English").Id, Instructors = new List<Instructor>() },
            };

            _context.Courses.AddRange(courses);
            _context.SaveChanges();
        }


    }
}