using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.RemoveUser
{
    public interface IRemoveUserCommand
    {
        void Execute(int userId);
    }
}
