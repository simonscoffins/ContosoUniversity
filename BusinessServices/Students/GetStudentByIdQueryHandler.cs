using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BusinessServices.CQS;
using DomainModel;
using DTOs;
using Repository;

namespace BusinessServices.Students {

    public class GetStudentByIdQuery : IQuery<StudentDto> {

        public int Id { get; set; }
    }

    public class GetStudentByIdQueryHandler : IAsyncQueryHandler<GetStudentByIdQuery, StudentDto> {

        private readonly IUnitOfWork _uow;


        public GetStudentByIdQueryHandler(IUnitOfWork uow) {
            _uow = uow;
        }


        public async Task<StudentDto> Handle(GetStudentByIdQuery query) {

            var student = await _uow.Set<Student>().FirstAsync(s => s.Id == query.Id);

            return new StudentDto {
                Id = student.Id,
                //FirstName = student.FirstMidName,
                LastName = student.LastName
            };
        }
    }
}