using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.AddParticipant
{
    public class AddParticipantCommand : IAddParticipantCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddParticipantCommand(IRoomRepository roomRepository, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public void Execute(Participant participant, int roomId)
        {

            var user = _userRepository.Get(participant.Id);
            var room = _roomRepository.Get(roomId);

            error participants are not added correctly probably need many to many relation.
            room.Participants.Add(user);
            _unitOfWork.Save();

        }
    }
}
