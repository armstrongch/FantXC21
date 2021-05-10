﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantXC21
{
    class RaceResults
    {
        public int finishPosition {get; private set;}
        public int numberOfRunners { get; private set; }
        public int remainingEnergy { get; private set; }
        public int distanceAheadOfNextPlace { get; private set; }
    }
}
