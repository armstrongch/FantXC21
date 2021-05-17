using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantXC21
{
    public enum SegmentType
    {
        FLAT,
        UPHILL,
        DOWNHILL,
        ROUGH
    }

    class Course
    {
        public List<SegmentType> segments { get; private set; }
        private Random random;
        public string name { get; private set; }
        public int elevation { 
            get
            {
                return segments.Where(x => x.Equals(SegmentType.UPHILL)).Count() - segments.Where(x => x.Equals(SegmentType.DOWNHILL)).Count();
            }
            private set { }
        }
        public TimeSpan courseRecord { get; private set; }
        public string recordHolderName { get; private set; }
        public int runnerCapacity { get; private set; }

        public Course(string courseName, int runnerCapacity)
        {
            name = courseName;
            this.runnerCapacity = runnerCapacity;
            segments = new List<SegmentType>();
            random = new Random();
            courseRecord = new TimeSpan(0, 100, 0); //Default course record is laughably slow: 100 minutes

            Array values = Enum.GetValues(typeof(SegmentType));
            int elevation = 0;
            while (segments.Count < 100)
            {
                int segmentCount = 3 + random.Next(6); //3-8
                if (segments.Count + segmentCount > 100)
                {
                    segmentCount = 100 - segments.Count;
                }

                SegmentType type; 
                if (elevation > 10)
                {
                    type = SegmentType.DOWNHILL;
                }
                else if (elevation < -10)
                {
                    type = SegmentType.UPHILL;
                }
                else
                {
                    type = (SegmentType)values.GetValue(random.Next(values.Length));
                }
                
                for (int i = 0; i < segmentCount; i += 1)
                {
                    segments.Add(type);
                    if (type == SegmentType.UPHILL)
                    {
                        elevation += 1;
                    }
                    else if (type == SegmentType.DOWNHILL)
                    {
                        elevation -= 1;
                    }
                }
            }
        }
        
        public void updateCourseRecord(Dictionary<string, TimeSpan> finisherList)
        {
            for (int i = 0; i < finisherList.Count; i += 1)
            {
                if (finisherList.ElementAt(i).Value < courseRecord)
                {
                    courseRecord = finisherList.ElementAt(i).Value;
                }
            }
        }

        public static readonly string[] names = {
            "Heathcliff University", "Salem Reservoir", "Sawmill Park", "Camp Burkewood", "Goat Bridge Mountain", "Carter State Forest"
        };
    }
}
