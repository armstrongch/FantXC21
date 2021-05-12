using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantXC21
{
    class Runner
    {
        public string name { get; private set; }
        public bool isPlayer { get; private set; }
        public int exhaustion { get; private set; }
        public int exhaustionReduction { get; private set; }
        public int startingEnergy { get; private set; }
        public int bonusEnergy { get; private set; }
        public int bonusDistanceAboveEighty { get; private set; }
        public Dictionary<cardType, int> cardEnergyModifiers { get; private set; }
        public Dictionary<cardType, int> cardDistanceModifiers { get; private set; }
        public CPU_Logic cpu_logic { get; private set; }
        public List<RaceResults> raceResults { get; private set; }
        public List<workoutType> workouts { get; private set; }
        
        public List<cardType> deck { get; private set; }
        public List<cardType> hand { get; private set; }
        public List<cardType> discard { get; private set; }

        public Runner(string name, bool isPlayer)
        {
            this.name = name;
            this.isPlayer = isPlayer;
            exhaustion = 0;
            exhaustionReduction = 0;
            bonusDistanceAboveEighty = 0;

            cpu_logic = new CPU_Logic();

            deck = new List<cardType>();
            deck.Add(cardType.RUN);
            deck.Add(cardType.RUN);
            deck.Add(cardType.RUN);
            deck.Add(cardType.SURGE);
            deck.Add(cardType.SURGE);
            deck.Add(cardType.RECOVER);
            deck.Add(cardType.RECOVER);
            deck.Add(cardType.KICK);
            deck.Add(cardType.COAST);
            deck.Add(cardType.COAST);
            deck.Add(cardType.REEL_IN);
            deck.Add(cardType.REEL_IN);

            hand = new List<cardType>();
            discard = new List<cardType>();
            bonusEnergy = 0;
            startingEnergy = 100;
            cardEnergyModifiers = new Dictionary<cardType, int>();
            cardDistanceModifiers = new Dictionary<cardType, int>();
            raceResults = new List<RaceResults>();
        }

        public Card getModifiedCard(cardType type)
        {
            int distanceMod = cardDistanceModifiers.ContainsKey(type) ? cardDistanceModifiers[type] : 0;
            int costMod = cardEnergyModifiers.ContainsKey(type) ? cardEnergyModifiers[type] : 0;
            return new Card(type, distanceMod, costMod);
        }

        private void updateEnergyModifier(cardType type, int modifier)
        {
            if (cardEnergyModifiers.ContainsKey(type))
            {
                cardEnergyModifiers[type] += modifier;
            }
            else
            {
                cardEnergyModifiers.Add(type, modifier);
            }
        }

        private void updateDistanceModifier(cardType type, int modifier)
        {
            if (cardDistanceModifiers.ContainsKey(type))
            {
                cardDistanceModifiers[type] += modifier;
            }
            else
            {
                cardDistanceModifiers.Add(type, modifier);
            }
        }

        public Workout selectWorkout(List<Workout> WorkoutList)
        {
            switch (cpu_logic.WorkoutSelectionType)
            {
                case WorkoutSelectionType.RECOVER_OVER_5:
                default:
                    if (exhaustion < 5)
                    {
                        return WorkoutList.Where(w => w.cost == 0).FirstOrDefault();
                    }
                    else
                    {
                        return WorkoutList.Where(w => w.cost > 0).FirstOrDefault();
                    }
            }
        }

        public void doWorkout(Workout workout)
        {
            int calculatedExhaustion = workout.cost - exhaustionReduction;
            if (calculatedExhaustion > 0)
            {
                exhaustion += calculatedExhaustion;
            }

            switch(workout.workoutType)
            {
                case workoutType.EASY_RUN:
                    exhaustion -= 3;
                    if (exhaustion < 0)
                    {
                        exhaustion = 0;
                    }
                    break;
                case workoutType.CROSS_TRAIN:
                    exhaustion = Convert.ToInt32(Math.Floor(exhaustion * 0.5));
                    break;
                case workoutType.DAY_OFF:
                    bonusEnergy += 20;
                    break;
                case workoutType.LONG_RUN:
                    startingEnergy += 25;
                    break;
                case workoutType.DOUBLE_WORKOUT:
                    deck.Add(cardType.RUN);
                    break;
                case workoutType.FARTLEKS:
                    deck.Add(cardType.SURGE);
                    break;
                case workoutType.TEMPO:
                    updateEnergyModifier(cardType.RUN, -5);
                    updateEnergyModifier(cardType.COAST, -5);
                    break;
                case workoutType.CRUISE_INTERVALS:
                    updateEnergyModifier(cardType.KICK, -5);
                    break;
                case workoutType.THRESHOLD_REPEATS:
                    updateDistanceModifier(cardType.SURGE, 200);
                    updateDistanceModifier(cardType.REEL_IN, 300);
                    break;
                case workoutType.PROGRESSIVE_RUN:
                    updateDistanceModifier(cardType.RUN, 300);
                    break;
                case workoutType.WEIGHT_LIFTING:
                    Array cardTypes = Enum.GetValues(typeof(cardType));
                    foreach (cardType cardType in cardTypes)
                    {
                        updateDistanceModifier(cardType, 200);
                        updateEnergyModifier(cardType, 5);
                    }
                    break;
                case workoutType.COMPOUND_SETS:
                    updateDistanceModifier(cardType.RUN, 100);
                    break;
                case workoutType.HILL_SPRINTS:
                    updateDistanceModifier(cardType.SURGE, 100);
                    updateDistanceModifier(cardType.REEL_IN, 100);
                    break;
                case workoutType.STEADY_VOLUME:
                    exhaustionReduction += 1;
                    break;
                case workoutType.FULL_RECOVERY_REPEATS:
                    bonusDistanceAboveEighty += 100;
                    break;
            }
        }

        public int getTotalPoints()
        {
            int totalPoints = 0;
            foreach(RaceResults result in raceResults)
            {
                totalPoints += 1 + result.numberOfRunners - result.finishPosition;
            }
            return totalPoints;
        }

        public int getNumTopThreeFinishes()
        {
            int numTopThrees = 0;
            foreach(RaceResults results in raceResults)
            {
                if (results.finishPosition <= 3)
                {
                    numTopThrees += 1;
                }
            }
            return numTopThrees;
        }

        public static readonly string[] names = {
            "Smith", "Johnson ", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor",
            "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", "Martinez", "Robinson",
            "Clark", "Rodriguez", "Lewis", "Lee", "Walker", "Hall", "Allen", "Young", "Hernandez", "King",
            "Wright", "Lopez", "Hill", "Scott", "Green", "Adams", "Baker", "Gonzalez", "Nelson", "Carter",
            "Mitchell", "Perez", "Roberts", "Turner", "Phillips", "Campbell", "Parker", "Evans", "Edwards", "Collins",
            "Stewart", "Sanchez", "Morris", "Rogers", "Reed", "Cook", "Morgan", "Bell", "Murphy", "Bailey",
            "Rivera", "Cooper", "Richardson", "Cox", "Howard", "Ward", "Torres", "Peterson", "Gray", "Ramirez",
            "James", "Watson", "Brooks", "Kelly", "Sanders", "Price", "Bennett", "Wood", "Barnes", "Ross",
            "Henderson", "Coleman", "Jenkins", "Perry", "Powell", "Long", "Patterson", "Hughes", "Flores", "Washington",
            "Butler", "Simmons", "Foster", "Gonzales", "Bryant", "Alexander", "Russell", "Griffin", "Diaz", "Hayes" };
    }

    
}
