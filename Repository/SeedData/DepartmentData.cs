using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel;

namespace Repository.SeedData {

    public static class DepartmentData {

        private static ContosoUniversityContext _context;

        public static void Seed(ContosoUniversityContext context) {

            _context = context;
            CreateDepartmentData();
        }

        private static void CreateDepartmentData() {

            var instructors = _context.Instructors.ToList();

            var departments = new List<Department>
            {
                new Department { Name = "English",     Budget = 350000, StartDate = DateTime.Parse("2007-09-01"), InstructorId = instructors.Single( i => i.LastName == "Abercrombie").Id },

                new Department { Name = "Mathematics", Budget = 100000, StartDate = DateTime.Parse("2007-09-01"), InstructorId = instructors.Single( i => i.LastName == "Fakhouri").Id },

                new Department { Name = "Engineering", Budget = 350000, StartDate = DateTime.Parse("2007-09-01"), InstructorId = instructors.Single( i => i.LastName == "Harui").Id },

                new Department { Name = "Economics",   Budget = 100000, StartDate = DateTime.Parse("2007-09-01"), InstructorId = instructors.Single( i => i.LastName == "Kapoor").Id }
            };

            _context.Departments.AddRange(departments);
            _context.SaveChanges();
        }

    }



}