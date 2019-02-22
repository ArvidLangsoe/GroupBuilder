
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GroupBuilderDomain
{
    public class Group : IEntity
    {
        public Group() {
            Members = new List<GroupMember>();
        }

        [Key]
        public int Id { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public ICollection<GroupMember> Members { get; set; }
    }
}
