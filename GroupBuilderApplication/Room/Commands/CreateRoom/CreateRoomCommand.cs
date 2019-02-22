using AutoMapper;
using GroupBuilderApplication.Shared;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderApplication.Queries.GetRoomList;
using GroupBuilderDomain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GroupBuilderApplication.Commands.CreateRoom
{
    public class CreateRoomCommand : ICreateRoomCommand
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRoomCommand(IRoomRepository roomRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public RoomSimpleModel Execute(CreateRoomModel model)
        {
            var room = _mapper.Map<Room>(model);
            _roomRepository.Add(room);
            room.RoomCode = GenerateRoomCode();
            _unitOfWork.Save();

            return _mapper.Map<RoomSimpleModel>(room);
        }


        private string GenerateRoomCode()
        {
            char[] charOptions = {
                'a', 'b', 'c', 'd', 'e','f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm', 'n', 'o','p', 'q', 'r', 's', 't',
                'u', 'v', 'x', 'y', 'z','1', '2', '3', '4', '5',
                '6', '7', '8', '9', '0','!', '&'
            };

            int minLength = 4;
            Random randomizer = new Random();
            StringBuilder codeBuilder = new StringBuilder();
            bool isUnique = false;

            while (!isUnique||codeBuilder.Length<minLength)
            {
                int randomValue = randomizer.Next(charOptions.Length);
                codeBuilder.Append(charOptions[randomValue]);

                if (codeBuilder.Length >= minLength) {
                    isUnique=_roomRepository.IsRoomCodeUnique(codeBuilder.ToString());
                }
            }


            return codeBuilder.ToString();
        }
    }

}
