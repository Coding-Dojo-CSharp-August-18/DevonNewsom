using System;
using Game;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck d = new Deck();
            d.ShowDeck();
            System.Console.WriteLine("++++++++++++++++++++++++++");

            d.Shuffle();
            d.ShowDeck();
        }
    }
}
