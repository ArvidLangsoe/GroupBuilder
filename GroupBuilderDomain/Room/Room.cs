using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Toolbelt.ComponentModel.DataAnnotations.Schema;

namespace GroupBuilderDomain
{
    public class Room : IEntity
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomCode { get; set; }

        public ISet<User> Participants { get; set; }

        public ISet<Group> Groups { get; set; }

    }
}
