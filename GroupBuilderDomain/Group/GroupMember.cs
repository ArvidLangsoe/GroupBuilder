using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GroupBuilderDomain
{
    public class GroupMember
    {

        [Key]
        public int UserId { get; set; }
        public User User { get; set; }

        [Key]
        public int GroupId { get; set; }
        public Group Group { get; set; }

    }
}
