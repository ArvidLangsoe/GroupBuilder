using GroupBuilderApplication.Commands.RandomizeGroups;
using GroupBuilderApplication.Factory.GroupRandomizer.Randomizers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Factory.GroupRandomizer
{
    public interface IGroupRandomizerFactory
    {
        Randomizer CreateRandomizer( RandomizerModel randomizerModel);

    }
}
