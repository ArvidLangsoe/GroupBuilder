using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderDomain;
using GroupBuilderPersistence.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderPersistence
{
    public class RoomRepository : Repository<Room>,IRoomRepository 
    {
        public RoomRepository(DatabaseContext database) : base(database) { }
    }
}
