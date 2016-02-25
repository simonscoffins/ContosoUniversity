using System.Data.Entity;
using DomainModel;

namespace Repository {
    public class ContosoUniversityContext : DbContext, IUnitOfWork {

        public ContosoUniversityContext()
            : base("ContosoUniversity") {

        }


        static ContosoUniversityContext() {
            System.Data.Entity.Database.SetInitializer(new ContextInitializer());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Person> People { get; set; }

    }
}