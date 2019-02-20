
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderDomain
{
    public class Group : IEntity
    {
        public int Id { get; set; }
        ISet<User> Members { get; set; }
    }
}
