using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using GroupBuilderApplication.Commands.RandomizeGroups;
using GroupBuilderApplication.Factory.GroupRandomizer;
using GroupBuilderApplication.Interfaces.Persistence;
using GroupBuilderApplication.Queries.GetGroupDetails;
using GroupBuilderApplication.Shared;
using GroupBuilderDomain;

namespace GroupBuilderApplication.Commands.RandomizeRoom
{

    public class RandomizeRoomCommand : IRandomizeRoomCommand
    {

        private readonly IUserRepository _userRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGroupRandomizerFactory _randomizerFactory;

        public RandomizeRoomCommand(
            IRoomRepository roomRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IUserRepository userRepository, 
            IGroupRandomizerFactory randomizerFactory)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
            _randomizerFactory = randomizerFactory;
        }

        public List<GroupDetailModel> Execute(int roomId, RandomizerModel randomizerModel)
        {
            var room = _roomRepository.Get(roomId);
            var randomizer = _randomizerFactory.CreateRandomizer(randomizerModel);

            IEnumerable<User> userWithGroups = new List<User>();
            if (room.Groups.Count > 0)
            {
                userWithGroups = room.Groups.SelectMany(g => g.Members).Select(gm => gm.User);

            }

            var usersWithNoGroup = room.Participants.Select(p => p.User).Where(u => !userWithGroups.Contains(u));

            List<Group> newGroups =randomizer.GenerateGroups(usersWithNoGroup.ToList());

            newGroups.ForEach(g => room.Groups.Add(g));
            _unitOfWork.Save();

            return _mapper.Map<List<GroupDetailModel>>(newGroups);
        }
    }
}
