namespace ViewModels
{
    public class Fruit
    {
        public string Name {get;set;}
        public int Calories {get;set;}

        public static Fruit[] BuildSomeFruits()
        {
            return new Fruit[]
            {
                new Fruit()
                {
                    Name = "Apple",
                    Calories = 20,
                },
                new Fruit() 
                {
                    Name = "Mango",
                    Calories = 35
                },
                new Fruit()
                {
                    Name = "Banana",
                    Calories = 23
                }
            };
        }
    }

    public class IndexViewModel
    {
        public Fruit TheFruit {get;set;}
        public Fruit[] MyFruits {get;set;}
        public string Message {get;set;}
    }


}