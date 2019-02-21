using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderApplication.Queries.GetUserList;
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

        public UserSimpleModel Execute(CreateUserModel model)
        {
            var user = _mapper.Map<User>(model);

            _repository.Add(user);

            _unitOfWork.Save();

            return _mapper.Map<UserSimpleModel>(user);
        }
    }
}
