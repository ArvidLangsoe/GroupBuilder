using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderDomain;
using System;
using System.Collections.Generic;
using System.Linq;
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

            if (room.Participants.Any(p => p.UserId == user.Id)) {
                throw new ArgumentException("This user is already participating in this room.");
            }

            room.Participants.Add(new RoomParticipant { Room = room, User = user });
            _unitOfWork.Save();

        }
    }
}
