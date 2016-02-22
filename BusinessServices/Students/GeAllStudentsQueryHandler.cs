using System.Collections.Generic;
using System.Linq;
using DTOs;
using Model;
using Repository;

namespace BusinessServices.Students {

    public class GetAllStudentsQuery : IQuery<IEnumerable<StudentDto>> { }

    public class GetAllStudentsQueryHandler : IQueryHandler<GetAllStudentsQuery, IEnumerable<StudentDto>> {

        private readonly IUnitOfWork _uow;


        public GetAllStudentsQueryHandler(IUnitOfWork uow) {
            _uow = uow;
        }


        public IEnumerable<StudentDto> Handle(GetAllStudentsQuery query) {

            var students = _uow.Set<Student>().Select(s => new StudentDto {
                Id = s.Id,
                FirstName = s.FirstMidName,
                LastName = s.LastName
            });

            return students;
        }
    }
}