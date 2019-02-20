using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {

        private readonly IUserRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommand(IUserRepository repository, IUnitOfWork unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Execute(CreateUserModel model)
        {
            var user = new User()
            {
                StudentId = model.StudentId
            };

            _repository.Add(user);

            _unitOfWork.Save();
        }
    }
}
