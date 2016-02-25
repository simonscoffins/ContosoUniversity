using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using MediatR;
using Repository;

namespace BusinessServices.Departments {

    public class GetAllDepartmentsQuery : IAsyncRequest<IEnumerable<DepartmentDto>> { }


    public class GetAllDepartmentsQueryHandler : IAsyncRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmentDto>> {

        private readonly IUnitOfWork _uow;

        public GetAllDepartmentsQueryHandler(IUnitOfWork uow) {
            _uow = uow;
        }

        public async Task<IEnumerable<DepartmentDto>> Handle(GetAllDepartmentsQuery message) {

            return await _uow.Set<Department>().Select(d => new DepartmentDto {
                Id = d.Id,
                Name = d.Name,
                Budget = d.Budget,
                Administrator = d.Administrator.FirstMidName + " " + d.Administrator.LastName
            }).ToListAsync();
        }
    }
}