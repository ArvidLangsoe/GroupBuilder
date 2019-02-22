using GroupBuilderApplication.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.CreateGroup
{
    public interface ICreateGroupCommand
    {
        GroupSimpleModel Execute(CreateGroupModel createGroupModel);
    }
}
