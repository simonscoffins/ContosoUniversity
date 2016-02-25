using System;
using System.Collections.Generic;
using DomainModel;

namespace Repository.SeedData {
    public class InstructorData {

        private static ContosoUniversityContext _context;

        public static void Seed(ContosoUniversityContext context) {

            _context = context;
            CreateInstructorData();
        }


        private static void CreateInstructorData() {

            var instructors = new List<Instructor> {
                new Instructor { FirstMidName = "Kim", LastName = "Abercrombie", HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName = "Fadi", LastName = "Fakhouri", HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstMidName = "Roger", LastName = "Harui", HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstMidName = "Candace", LastName = "Kapoor", HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstMidName = "Roger",   LastName = "Zheng", HireDate = DateTime.Parse("2004-02-12") }
            };

            _context.Instructors.AddRange(instructors);
            _context.SaveChanges();
        }


    }
}