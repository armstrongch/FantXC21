using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantXC21
{
    class Season
    {
        public int weekNum {
            get {
                return this.weeks.Count();
            } 
            set { }
        }
        public List<Week> weeks { get; private set; }
        public List<Runner> runners { get; private set; }
        public List<Course> courses { get; private set; }

        public const int pointsToQualify = 140;

        private List<Workout> workouts;
        public Random random;

        public const int numTopThreeFinishesToQualify = 4;
        
        public Season()
        {
            runners = new List<Runner>();
            workouts = new List<Workout>();

            runners.Add(new Runner(Runner.names[0], true));
            for (int i = 1; i <= 99; i += 1)
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
            courses = new List<Course>();
            int runnerCap;
            for (int i = 0; i < 6; i += 1)
            {
                switch(i)
                {
                    //Runner Capacity is 10, 15, 15, 20, 20, 20 for a total of 100 runners
                    case 0: runnerCap = 10; break;
                    case 1: case 2: runnerCap = 15; break;
                    default: runnerCap = 20; break;
                }
                courses.Add(new Course(Course.names[i], runnerCap));
            }
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

        public void SelectAndPlayCardsForAllCPURunnersInRace(Race race)
        {
            List<Runner> runnersInRace = runners
                .Where(r => race.runnerNames.Contains(r.name))
                .Where(r => r.turnStartPosition < 10000)
                .Where(r => r.isPlayer == false).ToList();

            foreach (Runner runner in runnersInRace)
            {
                List<Card> validCardsInHand = new List<Card>();
                foreach(cardType type in runner.hand)
                {
                    if (isCardValid(type, runner.name))
                    {
                        Card handCard = runner.getModifiedCard(type);
                        validCardsInHand.Add(handCard);
                    }
                }
                Card selectedCard = runner.selectCard(validCardsInHand);
                runner.playCard(selectedCard);
            }
        }

        public void AddWeekToSeason()
        {
            Week week = new Week(
                GetWorkoutSelection(),
                GetWorkoutSelection(),
                courses);
            week.races[weekNum % 6].AddRunner(player);
            runners.Shuffle(random);
            int nextRunnerIndex = 0;
            foreach (Race race in week.races)
            {
                while (race.runnerNames.Count < race.course.runnerCapacity)
                {
                    if (!runners[nextRunnerIndex].isPlayer)
                    {
                        race.AddRunner(runners[nextRunnerIndex]);
                    }
                    nextRunnerIndex += 1;
                }
            }

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

        public void setupRace(Race race)
        {
            foreach(Runner runner in runners.Where(r => race.runnerNames.Contains(r.name)))
            {
                runner.PrepareForRace();
            }
        }

        public void startNewRaceTurn(Race race)
        {
            foreach (Runner runner in runners.Where(r => race.runnerNames.Contains(r.name)))
            {
                runner.startNewTurn();
            }
        }

        public void endRaceTurn(Race race)
        {
            foreach (Runner runner in runners.Where(r => race.runnerNames.Contains(r.name)).Where(r => race.finisherList.ContainsKey(r.name) == false))
            {
                if (runner.turnEndPosition >= 10000)
                {
                    int distanceTravelledThisTurn = runner.turnEndPosition - runner.turnStartPosition;
                    int distanceFromStartTo10k = 10000 - runner.turnStartPosition;
                    long percentageOfTurnDistanceRaceEnded = distanceFromStartTo10k / distanceTravelledThisTurn;

                    TimeSpan finishTime = race.timeElapsed.Add(new TimeSpan(Race.unitOfTime.Ticks * percentageOfTurnDistanceRaceEnded));
                    
                    race.finisherList.Add(runner.name, finishTime);
                    runner.finishRace(finishTime);
                }
            }
            race.EndRaceTurn();
            if (race.finisherList.Count == race.runnerNames.Count)
            {
                race.course.updateCourseRecord(race.finisherList);
                race.sortFinisherList();
                addRaceResults(race);
            }
        }

        private void addRaceResults(Race race)
        {
            foreach (Runner runner in runners.Where(r => race.runnerNames.Contains(r.name)))
            {
                RaceResults result = new RaceResults(
                    race.sortedFinisherList.IndexOf(runner.name) + 1,
                    race.sortedFinisherList.Count
                );
                runner.AddRaceResult(result);
            }
        }

        public Runner player
        {
            get
            {
                return runners.Find(r => r.isPlayer);
            }
        }
        public Race playerRace
        {
            get
            {
                return weeks.Last().races.Find(r => r.runnerNames.Contains(player.name));
            }
        }
        public List<Runner> runnersInPlayerRace { 
            get 
            { 
                return runners.Where(r => playerRace.runnerNames.Contains(r.name)).ToList(); 
            } 
        }
        
        public string getRacePlayerStatus()
        {
            int totalRunners = playerRace.runnerNames.Count();
            
            int numRunnersAhead = runnersInPlayerRace
                .Where(r => !r.isPlayer)
                .Where(r => r.turnStartPosition > player.turnStartPosition).Count();
            bool tiedForPosition = runnersInPlayerRace
                .Where(r => r.turnStartPosition == player.turnStartPosition).Count() > 1;
            List<Runner> packRunners = runnersInPlayerRace
                 .Where(r => !r.isPlayer)
                .Where(r => Math.Abs(r.turnStartPosition - player.turnStartPosition) <= 50).ToList();
            Runner leader = runnersInPlayerRace
                .OrderBy(r => r.turnStartPosition).Last();

            string statusString = "Energy Remaining: " + player.currentEnergy.ToString() + "%";
            statusString += "\n" + (10000 - player.turnStartPosition).ToString() + " meters from the finish";
            if (tiedForPosition)
            {
                statusString += ", tied for ";
            }
            else
            {
                statusString += ", in ";
            }
            statusString += Utility.ordinal_suffix_of(numRunnersAhead + 1) + " place.";

            if (leader.isPlayer)
            {
                statusString += "\nYou are leading the race!";
            }
            else
            {
                statusString += "\n" + leader.name + " is leading the race, with " + (10000 - leader.turnStartPosition) + " to go.";
            }
            if (packRunners.Count() > 0)
            {
                statusString += "\nYou are running with a pack of " + packRunners.Count() + " others, including: ";
                string packNameString = "";
                int packRunnersToList = Math.Min(packRunners.Count(), 6);
                
                for (int i = 0; i < packRunnersToList; i += 1)
                {
                    packNameString += packRunners[i].name;
                    if (i < packRunnersToList - 1)
                    {
                        packNameString += ", ";
                        if (i == packRunnersToList - 2)
                        {
                            packNameString += "and ";
                        }
                    }
                }
                statusString += packNameString;
            }
            else
            {
                statusString += "\nYou are not running with a pack.";
            }

            statusString += "\nThere are " + player.deck.Count().ToString() + " cards remaining in your deck.";
            statusString += "\nElapsed Time: " + playerRace.timeElapsed.ToString();

            return statusString;
        }

        public bool isCardValid(cardType type, string runnerName)
        {
            Runner runner = runners.Find(r => r.name == runnerName);
            Card card = runner.getModifiedCard(type);
            if (card.energy > runner.currentEnergy)
            {
                return false;
            }
            switch(type)
            {
                case cardType.COAST:
                    int nearbyRunnerCount = runnersInPlayerRace
                        .Where(r => r.name != runnerName)
                        .Where(r => Math.Abs(r.turnStartPosition - runner.turnStartPosition) <= 50)
                        .Count();
                    return nearbyRunnerCount > 0;
                case cardType.REEL_IN:
                    List<Runner> runnersLessThan300MetersAhead = runnersInPlayerRace
                        .Where(r => r.name != runnerName)
                        .Where(r => r.turnStartPosition > runner.turnStartPosition)
                        .Where(r => r.turnStartPosition <= runner.turnStartPosition + 300)
                        .ToList();
                    return runnersLessThan300MetersAhead.Count > 0;
                default: return true;
            }
        }

        public void simulateFullRace(Race race)
        {
            setupRace(race);
            while (race.finisherList.Count < race.runnerNames.Count)
            {
                startNewRaceTurn(race);
                SelectAndPlayCardsForAllCPURunnersInRace(race);
                endRaceTurn(race);
            }
        }
    }
}
