using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderApplication.Queries.GetUserList;
using GroupBuilderApplication.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Queries.GetRoomDetails
{
    public class GetRoomDetailsQuery : IGetRoomDetailsQuery
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public GetRoomDetailsQuery(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }
        public RoomDetailModel Execute(int id)
        {
            var room = _roomRepository.Get(id);
            return _mapper.Map<RoomDetailModel>(room);
            /*
            var participants = _mapper.Map<List<UserSimpleModel>>(room.Participants);
            var groups = _mapper.Map<List<GroupSimpleModel>>(room.Groups);

            return new RoomDetailModel()
            {
                Id = room.Id,
                Name = room.Name,
                RoomCode = room.RoomCode,
                Participants = participants,
                Groups = groups
            };
            */
        }
    }
}
