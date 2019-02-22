using GroupBuilderApplication.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.RemoveGroupMember
{
    public interface IRemoveGroupMemberCommand
    {
        void Execute(int groupId, Member groupMember);
    }
}
