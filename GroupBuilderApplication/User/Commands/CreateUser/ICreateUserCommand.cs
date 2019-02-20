using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        void Execute(CreateUserModel model);
    }
}
