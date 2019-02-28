using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Toolbelt.ComponentModel.DataAnnotations.Schema;

namespace GroupBuilderDomain
{

    public class Room : IEntity
    {
        public Room() {
            Participants = new List<RoomParticipant>();
            Groups = new List<Group>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomCode { get; set; }

        public List<RoomParticipant> Participants { get; set; }

        public List<Group> Groups { get; set; }

    }
}
