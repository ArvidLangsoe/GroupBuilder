using System;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Queries.GetSingleUser
{
     public interface IGetSingleUserQuery
    {
        UserDetailItem Execute(int id);
    }
}
