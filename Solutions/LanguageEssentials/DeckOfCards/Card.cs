namespace Game
{
    class Card
    {
        string k_sVal;
        int k_value;

        string k_suit;

        public static string[] Suits = new string[4] {"Spades", "Hearts", "Diamonds", "Clubs"};
        public Card(string s, int val)
        {
            switch(val)
            {
                case 11:
                    k_sVal = "Jack";
                    break;
                case 12:
                    k_sVal = "Queen";
                    break;
                case 13:
                    k_sVal = "King";
                    break;
                case 1:
                    k_sVal = "Ace";
                    break;
                default:
                    k_sVal = val.ToString();
                    break;
            }
            k_suit = s;
            k_value = val;
        }

        public void SayCard()
        {
            System.Console.WriteLine("The {0} of {1}", this.k_sVal, this.k_suit);
        }

    }
}