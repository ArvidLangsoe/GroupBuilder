using AutoMapper;
using GroupBuilderApplication.Commands.CreateUser;
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

        }
    }
}