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

        public Card(cardType type)
        {
            this.cardType = cardType;
            switch (type)
            {
                case cardType.RUN:
                    this.distance = 800;
                    this.energy = 10;
                    this.specialText = "None";
                    break;
                case cardType.SURGE:
                    this.distance = 1400;
                    this.energy = 25;
                    this.specialText = "None";
                    break;
                case cardType.FATIGUE:
                    this.distance = 600;
                    this.energy = 25;
                    this.specialText = "None";
                    break;
                case cardType.RECOVER:
                    this.distance = 600;
                    this.energy = 5;
                    this.specialText = "Gain 10% Energy";
                    break;
                case cardType.KICK:
                    this.distance = 1600;
                    this.energy = 15;
                    this.specialText = "Expends all available Energy";
                    break;
                case cardType.COAST:
                    this.distance = 700;
                    this.energy = 5;
                    this.specialText = "Can only be used while running with a pack";
                    break;
                case cardType.REEL_IN:
                    this.distance = 1000;
                    this.energy = 10;
                    this.specialText = "Can only be used within 300 meters behind the next runner";
                    break;
            }
        }
    }
}
