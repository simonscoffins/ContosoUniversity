using System.Collections.Generic;
using System.Web.Http;
using BusinessServices;
using BusinessServices.Queries;
using DTOs;

namespace Web.Api {

    public class StudentsQueryController : ApiController {

        // queries
        private readonly IQueryHandler<GetAllStudentsQuery, IEnumerable<StudentDto>> _getAllStudents;
        private readonly IQueryHandler<GetStudentByIdQuery, StudentDto> _getStudentById;
        private readonly IQueryHandler<FindStudentsByNameQuery, IEnumerable<StudentDto>> _findStudentsByName;
        private readonly IQueryHandler<FindStudentsByEnrollmentYearQuery, IEnumerable<StudentDto>> _findStudentsByYear;


        public StudentsQueryController(

            IQueryHandler<GetStudentByIdQuery, StudentDto> getStudentById,
            IQueryHandler<GetAllStudentsQuery, IEnumerable<StudentDto>> getAllStudents,
            IQueryHandler<FindStudentsByNameQuery, IEnumerable<StudentDto>> findStudentByName,
            IQueryHandler<FindStudentsByEnrollmentYearQuery, IEnumerable<StudentDto>> findStudentsByYear) {

            _getStudentById = getStudentById;
            _getAllStudents = getAllStudents;
            _findStudentsByName = findStudentByName;
            _findStudentsByYear = findStudentsByYear;

        }


        [Route("api/students/{id}")]
        [HttpGet]
        public IHttpActionResult GetById(int id) {

            // how to handle with no parameters
            var student = _getStudentById.Handle(new GetStudentByIdQuery { Id = id });

            return Ok(student);
        }


        [Route("api/students")]
        [HttpGet]
        public IHttpActionResult Get() {

            // how to handle with no parameters
            var students = _getAllStudents.Handle(new GetAllStudentsQuery());

            return Ok(students);
        }


        [Route("api/students/name/{name}")]
        [HttpGet]
        public IHttpActionResult FindByName(string name) {

            // how to handle with no parameters
            var student = _findStudentsByName.Handle(new FindStudentsByNameQuery {
                Name = name
            });
            return Ok(student);
        }


        [Route("api/students/year/{year}")]
        [HttpGet]
        public IHttpActionResult FindByYear(int year) {

            // how to handle with no parameters
            var students = _findStudentsByYear.Handle(new FindStudentsByEnrollmentYearQuery {
                EnrollmentYear = year
            });
            return Ok(students);
        }

    }
}