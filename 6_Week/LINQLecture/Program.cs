using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {834,2,-23,2,103,-5,42,-1,27};

            int minNum = numbers.Min();

            List<string> names = new List<string>
            {
                "Sharon",
                "Charlie",
                "Barbara",
                "Molly",
                "Ashton",
                "Marcellus",
                "Molly",
                "Zeleg",
                "Yvonne",
                "Yoda",
                "Bob"
            };

            // get bob
            int minNameLength = names.Min(p => p.Length);

            var shortestName = names.FirstOrDefault(p => p.Length == minNameLength);



            var Cities = Place.GetCities();

            var texasCities = Cities.Where(city => city.StateCode == "TX");

            // SUM of all texasCities
            texasCities.Sum(ts => ts.Population);

            texasCities.Select(ts => ts.Population).Sum();

            var States = Place.GetStates();

            bool inWashington = Cities.Any(c => c.StateCode == "WA");
            bool allWashington = Cities.All(c => c.StateCode == "WA");

            // ["Seattle, Washington", "Houston, Texas"]
            //                       Set1        Set2
            string[] FullCityNames = Cities.Join(States, 
                // Set1 Key
                (c => c.StateCode),
                // Set 2 Key
                (s => s.StateCode),
                // result selector
                (joinedCity, joinedState) => 
                {
                    return $"{joinedCity.Name}, {joinedState.Name}";
                }).ToArray();

            City[] CitiesWithState = Cities.Join(States, 
                // Set1 Key
                (c => c.StateCode),
                // Set 2 Key
                (s => s.StateCode),
                // result selector
                (joinedCity, joinedState) => 
                {
                    joinedCity.State = joinedState;
                    return joinedCity;
                }).ToArray();



        }
    }
}
