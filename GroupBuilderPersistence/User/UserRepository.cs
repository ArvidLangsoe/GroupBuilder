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
    public class UserRepository : Repository<User>,IUserRepository
    {
        public UserRepository(DatabaseContext database) : base(database) { }


        public new User Get(int id)
        {
            return _database.Users
                .Include(u => u.Groups).ThenInclude(gm => gm.Group).ThenInclude(g=> g.Members)
                .Include(u => u.Rooms).ThenInclude(rp => rp.Room).ThenInclude(r=> r.Participants)
                .Include(u => u.Rooms).ThenInclude(rp => rp.Room).ThenInclude(r => r.Groups)
                .SingleOrDefault(p => p.Id == id);
        }
    }
}
