using GroupBuilderApplication.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.AddGroupMember
{
    public interface IAddGroupMemberCommand
    {
        void Execute(int groupId, Member newMember);
    }
}
