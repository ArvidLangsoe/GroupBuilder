using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderDomain;

namespace GroupBuilderApplication.Queries.GetUserList
{
    public class GetUserListQuery : IGetUserListQuery
    {
        private IUserRepository _repository;

        public GetUserListQuery(IUserRepository repository) {
            _repository = repository;
        }

        public List<UserListItem> Execute()
        {
            var users = _repository.GetAll().Select(user => new UserListItem()
            {
                Id = user.Id,
                StudentId = user.StudentId
            });

            return users.ToList();

        }
    }
}
