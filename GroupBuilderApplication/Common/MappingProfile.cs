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
            CreateMap<Room, RoomSimpleModel>();
            CreateMap<Room, RoomDetailModel>();
            CreateMap<Participant, User>();
            CreateMap<RoomParticipant, ParticipantModel>();
            CreateMap<RoomParticipant, RoomModel>();

            CreateMap<CreateGroupModel, Group>();
            CreateMap<Group, GroupSimpleModel>();
            CreateMap<Group, GroupDetailModel>();
            CreateMap<GroupMember, MemberModel>();
            CreateMap<GroupMember, GroupModel>();


        }
    }
}