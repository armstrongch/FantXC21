using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantXC21
{
    class Week
    {
        public List<Workout> WorkoutSelection_One { get; private set; }
        public List<Workout> WorkoutSelection_Two { get; private set; }

        public Week(List<Workout> WS_One, List<Workout> WS_Two)
        {
            WorkoutSelection_One = WS_One;
            WorkoutSelection_Two = WS_Two;
        }
    }
}
