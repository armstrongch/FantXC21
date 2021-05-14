using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantXC21
{
    class Race
    {
        public List<string> runnerNames { get; private set; }
        public Course course { get; private set; }
        public TimeSpan timeElapsed { get; private set; }

        public static readonly TimeSpan unitOfTime = new TimeSpan(0, 5, 40);

        public Dictionary<string, TimeSpan> finisherList { get; private set; }

        public Race(Course course)
        {
            this.course = course;
            timeElapsed = new TimeSpan(0, 0, 0);
            runnerNames = new List<string>();
        }

        public void AddRunner(Runner runner)
        {
            runnerNames.Add(runner.name);
        }
    }
}
