using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPAbstractions
{
    class Program
    {
        static void Main(string[] args)
        {
            IMovable[] moveables1 = new IMovable[]
            {
                new Car(5, 65), new Car(2, 140), new Motorcycle(), new Person()
            };

            List<IMovable> otherMovables = new List<IMovable>
            {
                new Motorcycle(), new Person(), new Pencil()
            };

            IMovable winner1 = Race(moveables1);
            IMovable winner2 = Race(otherMovables);

            
        }
        static void IterateVehicles(Vehicle[] vls)
        {
            foreach(Vehicle v in vls)
            {
                v.Move(5);
            }
        }

        static IMovable Race(IEnumerable<IMovable> movables)
        {
            foreach(IMovable m in movables)
            {
                m.Move(5);
            }

            IMovable furthest = movables.First();
            foreach(IMovable m in movables)
            {
                if(m.DistanceTraveled > furthest.DistanceTraveled)
                    furthest = m;
            }

            return furthest;
        }

    }

}
