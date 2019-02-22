using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GroupBuilderDomain
{
    public class RoomParticipant
    {
        public RoomParticipant() {
            DateJoined = DateTime.Now;
        }

        [Key]
        public int UserId { get; set; }
        public User User { get; set; }
        [Key]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Required]
        DateTime DateJoined { get; set; }
    }
}
