using GroupBuilderApplication.Commands.RandomizeGroups;
using GroupBuilderDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Factory.GroupRandomizer.Randomizers
{
    public abstract class Randomizer
    {

        protected int MinimumGroupSize { get; set; }
        protected int MaximumGroupSize { get; set; }


        protected int MinimumNumberOfGroups { get; set; }
        protected int MaximumNumberOfGroups { get; set; }


        public Randomizer(RandomizerModel randomizerModel) {
            MinimumGroupSize = randomizerModel.MinimumGroupSize;
            MaximumGroupSize = randomizerModel.MaximumGroupSize;

            MinimumNumberOfGroups = randomizerModel.MinimumNumberOfGroups;
            MaximumNumberOfGroups = randomizerModel.MaximumNumberOfGroups;
        }


        public abstract List<Group> GenerateGroups(List<User> users);

        protected void CheckMaximumRequirements(List<User> users)
        {
            if (MaximumNumberOfGroups < users.Count/MaximumGroupSize +1)
            {
                throw new ArgumentException("There are to many users to match the maximum requirements.");
            }
        }

        protected void CheckMinimumRequirements(List<User> users)
        {
            if (MinimumNumberOfGroups * MinimumGroupSize > users.Count)
            {
                throw new ArgumentException("There are to few users to match the minimum requirements.");
            }
        }

    }
}
