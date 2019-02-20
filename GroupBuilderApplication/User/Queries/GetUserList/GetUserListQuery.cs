using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderDomain;

namespace GroupBuilderApplication.Queries.GetUserList
{
    public class GetUserListQuery : IGetUserListQuery
    {
        private IUserRepository _repository;
        private IMapper _mapper;

        public GetUserListQuery(IUserRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public List<UserListItem> Execute()
        {
            var users = _repository.GetAll().ToList();
            return _mapper.Map<List<UserListItem>>(users);

        }
    }
}
