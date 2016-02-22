using System.Web.Http;
using BusinessServices;
using BusinessServices.Students;

namespace Web.Api {

    public class StudentsCommandController : ApiController {

        // commands
        private readonly ICommandHandler<UpdateStudentCommand> _updateStudent;
        private readonly ICommandHandler<CreateStudentCommand> _createStudent;
        private readonly ICommandHandler<DeleteStudentCommand> _deleteStudent;

        public StudentsCommandController (

            ICommandHandler<UpdateStudentCommand> updateStudent,
            ICommandHandler<CreateStudentCommand> createStudent,
            ICommandHandler<DeleteStudentCommand> deleteStudent) {

            _updateStudent = updateStudent;
            _createStudent = createStudent;
            _deleteStudent = deleteStudent;

        }



        [Route("api/updatestudent")]
        [HttpGet]
        public IHttpActionResult UpdateStudent () {

            _updateStudent.Handle(new UpdateStudentCommand {
                Id = 2,
                FirstName = "Judge",
                LastName = "Dredd"
            });

            return Ok();
        }


        [Route("api/createstudent")]
        [HttpGet]
        public IHttpActionResult CreateStudent () {

            _createStudent.Handle(new CreateStudentCommand {
                FirstName = "Check",
                LastName = "This"
            });

            return Ok();
        }


        [Route("api/deletestudent")]
        [HttpGet]
        public IHttpActionResult DeleteStudent () {

            _deleteStudent.Handle(new DeleteStudentCommand {
                Id = 2
            });

            return Ok();
        }

    }
}