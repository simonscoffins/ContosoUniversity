using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI;
using BusinessServices;
using BusinessServices.CQS;
using BusinessServices.Students;

namespace Web.Api {

    public class StudentsCommandController : ApiController {

        // commands
        private readonly IAsyncCommandHandler<UpdateStudentCommand> _updateStudent;
        private readonly IAsyncCommandHandler<CreateStudentCommand> _createStudent;
        private readonly IAsyncCommandHandler<DeleteStudentCommand> _deleteStudent;

        public StudentsCommandController(

            IAsyncCommandHandler<UpdateStudentCommand> updateStudent,
            IAsyncCommandHandler<CreateStudentCommand> createStudent,
            IAsyncCommandHandler<DeleteStudentCommand> deleteStudent) {

            _updateStudent = updateStudent;
            _createStudent = createStudent;
            _deleteStudent = deleteStudent;
        }



        [Route("api/updatestudent")]
        [HttpGet]
        public async Task<IHttpActionResult> UpdateStudent() {

            await _updateStudent.Handle(new UpdateStudentCommand {
                Id = 2,
                FirstName = "Judge",
                LastName = "Dredd"
            });

            return Ok();
        }


        [Route("api/createstudent")]
        [HttpGet]
        public async Task<IHttpActionResult> CreateStudent() {

            var command = new CreateStudentCommand {
                FirstName = "Check",
                LastName = "This"
            };

            await _createStudent.Handle(command);

            // retunr the new student id from the command
            return Ok(command.Id);
        }


        [Route("api/deletestudent/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> DeleteStudent(int id) {

            await _deleteStudent.Handle(new DeleteStudentCommand { Id = id });
            return Ok();
        }

    }
}