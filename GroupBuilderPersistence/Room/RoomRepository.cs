using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderDomain;
using GroupBuilderPersistence.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupBuilderPersistence
{
    public class RoomRepository : Repository<Room>,IRoomRepository 
    {
        public RoomRepository(DatabaseContext database) : base(database) { }

        public bool IsRoomCodeUnique(string roomCode)
        {
            return !_database.Rooms.Any(r => r.RoomCode.Equals(roomCode));
        }
    }
}
