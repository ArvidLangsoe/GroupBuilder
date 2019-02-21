using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Queries.GetRoomList
{
    public interface IGetRoomListQuery
    {
        List<RoomSimpleModel> Execute();
    }
}
