using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderApplication.Queries.GetUserList;
using GroupBuilderDomain;
using static BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (string.IsNullOrWhiteSpace(model.Password))
                throw new ArgumentException("Password is required");

            if (_repository.GetAll().Any(x => x.Email == model.Email))
                throw new ArgumentException("An account has already been registered with email: \"" + model.Email + "\"");

            var user = _mapper.Map<User>(model);

            user.PasswordHash = HashPassword(model.Password);

            _repository.Add(user);

            _unitOfWork.Save();

            return _mapper.Map<UserSimpleModel>(user);
        }

    }
}
