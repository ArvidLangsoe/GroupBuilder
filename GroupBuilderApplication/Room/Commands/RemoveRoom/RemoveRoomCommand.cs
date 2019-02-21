using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.RemoveRoom
{

    public class RemoveRoomCommand : IRemoveRoomCommand
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RemoveRoomCommand(IRoomRepository roomRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Exceute(int id)
        {
            _roomRepository.Remove(_roomRepository.Get(id));
            _unitOfWork.Save();
        }
    }
}
