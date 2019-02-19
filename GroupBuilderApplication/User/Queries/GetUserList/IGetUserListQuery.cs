using GroupBuilderDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Queries.GetUserList
{
    public interface IGetUserListQuery
    {
        List<UserListItem> Execute();
    }
}
