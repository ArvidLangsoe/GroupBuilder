using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.AddParticipant
{
    public interface IAddParticipantCommand
    {
        void Execute(Participant participant, int roomId); 
    }
}
