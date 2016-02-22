using System.Data.Entity;
using DTOs;
using Model;
using Repository;

namespace BusinessServices.Students {

    public class DeleteStudentCommand {

        public int Id { get; set; }
    }


    public class DeleteStudentCommandHandler : ICommandHandler<DeleteStudentCommand> {

        private readonly IUnitOfWork _uow;

        public DeleteStudentCommandHandler(IUnitOfWork uow) {
            _uow = uow;
        }

        public void Handle(DeleteStudentCommand command) {

            var student = new Student { Id = command.Id };

            _uow.Entry(student).State = EntityState.Deleted;
            _uow.Set<Student>().Remove(student);

            _uow.SaveChanges();
        }
    }
}