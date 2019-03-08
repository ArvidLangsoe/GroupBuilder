using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderApplication.Queries.GetSingleUser;
using GroupBuilderApplication.Queries.GetUserList;

using static BCrypt.Net.BCrypt;

namespace GroupBuilderApplication.Commands.LoginUser
{
    public class LoginUserCommand : ILoginUserCommand
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public LoginUserCommand(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserDetailItem Execute(LoginUserModel loginModel)
        {
            var matchingUser =_repository.GetAll().SingleOrDefault(x => x.Email.Equals(loginModel.Email));

            if (matchingUser == null) {
                throw new ArgumentException("Ivalid Email");
            }

            bool passwordIsValid = Verify(loginModel.Password, matchingUser.PasswordHash);

            if (!passwordIsValid) {
                throw new ArgumentException("Wrong Password");
            }

            return _mapper.Map<UserDetailItem>(matchingUser);
        }
    }
}
