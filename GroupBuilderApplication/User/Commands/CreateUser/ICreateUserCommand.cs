using GroupBuilderApplication.Queries.GetUserList;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
         UserSimpleModel Execute(CreateUserModel model);
    }
}
