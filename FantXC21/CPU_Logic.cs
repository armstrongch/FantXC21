using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantXC21
{
    enum WorkoutSelectionType
    {
        RECOVER_OVER_50 //Recover if 
    }
    class CPU_Logic
    {
        public WorkoutSelectionType WorkoutSelectionType { get; private set;}
        private Random random;

        public CPU_Logic()
        {
            random = new Random();

            //Get a random workout selection type
            Array values = Enum.GetValues(typeof(WorkoutSelectionType));
            WorkoutSelectionType = (WorkoutSelectionType)values.GetValue(random.Next(values.Length));
        }
    }
}
