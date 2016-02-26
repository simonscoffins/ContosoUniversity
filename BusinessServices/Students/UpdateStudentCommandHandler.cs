using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BusinessServices.CQS;
using BusinessServices.Extensions;
using DomainModel;
using DTOs;
using Repository;
using TaskExtensions = BusinessServices.Extensions.TaskExtensions;

namespace BusinessServices.Students {

    public class UpdateStudentCommand {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    public class UpdateStudentCommandHandler : IAsyncCommandHandler<UpdateStudentCommand> {

        private readonly IUnitOfWork _uow;


        public UpdateStudentCommandHandler(IUnitOfWork uow) {
            _uow = uow;
        }

        public Task Handle(UpdateStudentCommand command) {

            var student = _uow.Set<Student>().Find(command.Id);

            student.FirstMidName = command.FirstName;
            student.LastName = command.LastName;


            return TaskExtensions.CompletedTask;
        }

    }
}