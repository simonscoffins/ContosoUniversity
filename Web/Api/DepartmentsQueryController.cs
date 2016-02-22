using System.Threading.Tasks;
using System.Web.Http;
using BusinessServices.Departments;
using MediatR;

namespace Web.Api {

    public class DepartmentsQueryController : ApiController {

        private readonly IMediator _mediator;

        public DepartmentsQueryController(IMediator mediator) {
            _mediator = mediator;
        }


        [Route("api/departments")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll () {

            var depts = await _mediator.SendAsync(new GetAllDepartmentsQuery());
            return Ok(depts);
        }


        [Route("api/departments/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetById (int id) {

            var dept = await _mediator.SendAsync(new GetDepartmentByIdQuery {
                Id = id
            });

            return Ok(dept);
        }
    }
}