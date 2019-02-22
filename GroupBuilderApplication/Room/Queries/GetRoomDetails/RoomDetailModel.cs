using GroupBuilderApplication.Queries.GetUserList;
using GroupBuilderApplication.Shared;
using GroupBuilderDomain;
using System.Collections.Generic;

namespace GroupBuilderApplication.Queries.GetRoomDetails
{
    public class RoomDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomCode { get; set; }

        public List<ParticipantModel> Participants { get; set; }

        public List<GroupSimpleModel> Groups { get; set; }
    }
}