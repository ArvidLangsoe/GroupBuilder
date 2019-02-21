using GroupBuilderDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Interfaces.Persistence
{
    public interface IRoomRepository : IRepository<Room>
    {
        bool IsRoomCodeUnique(string roomCode);
    }
}
