using System.Linq;
using DTOs;
using Model;
using Repository;

namespace BusinessServices.Students {

    public class GetStudentByIdQuery : IQuery<StudentDto> {

        public int Id { get; set; }
    }

    public class GetStudentByIdQueryHandler : IQueryHandler<GetStudentByIdQuery, StudentDto> {

        private readonly IUnitOfWork _uow;


        public GetStudentByIdQueryHandler(IUnitOfWork uow) {
            _uow = uow;
        }


        public StudentDto Handle(GetStudentByIdQuery query) {

            var student = _uow.Set<Student>().First(s => s.Id == query.Id);

            return new StudentDto {
                Id = student.Id,
                FirstName = student.FirstMidName,
                LastName = student.LastName
            };
        }
    }
}