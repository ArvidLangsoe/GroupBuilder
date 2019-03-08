using AutoMapper;
using GroupBuilderApplication.Shared;
using GroupBuilderApplication.Commands.AddParticipant;
using GroupBuilderApplication.Commands.CreateRoom;
using GroupBuilderApplication.Commands.CreateUser;
using GroupBuilderApplication.Queries.GetRoomDetails;
using GroupBuilderApplication.Queries.GetRoomList;
using GroupBuilderApplication.Queries.GetSingleUser;
using GroupBuilderApplication.Queries.GetUserList;
using GroupBuilderDomain;
using GroupBuilderApplication.Commands.CreateGroup;
using GroupBuilderApplication.Queries.GetGroupDetails;

namespace GroupBuilder
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserModel, User>();
            CreateMap<User, UserSimpleModel>();
            CreateMap<User, UserDetailItem>();

            CreateMap<CreateRoomModel, Room>();
            CreateMap<Room, RoomSimpleModel>().AfterMap((r, rsm) =>
            {
                rsm.NumberOfGroups = r.Groups.Count;
                rsm.NumberOfParticipants = r.Participants.Count;
            });
            CreateMap<Room, RoomDetailModel>();
            CreateMap<Participant, User>();
            CreateMap<RoomParticipant, ParticipantModel>();
            CreateMap<RoomParticipant, RoomModel>();

            CreateMap<CreateGroupModel, Group>();
            CreateMap<Group, GroupSimpleModel>().AfterMap((g, gsm) =>
            {
                gsm.NumberOfMembers = g.Members.Count;
            });
            CreateMap<Group, GroupDetailModel>();
            CreateMap<GroupMember, MemberModel>();
            CreateMap<GroupMember, GroupModel>();


        }
    }
}