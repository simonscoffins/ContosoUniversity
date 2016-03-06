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

            var mc = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDto>();
                
            });

            //var students = await _uow.Set<Student>()
            //    .Select(s => new {s.Id, s.FirstMidName, s.LastName })
            //    .ToListAsync();

            // what gets sent to the db?
            var z = _uow.Set<Student>().ProjectToList<StudentDto>(mc);


            var y = await _uow.Set<Student>()
                .Select(s => new {s.Id, s.FirstMidName, s.LastName})
                .ProjectToListAsync<StudentDto>(mc);
            

//            var x = await _uow.Set<Student>().ProjectToListAsync<StudentDto>(mc);

            return y;

            //return Mapper.Map<List<StudentDto>>(students);


            //var config = new MapperConfiguration()


            //var ctx = new ContosoUniversityContext();

            //var y = ctx.Students.ProjectTo()


            //    .Select(s => new StudentDto {
            //    Id = s.Id,
            //    FirstName = s.FirstMidName,
            //    LastName = s.LastName
            //}).ToListAsync();



//            return dto;
        }
    }
}