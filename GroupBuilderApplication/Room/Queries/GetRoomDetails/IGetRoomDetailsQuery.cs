using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Queries.GetRoomDetails
{
    public interface IGetRoomDetailsQuery
    {
        RoomDetailModel Execute(int id);
    }
}
