using System;
using System.Threading.Tasks;
using BusinessServices.CQS;
using DomainModel;
using Repository;

namespace BusinessServices.Students {

    public class CreateStudentCommand {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        /// Output property for returning id of newly created entity
        /// </summary>
        public int Id { get; internal set; }
    }


    public class CreateStudentCommandHandler : IAsyncCommandHandler<CreateStudentCommand> {

        private readonly IUnitOfWork _uow;

        public CreateStudentCommandHandler(IUnitOfWork uow) {
            _uow = uow;
        }

        public async Task Handle(CreateStudentCommand command) {

            var student = new Student {
                FirstMidName = command.FirstName,
                LastName = command.LastName,
                EnrollmentDate = DateTime.Now
            };

            _uow.Set<Student>().Add(student);

            // save changes handle here explicitly instead of leaving for save command decorator in
            // order to pass back the dn gernerated id. The decorator will still call save changes but
            // ef will not call the db again as changes already saved.
            await _uow.SaveChangesAsync();
            command.Id = student.Id;
        }
    }
}