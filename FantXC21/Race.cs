using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantXC21
{
    class Race
    {
        public List<Runner> runners { get; private set; }
        public Course course { get; private set; }
        public TimeSpan timeElapsed { get; private set; }

        public static readonly TimeSpan unitOfTime = new TimeSpan(0, 5, 40);
    }
}
