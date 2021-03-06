﻿using GroupBuilderApplication.Commands.RandomizeGroups;
using GroupBuilderApplication.Queries.GetGroupDetails;
using GroupBuilderApplication.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderApplication.Commands.RandomizeRoom
{
    public interface IRandomizeRoomCommand
    {
        List<GroupDetailModel> Execute(int roomId, RandomizerModel randomizerModel);
    }
}
