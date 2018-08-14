using System;

namespace HumanAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Human d = new Human("Devon");
            Human m = new Human("Murphy");
            m.Attack(d);
            m.Attack(d);
            m.Attack(d);
            m.Attack(d);
            m.Attack(d);
            m.Attack(d);
            m.Attack(d);
            m.Attack(d);
            m.Attack(d);
            m.Attack(d);
            System.Console.WriteLine(d.Health);
        }
    }
}
