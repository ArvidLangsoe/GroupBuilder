using System;
using System.Collections.Generic;
using System.Text;
using GroupBuilderApplication.Shared;

namespace GroupBuilderApplication.Commands.AddParticipant
{
    public interface IAddParticipantCommand
    {
        void Execute(Participant participant, int roomId); 
    }
}
