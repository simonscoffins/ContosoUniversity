using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using DTOs;
using Repository;

namespace BusinessServices.Students {

    public class GetAllStudentsQuery : IQuery<IEnumerable<StudentDto>> { }

    public class GetAllStudentsQueryHandler : IAsyncQueryHandler<GetAllStudentsQuery, IEnumerable<StudentDto>> {

        private readonly IUnitOfWork _uow;


        public GetAllStudentsQueryHandler(IUnitOfWork uow) {
            _uow = uow;
        }


        public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsQuery query) {

            var students = await _uow.Set<Student>().Select(s => new StudentDto {
                Id = s.Id,
                FirstName = s.FirstMidName,
                LastName = s.LastName
            }).ToListAsync();

            return students;
        }
    }
}