using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupBuilderApplication.Commands.RandomizeGroups;
using GroupBuilderDomain;

namespace GroupBuilderApplication.Factory.GroupRandomizer.Randomizers
{

    //This algoritm will group users the most evenly split way. 
    //This means only one group will have a different amount of memebers from the rest, but as close as possible.
    public class EvenSplitRandomizer : Randomizer
    {
        public EvenSplitRandomizer(RandomizerModel randomizerModel) : base(randomizerModel)
        {
        }

        public override List<Group> GenerateGroups(List<User> users)
        {
            CheckMinimumRequirements(users);
            CheckMaximumRequirements(users);

            int idealGroupSize = -1;
            double idealRemainderPercentage = 1;

            for(int i = MaximumGroupSize; i>MinimumGroupSize; i--)
            {
                var remainder = users.Count % i;
                var percent = ((double)remainder) / i;

                if (remainder>0&&remainder < MinimumGroupSize) {
                    continue;
                }

                if (idealRemainderPercentage > percent) {
                    idealGroupSize = i;
                    idealRemainderPercentage = percent;
                }
                if (percent >= 0.999) {
                    break;
                }
            }
            if (idealGroupSize == -1) {
                throw new Exception("Error could not find an optimal group distribution");
            }

            List<Group> groups = new List<Group>();
            Random random = new Random();
            var randomizedList = users.OrderBy(u => random.Next()).ToList();

            while (randomizedList.Count > 0) {
                Group currentGroup = new Group();
                for (int i = 0; i<idealGroupSize; i++) {
                    var user = randomizedList.LastOrDefault();
                    if (user == null) {
                        break;
                    }
                    randomizedList.Remove(user);

                    currentGroup.Members.Add(
                        new GroupMember {
                            User = user,
                            UserId = user.Id
                    });
                }
                groups.Add(currentGroup);
            }
            return groups;
        }


    }
}
