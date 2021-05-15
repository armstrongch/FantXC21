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
        public Boolean qualified { 
            get
            {
                return (getTotalPoints() >= 140) || (getNumTopThreeFinishes() >= 4);

            }
            set { }
        }
        public Dictionary<string, TimeSpan> coursePersonalBests { get; private set; }
        public TimeSpan personalBest { get; private set; }

        public int turnStartPosition { get; private set; }
        public int turnEndPosition { get; private set; }
        public int currentEnergy { get; private set; }

        private Random random;

        public Runner(string name, bool isPlayer)
        {
            this.name = name;
            this.isPlayer = isPlayer;
            exhaustion = 0;
            exhaustionReduction = 0;
            bonusDistanceAboveEighty = 0;
            personalBest = new TimeSpan(0, 100, 0);
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
            workouts = new List<workoutType>();

            coursePersonalBests = new Dictionary<string, TimeSpan>();
            for (int i = 0; i < Course.names.Length; i += 1)
            {
                coursePersonalBests.Add(Course.names[i], personalBest);
            }

            random = new Random();
        }

        //Only call this when actually prepping for a race, or you'll wipe out the bonus energy. This shouldn't be a general-purpose reset
        public void PrepareForRace()
        {
            turnStartPosition = 0;
            turnEndPosition = 0;
            currentEnergy = startingEnergy + bonusEnergy;
            bonusEnergy = 0;
            deck.AddRange(discard);
            deck.AddRange(hand);
            deck.RemoveAll(c => c == cardType.FATIGUE);
            discard = new List<cardType>();
            hand = new List<cardType>();
            deck.Shuffle(random);
            for (int i = 0; i < 2; i += 1)
            {
                drawCard();
            }
            hand.Add(cardType.FATIGUE);
        }

        public void startNewTurn()
        {
            turnStartPosition = turnEndPosition;
            drawCard();
        }

        public void drawCard()
        {
            if (deck.Count > 0)
            {
                hand.Add(deck[0]);
                deck.RemoveAt(0);
            }
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

        public Card selectCard(List<Card> validCards)
        {
            switch (cpu_logic.CardSelectionType)
            {
                case CardSelectionType.LONGEST_DISTANCE_LOGICAL_KICK:
                default:
                    //Card with longest distance, prioritizing lower cost
                    validCards.OrderBy(c => c.energy / 100 - c.distance);
                    Card selectedCard = validCards.First();
                    //If the longest card is a kick, only do it if it will get us over the finish line
                    if (selectedCard.cardType == cardType.KICK)
                    {
                        if ((10000 - turnStartPosition) > selectedCard.distance)
                        {
                            selectedCard = validCards[1];
                        }
                    }
                    return selectedCard;
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
                        List<Workout> nonRecoveryWorkouts = WorkoutList.Where(w => w.cost > 0).ToList();
                        nonRecoveryWorkouts.Shuffle(random);
                        return WorkoutList.Find(w => w.cost > 0);

                    }
                    else
                    {
                        return WorkoutList.Find(w => w.cost == 0);
                    }
            }
        }

        public void playCard(Card card)
        {
            if (card.cardType != cardType.FATIGUE)
            {
                hand.Remove(card.cardType);
                discard.Add(card.cardType);
            }

            turnEndPosition += card.distance;
            currentEnergy -= card.energy;
            switch (card.cardType)
            {
                case cardType.RECOVER:
                    currentEnergy += 10;
                    break;
                case cardType.KICK:
                    currentEnergy = 0;
                    break;
            }
        }

        public void doWorkout(Workout workout)
        {
            int calculatedExhaustion = workout.cost - exhaustionReduction;
            if (calculatedExhaustion > 0)
            {
                exhaustion += calculatedExhaustion;
            }

            workouts.Add(workout.workoutType);

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
            "Armstrong", "Johnson ", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor",
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
