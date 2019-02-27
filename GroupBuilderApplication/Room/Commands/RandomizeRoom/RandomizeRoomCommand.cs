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
        private readonly IGroupRepository _groupRepository;
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
            IGroupRepository groupRepository,
            IGroupRandomizerFactory randomizerFactory)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _randomizerFactory = randomizerFactory;
        }

        public List<GroupDetailModel> Execute(int roomId, RandomizerModel randomizerModel)
        {
            var room = _roomRepository.Get(roomId);
            var randomizer = _randomizerFactory.CreateRandomizer(randomizerModel);
            //This does not work ---->
            var userWithGroups = room.Groups.Select(g => g.Members).Aggregate((l1, l2) => { l1.AddRange(l2);return l1; } ).Select(gm => gm.User);

            var usersWithNoGroup = _userRepository.GetAll().Where(u => !userWithGroups.Contains(u));

            List<Group> newGroups =randomizer.GenerateGroups(usersWithNoGroup.ToList());

            newGroups.ForEach(g => room.Groups.Add(g));
            _unitOfWork.Save();

            return _mapper.Map<List<GroupDetailModel>>(newGroups);
        }
    }
}
