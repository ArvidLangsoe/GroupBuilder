using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderApplication.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.RemoveParticipant
{
    public class RemoveParticipantCommand : IRemoveParticipantCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RemoveParticipantCommand(IRoomRepository roomRepository, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public void Execute(Participant participant, int roomId)
        {
            var room = _roomRepository.Get(roomId);
            room.Participants.RemoveAll(rp => rp.UserId == participant.Id);
            _unitOfWork.Save();
        }
    }
}
