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
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(DatabaseContext database) : base(database) { }

        public new Group Get(int id)
        {
            return _database.Groups.Include(g => g.Room).Include(g=>g.Members).ThenInclude(gm => gm.User)
                .SingleOrDefault(p => p.Id == id);
        }
    }
}
