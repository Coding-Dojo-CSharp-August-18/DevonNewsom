using System;
using System.Collections.Generic;

namespace GameFun
{
    class Program
    {
        static void Main(string[] args)
        {
            IDamageable[] targets = new IDamageable[]
            {   
                new Melee(), new Melee(), new Building(), new Building()
            };

            Melee thingOne = new Melee();
            Melee thingTwo = new Melee();

            thingOne.Attack(thingTwo);
            thingOne.Attack(thingTwo, 100);
    
            DamageMany(targets, 10);
        }
        static void DamageMany(IEnumerable<IDamageable> thingsToDamage, int damageTaken)
        {
            foreach(IDamageable thing in thingsToDamage)
                thing.TakeDamage(damageTaken);
        }
    }
}
