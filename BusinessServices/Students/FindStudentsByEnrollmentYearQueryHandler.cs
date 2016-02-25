using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel;
using DTOs;
using Repository;

namespace BusinessServices.Students {

    public class FindStudentsByEnrollmentYearQuery : IQuery<IEnumerable<StudentDto>> {

        public int EnrollmentYear { get; set; }
    }


    public class FindStudentsByEnrollmentYearQueryHandler : IQueryHandler<FindStudentsByEnrollmentYearQuery, IEnumerable<StudentDto>> {

        private readonly IUnitOfWork _uow;


        public FindStudentsByEnrollmentYearQueryHandler(IUnitOfWork uow) {
            _uow = uow;
        }

        public IEnumerable<StudentDto> Handle(FindStudentsByEnrollmentYearQuery query) {

            var startDateRange = new DateTime(query.EnrollmentYear, 01, 01, 00, 00, 00);
            var endDateRange = new DateTime(query.EnrollmentYear, 12, 31, 23, 59, 59);

            var students =
                _uow.Set<Student>()
                .Where(s => s.EnrollmentDate >= startDateRange && s.EnrollmentDate <= endDateRange)
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