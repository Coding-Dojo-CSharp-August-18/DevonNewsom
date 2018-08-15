using System;

namespace GameFun
{
    public abstract class Unit : IDamageable
    {
        public static int DefaultHealth = 100;
        public int Health {get;set;}
        public abstract string Name {get;set;}
        public abstract void SayName();
        public bool TakeDamage(int dmg)
        {
            // reduce until 0, return true dead
            int resultingHealth = Health -= dmg;

            if(resultingHealth <= 0)
            {
                Health = 0;
                return true;
            }
            Health = resultingHealth;
            return false;
        }
        public Unit(int health)
        {
            Health = health;
        }
        public Unit()
        {
            Health = DefaultHealth;
        }

        // returns true if target is destroyed
        public bool Attack(IDamageable target)
        {
            return target.TakeDamage(10);
        }

        // method overload for attacl
        public bool Attack(IDamageable target, int amtDmg)
        {
            return target.TakeDamage(amtDmg);
        }
    }
    public class Melee : Unit
    {
        public static int DefaultHealth = 150;
        public override string Name {get;set;}
        public override void SayName()
        {
            Console.WriteLine(Name);
        }
        public Melee() : base(DefaultHealth){}

    }
    public class Building : IDamageable
    {
        public Building()
        {
            // 50% chance of having shields

            Random rand = new Random();
            ShieldsActive = (rand.Next(2) == 1);
            Health = 300;
        }
        public int Health {get;set;}
        public bool ShieldsActive {get;set;}
        public bool TakeDamage(int dmg)
        {
            //  variable           expression                       
            int resultingHealth = (ShieldsActive) 
                // if true
                ? Health -= (int)dmg/2
                // if false
                : Health -= dmg;
            
            Health = resultingHealth;

            return (Health == 0);
        }
    }

    public class Bunny : IDamageable
    {
        public int Health {get;set;} = 1000;
        public bool TakeDamage(int dmg)
        {
            Health -= dmg;
            Console.WriteLine("OH NO IM A BUNNY TAKING DAMAGE!");
            return Health <= 0;
        }
    }
}