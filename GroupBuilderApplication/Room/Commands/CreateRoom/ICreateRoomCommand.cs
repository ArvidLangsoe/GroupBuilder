using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.CreateRoom
{
    public interface ICreateRoomCommand
    {
        void Execute(CreateRoomModel model);
    }
}
