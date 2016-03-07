using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BusinessServices.CQS;
using DomainModel;
using DTOs;
using Repository;

namespace BusinessServices.Students {

    public class FindStudentsByNameQuery : IQuery<IEnumerable<StudentDto>> {

        public string Name { get; set; }
    }


    public class FindStudentsByNameQueryHandler : IAsyncQueryHandler<FindStudentsByNameQuery, IEnumerable<StudentDto>> {

        private readonly IUnitOfWork _uow;


        public FindStudentsByNameQueryHandler(IUnitOfWork uow) {
            _uow = uow;
        }


        public async Task<IEnumerable<StudentDto>> Handle(FindStudentsByNameQuery query) {

            var students = await _uow.Set<Student>()
                .Where(s => s.FirstMidName.Contains(query.Name) || s.LastName.Contains(query.Name))
                .Select(s => new StudentDto {
                  
                    Id = s.Id,
                    //FirstName = s.FirstMidName,
                    LastName = s.LastName
                }).ToListAsync();

            return students;
        }
    }
}