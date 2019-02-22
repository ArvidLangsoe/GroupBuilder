using GroupBuilderApplication.Queries.GetRoomList;
using System;
using System.Collections.Generic;
using System.Text;
using GroupBuilderApplication.Shared;

namespace GroupBuilderApplication.Commands.CreateRoom
{
    public interface ICreateRoomCommand
    {
        RoomSimpleModel Execute(CreateRoomModel model);
    }
}
