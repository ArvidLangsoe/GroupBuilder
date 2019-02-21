using AutoMapper;
using GroupBuilderApplication.Commands.CreateRoom;
using GroupBuilderApplication.Commands.CreateUser;
using GroupBuilderApplication.Queries.GetSingleUser;
using GroupBuilderApplication.Queries.GetUserList;
using GroupBuilderDomain;

namespace GroupBuilder
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserModel, User>();
            CreateMap<User, UserListItem>();
            CreateMap<User, UserDetailItem>();
            CreateMap<CreateRoomModel, Room>();

        }
    }
}