using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Queries.GetSingleUser
{
    public class GetSingleUserQuery : IGetSingleUserQuery
    {

        private IUserRepository _repository;
        private IMapper _mapper;

        public GetSingleUserQuery(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserDetailItem Execute(int id)
        {
            return _mapper.Map<UserDetailItem>(_repository.Get(id));
        }
    }
}
