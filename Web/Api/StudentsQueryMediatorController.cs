using System.Threading.Tasks;
using System.Web.Http;
using BusinessServices.CQS;
using BusinessServices.Students;

namespace Web.Api {

    public class StudentsQueryMediatorController : ApiController {

        // queries
        private readonly IQueryMediator _queryMediator;

        public StudentsQueryMediatorController(IQueryMediator queryProcessor) {
            _queryMediator = queryProcessor;
        }


        [Route("api/students/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id) {

            var query = new GetStudentByIdQuery { Id = id };
            var student = await _queryMediator.ExecuteAsync(query);
            return Ok(student);
        }


        [Route("api/students")]
        [HttpGet]
        public async Task<IHttpActionResult> Get() {

            // how to handle with no parameters
            var query = new GetAllStudentsQuery();
            var students = await _queryMediator.ExecuteAsync(query);
            return Ok(students);
        }


        [Route("api/students/name/{name}")]
        [HttpGet]
        public async Task<IHttpActionResult> FindByName(string name) {

            var query = new FindStudentsByNameQuery { Name = name };
            var students = await _queryMediator.ExecuteAsync(query);
            return Ok(students);
        }


        [Route("api/students/year/{year}")]
        [HttpGet]
        public async Task<IHttpActionResult> FindByYear(int year) {

            var query = new FindStudentsByEnrollmentYearQuery { EnrollmentYear = year };
            var students = await _queryMediator.ExecuteAsync(query);
            return Ok(students);
        }

    }
}