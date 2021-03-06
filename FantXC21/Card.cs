using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantXC21
{
    public enum cardType {
        RUN,
        SURGE,
        FATIGUE,
        RECOVER,
        KICK,
        COAST,
        REEL_IN
    }
    class Card
    {
        public int distance { get; private set; }
        public int energy { get; private set; }
        public string specialText { get; private set; }
        public cardType cardType { get; private set; }
        public string name { get; private set; }

        public Card(cardType type)
        {
            this.cardType = type;
            switch (type)
            {
                case cardType.RUN:
                    this.name = "Run";
                    this.distance = 800;
                    this.energy = 10;
                    this.specialText = "None";
                    break;
                case cardType.SURGE:
                    this.name = "Surge";
                    this.distance = 1400;
                    this.energy = 25;
                    this.specialText = "None";
                    break;
                case cardType.FATIGUE:
                    this.name = "Fatigue";
                    this.distance = 600;
                    this.energy = 0;
                    this.specialText = "Always available";
                    break;
                case cardType.RECOVER:
                    this.name = "Recover";
                    this.distance = 600;
                    this.energy = 5;
                    this.specialText = "Gain 10% Energy";
                    break;
                case cardType.KICK:
                    this.name = "Kick";
                    this.distance = 1600;
                    this.energy = 15;
                    this.specialText = "Expends all available Energy";
                    break;
                case cardType.COAST:
                    this.name = "Coast";
                    this.distance = 700;
                    this.energy = 5;
                    this.specialText = "Can only be used while running with a pack";
                    break;
                case cardType.REEL_IN:
                    this.name = "Reel In";
                    this.distance = 1000;
                    this.energy = 10;
                    this.specialText = "Can only be used within 300 meters behind the next runner";
                    break;
            }
        }

        public Card(cardType type, int modifiedDistance, int modifiedCost, int exhaustion) : this(type)
        {
            this.distance += modifiedDistance;
            this.energy += modifiedCost;
            this.energy = Convert.ToInt32(Math.Round((1 + exhaustion * 0.1) * this.energy));
            this.energy = Convert.ToInt32(Math.Max(this.energy, 0));
        }
    }
}
