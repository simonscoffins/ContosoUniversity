using System.Collections.Generic;
using System.Linq;
using DomainModel;

namespace Repository.SeedData {

    public class OfficeAssignmentData {

        private static ContosoUniversityContext _context;

        public static void Seed(ContosoUniversityContext context) {

            _context = context;
            CreateOfficeAssignmentData();
        }


        private static void CreateOfficeAssignmentData() {

            var instructors = _context.Instructors.ToList();

            var officeAssignments = new List<OfficeAssignment> {

                new OfficeAssignment {Id = instructors.Single( i => i.LastName == "Fakhouri").Id, Location = "Smith 17" },

                new OfficeAssignment {Id = instructors.Single( i => i.LastName == "Harui").Id, Location = "Gowan 27" },

                new OfficeAssignment {Id = instructors.Single( i => i.LastName == "Kapoor").Id, Location = "Thompson 304" },
            };

            _context.OfficeAssignments.AddRange(officeAssignments);
            _context.SaveChanges();
        }


    }
}