using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GroupBuilderDomain
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        public string Name { get; set; }

        public List<RoomParticipant> Rooms { get; set; }

        public ICollection<GroupMember> Groups { get; set; }

        public string StudentId { get; set; }
        public string PasswordHash { get; set; }
    }


}
