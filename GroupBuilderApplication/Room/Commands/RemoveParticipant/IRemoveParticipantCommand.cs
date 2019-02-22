using GroupBuilderApplication.Commands;
using GroupBuilderApplication.Commands.AddParticipant;
using GroupBuilderApplication.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.RemoveParticipant
{
    public interface IRemoveParticipantCommand
    {
        void Execute(Participant participant, int roomId);

    }
}
