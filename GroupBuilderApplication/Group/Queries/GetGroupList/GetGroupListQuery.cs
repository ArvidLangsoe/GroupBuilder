using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderApplication.Shared;
using Microsoft.EntityFrameworkCore;

namespace GroupBuilderApplication.Queries
{
    public class GetGroupListQuery : IGetGroupListQuery
    {

        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;

        public GetGroupListQuery(IRoomRepository roomRepository, IUnitOfWork unitOfWork, IMapper mapper, IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public List<GroupSimpleModel> Execute()
        {
            return _mapper.Map<List<GroupSimpleModel>>( _groupRepository.GetAll().ToList());
        }
    }
}
