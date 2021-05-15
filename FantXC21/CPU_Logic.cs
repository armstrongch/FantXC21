using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantXC21
{
    enum WorkoutSelectionType
    {
        RECOVER_OVER_5 //Recover if exhaustion is over 5, otherwise pick a random non-recovery workout
    }

    enum CardSelectionType
    {
        LONGEST_DISTANCE_LOGICAL_KICK //Always go as far as possible, but only kick when we can reach the finish
    }
    class CPU_Logic
    {
        public WorkoutSelectionType WorkoutSelectionType { get; private set;}
        public CardSelectionType CardSelectionType { get; private set; }
        private Random random;

        public CPU_Logic()
        {
            random = new Random();

            //Get a random workout selection type
            Array workout_values = Enum.GetValues(typeof(WorkoutSelectionType));
            WorkoutSelectionType = (WorkoutSelectionType)workout_values.GetValue(random.Next(workout_values.Length));

            Array card_values = Enum.GetValues(typeof(CardSelectionType));
            CardSelectionType = (CardSelectionType)card_values.GetValue(random.Next(card_values.Length));
        }
    }
}
