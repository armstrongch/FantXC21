using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantXC21
{
    public enum workoutType
    {
        EASY_RUN,
        CROSS_TRAIN,
        DAY_OFF,

        FULL_RECOVERY_REPEATS,
        FARTLEKS,
        HILL_SPRINTS,
        COMPOUND_SETS,

        DOUBLE_WORKOUT,
        WEIGHT_LIFTING,
        PROGRESSIVE_RUN,
        THRESHOLD_REPEATS,

        LONG_RUN,
        TEMPO,
        CRUISE_INTERVALS,
        STEADY_VOLUME
    }
    class Workout
    {
        public string name { get; private set; }
        public int cost { get; private set; }
        public string text { get; private set; }
        public workoutType workoutType { get; private set; }

        public Workout(workoutType type)
        {
            this.workoutType = type;
            switch (type)
            {
                //Rest Days
                case workoutType.EASY_RUN:
                    name = "Easy Run";
                    cost = 0;
                    text = "Reduce exhaustion by 3";
                    break;
                case workoutType.CROSS_TRAIN:
                    name = "Cross Train";
                    cost = 0;
                    text = "Reduce exhaustion by 50%";
                    break;
                case workoutType.DAY_OFF:
                    name = "Day Off";
                    cost = 0;
                    text = "Increase energy by 20% during this week's race";
                    break;
                
                //Easy Workouts
                case workoutType.FULL_RECOVERY_REPEATS:
                    name = "Full-Recovery Repeats";
                    cost = 1;
                    text = "Advance an additional 100 meters at the end of any turn where you have at least 80% energy remaining";
                    break;
                case workoutType.FARTLEKS:
                    name = "Fartleks";
                    cost = 1;
                    text = "Add an additional 'Surge' card to your deck";
                    break;
                case workoutType.HILL_SPRINTS:
                    name = "Hill Sprints";
                    cost = 1;
                    text = "Increase distance of 'Surge' and 'Reel In' cards by 100 meters";
                    break;
                case workoutType.COMPOUND_SETS:
                    name = "Compound Sets";
                    cost = 1;
                    text = "Increase distance of 'Kick' cards by 100 meters";
                    break;

                //Medium Workouts
                case workoutType.WEIGHT_LIFTING:
                    name = "Weight Lifting";
                    cost = 2;
                    text = "Increase the cost of all cards by 5% and increase the distance of all cards by 200 meters";
                    break;
                case workoutType.DOUBLE_WORKOUT:
                    name = "Double Workout";
                    cost = 2;
                    text = "Add an additional 'Run' card to your deck";
                    break;
                case workoutType.PROGRESSIVE_RUN:
                    name = "Progressive Run";
                    cost = 2;
                    text = "Increase distance of 'Run' cards by 300 meters";
                    break;
                case workoutType.THRESHOLD_REPEATS:
                    name = "Threshold Repeats";
                    cost = 2;
                    text = "Increase distance of 'Surge' and 'Reel In' cards by 200 meters";
                    break;

                //Hard Workouts
                case workoutType.LONG_RUN:
                    name = "Long Run";
                    cost = 3;
                    text = "Permenantly increase starting energy by 25%";
                    break;
                case workoutType.TEMPO:
                    name = "Tempo";
                    cost = 3;
                    text = "Reduce cost of 'Run' and 'Coast' cards by 5% energy";
                    break;
                case workoutType.CRUISE_INTERVALS:
                    name = "Cruise Intervals";
                    cost = 3;
                    text = "Reduce the cost of 'Kick' cards by 5% energy";
                    break;
                case workoutType.STEADY_VOLUME:
                    name = "Steady Volume";
                    cost = 3;
                    text = "Reduce exhaustion from workouts and races by 1";
                    break;
            }
        }
    }
}
