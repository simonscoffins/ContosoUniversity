using System.Data.Entity;
using System.Threading.Tasks;
using DomainModel;
using DTOs;
using Repository;

namespace BusinessServices.Students {

    public class DeleteStudentCommand {

        public int Id { get; set; }
    }


    public class DeleteStudentCommandHandler : IAsyncCommandHandler<DeleteStudentCommand> {

        private readonly IUnitOfWork _uow;

        public DeleteStudentCommandHandler(IUnitOfWork uow) {
            _uow = uow;
        }

        public async Task Handle(DeleteStudentCommand command) {

            var student = new Student { Id = command.Id };

            _uow.Entry(student).State = EntityState.Deleted;
            _uow.Set<Student>().Remove(student);

            await _uow.SaveChangesAsync();
        }
    }
}