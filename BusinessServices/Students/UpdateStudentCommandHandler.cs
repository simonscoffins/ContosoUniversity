using DTOs;
using Model;
using Repository;

namespace BusinessServices.Students {

    public class UpdateStudentCommand {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    public class UpdateStudentCommandHandler : ICommandHandler<UpdateStudentCommand> {

        private readonly IUnitOfWork _uow;


        public UpdateStudentCommandHandler(IUnitOfWork uow) {
            _uow = uow;
        }

        public void Handle(UpdateStudentCommand command) {

            var student = _uow.Set<Student>().Find(command.Id);

            student.FirstMidName = command.FirstName;
            student.LastName = command.LastName;

            // move to decorator
            _uow.SaveChanges();
        }
    }
}