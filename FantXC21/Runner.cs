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
        
        private List<Card> deck;
        private List<Card> hand;
        private List<Card> discard;
        

        public Runner(string name, bool isPlayer)
        {
            this.name = name;
            this.isPlayer = isPlayer;
            exhaustion = 0;
            exhaustionReduction = 0;
            bonusDistanceAboveEighty = 0;

            deck = new List<Card>();
            deck.Add(new Card(cardType.RUN));
            deck.Add(new Card(cardType.RUN));
            deck.Add(new Card(cardType.RUN));
            deck.Add(new Card(cardType.SURGE));
            deck.Add(new Card(cardType.SURGE));
            deck.Add(new Card(cardType.RECOVER));
            deck.Add(new Card(cardType.RECOVER));
            deck.Add(new Card(cardType.KICK));
            deck.Add(new Card(cardType.COAST));
            deck.Add(new Card(cardType.COAST));
            deck.Add(new Card(cardType.RUN));
            deck.Add(new Card(cardType.RUN));

            hand = new List<Card>();
            discard = new List<Card>();
            bonusEnergy = 0;
            startingEnergy = 100;
            cardEnergyModifiers = new Dictionary<cardType, int>();
            cardDistanceModifiers = new Dictionary<cardType, int>();
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
            if (cardEnergyModifiers.ContainsKey(type))
            {
                cardEnergyModifiers[type] += modifier;
            }
            else
            {
                cardEnergyModifiers.Add(type, modifier);
            }
        }

        public void doWorkout(Workout workout)
        {
            exhaustion += workout.cost;
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
                    deck.Add(new Card(cardType.RUN));
                    break;
                case workoutType.FARTLEKS:
                    deck.Add(new Card(cardType.SURGE));
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
                        updateEnergyModifier(cardType, -5);
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
