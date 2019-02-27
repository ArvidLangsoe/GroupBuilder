using GroupBuilderApplication.Commands.RandomizeGroups;
using GroupBuilderApplication.Factory.GroupRandomizer.Randomizers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Factory.GroupRandomizer
{
    public class GroupRandomizerFactory : IGroupRandomizerFactory
    {
        public Randomizer CreateRandomizer( RandomizerModel randomizerModel) {

            switch (randomizerModel.Algorithm) {
                case RandomizerEnum.EvenSplit:
                    return new EvenSplitRandomizer(randomizerModel);
                default:
                    throw new ArgumentException("Chosen Randomizer does not exist.");
            }
        }

    }
}
