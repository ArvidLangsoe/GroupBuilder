using GroupBuilderApplication.Queries.GetUserList;
using GroupBuilderDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Shared
{
    public class ParticipantModel
    {
        public UserSimpleModel User { get; set; }
        DateTime DateJoined { get; set; }
    }
}
