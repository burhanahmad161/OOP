using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace card.Bl
{
    class Card
    {
        private int Value;
        private int Suit;
        public Card(int value,int suit)
        {
            this.Value = value;
            this.Suit = suit;
        }
        public int getValue()
        {
            return Value;
        }
        public int getSuit()
        {
            return Suit;
        }
        public string getValueAsString()
        {
            if(Value==1)
            {
                return "Ace";
            }
            else if(Value == 11)
            {
                return "Jack";
            }
            else if (Value == 12)
            {
                return "Queen";
            }
            else if (Value == 13)
            {
                return "King";
            }
            else
            {
                return Value.ToString();
            }
        }
        public string getSuitAsString()
        {
            if (Suit == 1)
            {
                return "Clubs";
            }
            else if (Suit == 2)
            {
                return "Diamonds";
            }
            else if (Suit == 3)
            {
                return "Sapdes";
            }
            else
            {
                return "Hearts";
            }
        }
        public string toString()
        {
            return getValueAsString() + " of " + getSuitAsString();
        }
    }
}
