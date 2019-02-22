
using GroupBuilderApplication.Queries.GetUserList;
using GroupBuilderApplication.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Queries.GetGroupDetails
{
    public class GroupDetailModel
    {
        public int Id { get; set; }
        public RoomSimpleModel Room { get; set; }

        public ICollection<MemberModel> Members { get; set; }
    }
}
