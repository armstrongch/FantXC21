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
        public List<Race> races { get; private set; }

        public Week(List<Workout> WS_One, List<Workout> WS_Two, List<Course> courses)
        {
            WorkoutSelection_One = WS_One;
            WorkoutSelection_Two = WS_Two;
            races = new List<Race>();
            foreach(Course course in courses)
            {
                races.Add(new Race(course));
            }
        }
    }
}
