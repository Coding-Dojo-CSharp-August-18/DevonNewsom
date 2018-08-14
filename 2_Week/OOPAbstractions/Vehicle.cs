using System;

namespace OOPAbstractions
{
    // Behavior
    public interface IMovable
    {
        int DistanceTraveled {get;set;}
        void Move(int duration);
    }

    public interface IDamageable
    {
        void TakeDamamge(int dmg);
        int Health {get;set;}
    }
    public abstract class Vehicle : IMovable
    {
        public int DistanceTraveled {get;set;} = 0;
        public int MaxPassengers;
        public double Speed;
        

        //Virtual: CAN be overridden
        public virtual void MakeNoise()
        {
            Console.WriteLine("Beep");
        }

        //Abstract: MUST be overriden
        public abstract void Move(int duration);
    }

    public class Car : Vehicle, IMovable
    {
        
        public Car(int masPass, double speed)
        {
            MaxPassengers = masPass;
            Speed = speed;
            DistanceTraveled = 0;
        }
        public override void MakeNoise()
        {
            Console.WriteLine("Honk!");
        }
        public override void Move(int duration)
        {
            MakeNoise();
            DistanceTraveled += (int)((duration) * Speed);
        }
    }

    public class Motorcycle : Vehicle
    {
        public override void Move(int duration)
        {
            DistanceTraveled += (int)(duration * (Speed * 2));
        }
        public Motorcycle()
        {
            MaxPassengers = 2;
            Speed = 100;
        }

    }

    public class Person : IMovable
    {
        public int DistanceTraveled {get;set;}
        public void Move(int duration)
        {
            for(int i = 0; i < duration; i++)
                DistanceTraveled += 1;
        }
    }

    public class Pencil : IMovable
    {
        public int DistanceTraveled {get;set;}
        public void Move(int duration)
        {

        }
    }
}