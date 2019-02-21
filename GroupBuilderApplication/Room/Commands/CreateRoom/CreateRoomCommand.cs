using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.CreateRoom
{
    public class CreateRoomCommand : ICreateRoomCommand
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRoomCommand(IRoomRepository roomRepository, IUnitOfWork unitOfWork, IMapper mapper) {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Execute(CreateRoomModel model)
        {
            var room=_mapper.Map<Room>(model);
            _roomRepository.Add(room);
            _unitOfWork.Save();
        }
    }
}
