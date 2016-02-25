using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using BusinessServices;
using BusinessServices.Students;
using DTOs;

namespace Web.Api {

    public class StudentsQueryProcessorController : ApiController {

        // queries
        private readonly IQueryProcessor _queryProcessor;

        public StudentsQueryProcessorController(IQueryProcessor queryProcessor) {
            _queryProcessor = queryProcessor;
        }


        [Route("api/students/{id}")]
        [HttpGet]
        public IHttpActionResult GetById(int id) {

            var query = new GetStudentByIdQuery { Id = id };
            var student = _queryProcessor.Process(query);
            return Ok(student);
        }


        [Route("api/students")]
        [HttpGet]
        public async Task<IHttpActionResult> Get() {

            // how to handle with no parameters
            var query = new GetAllStudentsQuery();
            var students = await _queryProcessor.ProcessAsync(query);
            return Ok(students);
        }


        [Route("api/students/name/{name}")]
        [HttpGet]
        public IHttpActionResult FindByName(string name) {

            var query = new FindStudentsByNameQuery { Name = name };
            var students = _queryProcessor.Process(query);
            return Ok(students);
        }


        [Route("api/students/year/{year}")]
        [HttpGet]
        public IHttpActionResult FindByYear(int year) {

            var query = new FindStudentsByEnrollmentYearQuery { EnrollmentYear = year };
            var students = _queryProcessor.Process(query);
            return Ok(students);
        }

    }
}