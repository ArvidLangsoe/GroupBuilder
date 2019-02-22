
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderApplication.Shared;

namespace GroupBuilderApplication.Commands.RemoveGroupMember
{
    public class RemoveGroupMemberCommand : IRemoveGroupMemberCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroupRepository _groupRepository;

        public RemoveGroupMemberCommand(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
        }

        public void Execute(int groupId, Member groupMember)
        {
            var group = _groupRepository.Get(groupId);
            group.Members.RemoveAll(gm => gm.UserId == groupMember.UserId);
            _unitOfWork.Save();
        }
    }
}
