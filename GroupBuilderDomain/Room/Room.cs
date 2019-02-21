using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderDomain
{
    public class Room : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ISet<User> Participants { get; set; }

        public ISet<Group> Groups { get; set; }

    }
}
