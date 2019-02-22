using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderApplication.Shared;
using GroupBuilderDomain;

namespace GroupBuilderApplication.Commands.AddGroupMember
{
    public class AddGroupMemberCommand : IAddGroupMemberCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;

        public AddGroupMemberCommand(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IGroupRepository groupRepository)
        {
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Execute(int groupId, Member newMember)
        {
            var group = _groupRepository.Get(groupId);
            var user = _userRepository.Get(newMember.UserId);
            if (group.Members.Any(m => m.UserId ==user.Id)) {
                throw new ArgumentException("User is already in the group");
            }
            group.Members.Add(new GroupMember() {
                Group = group,
                User = user
            });
            _unitOfWork.Save();
        }
    }
}
