﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GroupBuilderDomain
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
    }
}
