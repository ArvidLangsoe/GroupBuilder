using AutoMapper;
using GroupBuilderApplication.Shared;
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

        public RoomSimpleModel Execute(Participant participant, int roomId)
        {
            var room = _roomRepository.Get(roomId);
            if (room == null) {
                throw new ArgumentException("No room exists with that Id.");
            }
            return AddParticipant(participant, room);
        }

        public RoomSimpleModel Execute(Participant participant, string roomCode) {
            var room = _roomRepository.GetAll().SingleOrDefault(x => x.RoomCode.Equals(roomCode));
            if (room == null)
            {
                throw new ArgumentException("No room exists with that roomcode.");
            }

            return AddParticipant(participant, room);
        }

        private RoomSimpleModel AddParticipant(Participant participant, Room room) {
            var user = _userRepository.Get(participant.Id);
            
            if (room.Participants.Any(p => p.UserId == user.Id))
            {
                throw new ArgumentException("This user is already participating in this room.");
            }

            room.Participants.Add(new RoomParticipant { Room = room, User = user });
            _unitOfWork.Save();


            return _mapper.Map<RoomSimpleModel>(room);
        }
    }
}
