using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.RemoveRoom
{
    public interface IRemoveRoomCommand
    {
        void Exceute(int id);
    }
}
