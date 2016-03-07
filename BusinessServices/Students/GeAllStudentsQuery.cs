using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using BusinessServices.CQS;
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

            // todo: inject into class
            var mc = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDto>();
            });

            var students = await _uow.Set<Student>().ProjectToListAsync<StudentDto>(mc);
            return students;
        }
    }
}