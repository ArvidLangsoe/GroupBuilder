﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GroupBuilderDomain
{
    public class Group : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        ISet<User> Members { get; set; }
    }
}
