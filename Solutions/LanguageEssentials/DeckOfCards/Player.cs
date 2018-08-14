using System.Collections.Generic;

namespace Game
{
    class Player
    {
        string k_name;
        List<Card> k_hand;
        public Player(string name)
        {
            k_name = name;
            k_hand = new List<Card>();
        }

        public string Name
        {
            get { return k_name; }
        }

        public Card Draw(Deck d)
        {
            Card theCard = d.Deal();
            k_hand.Add(theCard);
            return theCard;
        }

        public Card Discard(int idx)
        {
            Card theCard;
            if(idx < k_hand.Count)
            {
                theCard = k_hand[idx];
                k_hand.RemoveAt(idx);
                return theCard;
            }
            else { return null; }
        }

    }
}