using System.Collections.Generic;
using System.Linq;
using DTOs;
using Model;
using Repository;

namespace BusinessServices.Students {

    public class FindStudentsByNameQuery : IQuery<IEnumerable<StudentDto>> {

        public string Name { get; set; }
    }


    public class FindStudentsByNameQueryHandler : IQueryHandler<FindStudentsByNameQuery, IEnumerable<StudentDto>> {

        private readonly IUnitOfWork _uow;


        public FindStudentsByNameQueryHandler(IUnitOfWork uow) {
            _uow = uow;
        }


        public IEnumerable<StudentDto> Handle(FindStudentsByNameQuery query) {

            var students = _uow.Set<Student>()
                .Where(s => s.FirstMidName.Contains(query.Name) || s.LastName.Contains(query.Name))
                .Select(s => new StudentDto {
                    Id = s.Id,
                    FirstName = s.FirstMidName,
                    LastName = s.LastName
                })
                .ToList();

            return students;
        }
    }
}