using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
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
            return _mapper.Map<RoomDetailModel>(_roomRepository.Get(id));
        }
    }
}
