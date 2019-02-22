using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderApplication.Shared;
using GroupBuilderDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.CreateGroup
{
    public class CreateGroupCommand : ICreateGroupCommand
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;

        public CreateGroupCommand(IRoomRepository roomRepository, IUnitOfWork unitOfWork, IMapper mapper, IGroupRepository groupRepository)
        {
            _roomRepository = roomRepository;
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public GroupSimpleModel Execute(CreateGroupModel createGroupModel)
        {
            var group = _mapper.Map<Group>(createGroupModel);
            _groupRepository.Add(group);
            _unitOfWork.Save();
            var room = _roomRepository.Get(group.RoomId);
            room.Groups.Add(group);
            _unitOfWork.Save();
            
            return _mapper.Map<GroupSimpleModel>(group);
        }
    }
}
