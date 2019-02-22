using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.RemoveGroup
{
    public class RemoveGroupCommand : IRemoveGroupCommand
    {

        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;

        public RemoveGroupCommand(IRoomRepository roomRepository, IUnitOfWork unitOfWork, IMapper mapper, IGroupRepository groupRepository)
        {
            _roomRepository = roomRepository;
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Execute(int groupId)
        {
            var group = _groupRepository.Get(groupId);
            _groupRepository.Remove(group);
            _unitOfWork.Save();
        }
    }
}
