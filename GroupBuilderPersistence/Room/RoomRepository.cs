using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderDomain;
using GroupBuilderPersistence.Shared;
using Microsoft.EntityFrameworkCore;
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

        public new Room Get(int id)
        {
            return _database.Rooms.Include(r => r.Participants).ThenInclude(rp => rp.User).Include(r => r.Groups)
                .SingleOrDefault(p => p.Id == id);
        }

    }
}
