using AutoMapper;
using GroupBuilderApplication.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupBuilderApplication.Queries.GetRoomList
{
    public class GetRoomListQuery : IGetRoomListQuery
    {

        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public GetRoomListQuery(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }
        public List<RoomSimpleModel> Execute()
        {
            return _mapper.Map<List<RoomSimpleModel>>(_roomRepository.GetAll().ToList());
        }
    }
}
