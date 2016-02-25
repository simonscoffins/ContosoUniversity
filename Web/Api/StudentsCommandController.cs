using System.Threading.Tasks;
using System.Web.Http;
using BusinessServices;
using BusinessServices.CQS.Commands;
using BusinessServices.Students;

namespace Web.Api {

    public class StudentsCommandController : ApiController {

        // commands
        private readonly ICommandHandler<UpdateStudentCommand> _updateStudent;
        private readonly ICommandHandler<CreateStudentCommand> _createStudent;
        private readonly IAsyncCommandHandler<DeleteStudentCommand> _deleteStudent;

        public StudentsCommandController(

            ICommandHandler<UpdateStudentCommand> updateStudent,
            ICommandHandler<CreateStudentCommand> createStudent,
            IAsyncCommandHandler<DeleteStudentCommand> deleteStudent) {

            _updateStudent = updateStudent;
            _createStudent = createStudent;
            _deleteStudent = deleteStudent;
        }



        [Route("api/updatestudent")]
        [HttpGet]
        public IHttpActionResult UpdateStudent() {

            _updateStudent.Handle(new UpdateStudentCommand {
                Id = 2,
                FirstName = "Judge",
                LastName = "Dredd"
            });

            return Ok();
        }


        [Route("api/createstudent")]
        [HttpGet]
        public IHttpActionResult CreateStudent() {

            _createStudent.Handle(new CreateStudentCommand {
                FirstName = "Check",
                LastName = "This"
            });

            return Ok();
        }


        [Route("api/deletestudent/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> DeleteStudent(int id) {

            await _deleteStudent.Handle(new DeleteStudentCommand { Id = id });
            return Ok();
        }

    }
}