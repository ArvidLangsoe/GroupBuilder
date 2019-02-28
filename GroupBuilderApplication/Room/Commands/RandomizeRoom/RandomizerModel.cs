using GroupBuilderApplication.Factory.GroupRandomizer.Randomizers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GroupBuilderApplication.Commands.RandomizeGroups
{
    public class RandomizerModel
    {
        public int MinimumGroupSize { get; set; } = 2;
        public int MaximumGroupSize { get; set; } = 6;
        public int MinimumNumberOfGroups { get; set; } = 1;
        public int MaximumNumberOfGroups { get; set; } = Int32.MaxValue;
        public RandomizerEnum Algorithm { get; set; } = RandomizerEnum.EvenSplit;

        
    }
}
