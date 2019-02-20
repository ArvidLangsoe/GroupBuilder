using AutoMapper;
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

        private readonly IMapper _mapper;

        public CreateUserCommand(IUserRepository repository, IUnitOfWork unitOfWork, IMapper mapper) {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Execute(CreateUserModel model)
        {
            var user = _mapper.Map<User>(model);

            _repository.Add(user);

            _unitOfWork.Save();
        }
    }
}
