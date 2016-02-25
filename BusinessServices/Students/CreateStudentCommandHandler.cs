﻿using System;
using System.Threading.Tasks;
using BusinessServices.CQS.Commands;
using DomainModel;
using Repository;

namespace BusinessServices.Students {

    public class CreateStudentCommand {

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    public class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand> {

        private readonly IUnitOfWork _uow;

        public CreateStudentCommandHandler(IUnitOfWork uow) {
            _uow = uow;
        }

        public void Handle(CreateStudentCommand command) {

            var student = new Student {
                FirstMidName = command.FirstName,
                LastName = command.LastName,
                EnrollmentDate = DateTime.Now
            };

            _uow.Set<Student>().Add(student);

            var task = _uow.SaveChangesAsync();
            task.Wait();
        }
    }
}