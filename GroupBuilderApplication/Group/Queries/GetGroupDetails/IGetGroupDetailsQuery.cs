using GroupBuilderApplication.Queries.GetGroupDetails;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Queries.GetGroupDetails
{
    public interface IGetGroupDetailsQuery
    {
        GroupDetailModel Execute(int groupId);
    }
}
