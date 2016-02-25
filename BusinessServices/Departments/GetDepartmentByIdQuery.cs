using System.Data.Entity;
using System.Threading.Tasks;
using DomainModel;
using MediatR;
using Repository;

namespace BusinessServices.Departments {

    public class GetDepartmentByIdQuery : IAsyncRequest<DepartmentDto> {

        public int Id { get; set; }
    }


    public class GetDepartmentByIdQueryHandler : IAsyncRequestHandler<GetDepartmentByIdQuery, DepartmentDto> {

        private readonly IUnitOfWork _uow;

        public GetDepartmentByIdQueryHandler(IUnitOfWork uow) {
            _uow = uow;
        }

        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery query) {

            var dept = await _uow.Set<Department>().FirstAsync(d => d.Id == query.Id);

            return new DepartmentDto {
                Id = dept.Id,
                Name = dept.Name,
                Budget = dept.Budget,
                Administrator = dept.Administrator.FullName
            };
        }
    }

}