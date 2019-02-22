using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderDomain;
using GroupBuilderPersistence.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderPersistence
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(DatabaseContext database) : base(database) { }
    }
}
