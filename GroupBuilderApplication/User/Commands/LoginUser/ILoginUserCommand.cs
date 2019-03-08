using GroupBuilderApplication.Queries.GetSingleUser;
using GroupBuilderApplication.Queries.GetUserList;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.LoginUser
{
    public interface ILoginUserCommand
    {
        UserDetailItem Execute(LoginUserModel loginModel);
    }
}
