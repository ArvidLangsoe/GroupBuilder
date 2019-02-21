using GroupBuilderApplication.Queries.GetRoomList;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.CreateRoom
{
    public interface ICreateRoomCommand
    {
        RoomSimpleModel Execute(CreateRoomModel model);
    }
}
