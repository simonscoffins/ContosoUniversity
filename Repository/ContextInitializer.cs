using System.Data.Entity;
using Repository.SeedData;

namespace Repository {

    public class ContextInitializer : CreateDatabaseIfNotExists<ContosoUniversityContext> {

        protected override void Seed(ContosoUniversityContext context) {
            base.Seed(context);

            StudentsData.Seed(context);
            InstructorData.Seed(context);
            DepartmentData.Seed(context);
            CourseData.Seed(context);
            OfficeAssignmentData.Seed(context);
            EnrollmentData.Seed(context);
        }
    }
}