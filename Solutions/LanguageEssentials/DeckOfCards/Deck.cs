using System;
using System.Collections.Generic;

namespace Game
{
    class Deck
    {
        List<Card> k_cards = new List<Card>();
        public Deck()
        {
            Reset();
        }

        public List<Card> Reset()
        {
            k_cards.Clear();
            for(int i = 0; i < 4; i++)
            {
                int j = 1;
                while(j < 14)
                {
                    k_cards.Add(new Card(Card.Suits[i], j));
                    j++;
                }
            }
            return k_cards;
        }

        public List<Card> Cards
        {
            get { return this.k_cards; }
        }

        public void ShowDeck()
        {
            foreach (Card c in k_cards)
            {
                c.SayCard();
            }
        }

        public Card Deal()
        {
            Card theCard = k_cards[0];
            k_cards.RemoveAt(0);
            return theCard;
        }

        public void Shuffle()
        {
            List<Card> cards2shuffle = this.k_cards;
            List<Card> shuffled = new List<Card>();
            Random randy = new Random();
            while(cards2shuffle.Count > 0)
            {
                int idx = randy.Next(0, cards2shuffle.Count);
                shuffled.Add(cards2shuffle[idx]);
                cards2shuffle.RemoveAt(idx);
            }
            this.k_cards = shuffled;
        }
    }
}