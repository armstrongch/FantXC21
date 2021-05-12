using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantXC21
{
    class Season
    {
        public int weekNum { get; private set; }
        public List<Week> weeks { get; private set; }
        public List<Runner> runners { get; private set; }
       
        private List<Workout> workouts;
        public Random random;

        public const int pointsToQualify = 140;
        public const int numTopThreeFinishesToQualify = 4;
        
        public Season()
        {
            weekNum = 1;
            runners = new List<Runner>();
            workouts = new List<Workout>();

            runners.Add(new Runner(Runner.names[0], true));
            for (int i = 1; i < 99; i += 1)
            {
                runners.Add(new Runner(Runner.names[i], false));
            }

            Array workoutTypes = Enum.GetValues(typeof(workoutType));

            foreach (workoutType workoutType in workoutTypes)
            {
                workouts.Add(new Workout(workoutType));
            }

            random = new Random();
            weeks = new List<Week>();
        }

        public void SelectAndPerformWorkoutsForAllCPURunners()
        {
            foreach (Runner runner in runners)
            {
                if (!runner.isPlayer)
                {
                    runner.doWorkout(runner.selectWorkout(weeks.Last().WorkoutSelection_One));
                    runner.doWorkout(runner.selectWorkout(weeks.Last().WorkoutSelection_Two));
                }
            }
        }

        public void AddWeekToSeason()
        {
            Week week = new Week(
                GetWorkoutSelection(),
                GetWorkoutSelection());

            weeks.Add(week);
        }

        public List<Workout> GetWorkoutSelection()
        {
            List<Workout> workoutSelection = new List<Workout>();

            //Assumes workouts costs 0, 1, 2 or 3
            for (int i = 0; i < 4; i += 1)
            {
                //Get all of the workouts that cost i, and add one of each to the list
                List<Workout> workoutSubset = workouts.Where(w => w.cost == i).ToList();
                workoutSelection.Add(workoutSubset.ElementAt(random.Next(workoutSubset.Count())));
            }
            return workoutSelection;
        }
    }
}
