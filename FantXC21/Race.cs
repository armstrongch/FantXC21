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
        //Instead of just sorting the existing list, we are going to create a new list at the end of the race,
        // so that this will break if we try to award points before sorting the finishers
        public List<string> sortedFinisherList { get; private set; }

        public Race(Course course)
        {
            this.course = course;
            timeElapsed = new TimeSpan(0, 0, 0);
            runnerNames = new List<string>();
            finisherList = new Dictionary<string, TimeSpan>();
        }

        public void AddRunner(Runner runner)
        {
            if (runner != null)
            {
                runnerNames.Add(runner.name);
            }  
        }

        public void EndRaceTurn()
        {
            timeElapsed += unitOfTime;
        }

        internal void sortFinisherList()
        {
            sortedFinisherList = new List<string>();
            foreach(var item in finisherList.OrderBy(d => d.Value).ToList())
            {
                sortedFinisherList.Add(item.Key);
            }
        }
    }
}
