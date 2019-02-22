using GroupBuilderApplication.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Queries
{
    public interface IGetGroupListQuery
    {
        List<GroupSimpleModel> Execute();
    }
}
