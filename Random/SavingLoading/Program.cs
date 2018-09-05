using System;
namespace SavingLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            Player you = Serializer<Player>.Load();
            if(you == null)
            {
                Console.WriteLine("Please enter a name");
                string name = Console.ReadLine();
                Serializer<Player>.Save(new Player(name));
                Console.WriteLine("... saving ...");
            }
            else
                Console.WriteLine($"Welcome back, {you.Name}!");
        }
    }
}
