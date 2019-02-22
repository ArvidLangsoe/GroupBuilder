using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;

namespace GroupBuilderApplication.Queries.GetGroupDetails
{
    public class GetGroupDetailsQuery : IGetGroupDetailsQuery
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;

        public GetGroupDetailsQuery(IRoomRepository roomRepository, IUnitOfWork unitOfWork, IMapper mapper, IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public GroupDetailModel Execute(int groupId)
        {
            var group = _groupRepository.Get(groupId);
            return _mapper.Map<GroupDetailModel>(group);

        }
    }
}
