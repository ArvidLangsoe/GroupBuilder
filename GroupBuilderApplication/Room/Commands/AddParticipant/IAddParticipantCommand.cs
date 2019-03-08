using System;
using System.Collections.Generic;
using System.Text;
using GroupBuilderApplication.Shared;

namespace GroupBuilderApplication.Commands.AddParticipant
{
    public interface IAddParticipantCommand
    {
        RoomSimpleModel Execute(Participant participant, int roomId);
        RoomSimpleModel Execute(Participant participant, string roomCode);
    }
}
