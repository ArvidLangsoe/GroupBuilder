using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.RemoveGroup
{
    public interface IRemoveGroupCommand
    {
        void Execute(int groupId);
    }
}
