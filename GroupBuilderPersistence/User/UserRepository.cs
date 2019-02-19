using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderDomain;
using GroupBuilderPersistence.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderPersistence
{
    class UserRepository : Repository<User>,IUserRepository
    {
        public UserRepository(DatabaseContext database) : base(database) { }
    }
}
