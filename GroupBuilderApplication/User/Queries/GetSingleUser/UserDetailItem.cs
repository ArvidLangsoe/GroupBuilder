
using GroupBuilderApplication.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Queries.GetSingleUser
{
    public class UserDetailItem
    {

        public int Id { get; set; }
        public string StudentId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<RoomModel> Rooms { get; set; }


        public ICollection<GroupModel> Groups { get; set; }
    }
}
