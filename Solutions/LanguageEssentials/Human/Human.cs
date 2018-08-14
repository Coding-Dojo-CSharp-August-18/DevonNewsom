namespace HumanAssignment
{
    class Human
    {
        string k_name;
        int k_strength;
        int k_intelligence;
        int k_dexterity;
        int k_health;

        public Human(string n)
        {
            k_name = n;
            k_strength = 3; 
            k_dexterity = 3; 
            k_intelligence = 3;
            k_health = 100;
        }
        public Human(string name, int strength, int intelligence, int dexterity, int health)
        {
            k_name = name;
            k_intelligence = intelligence;
            k_strength = strength;
            k_dexterity = dexterity;
            k_health = health;
        }

        // +++++++++++++++++++++++++++
        // CLASS PROPERTIES
        // +++++++++++++++++++++++++++
        public string Name 
        { 
            get { return this.k_name; }
            set { this.k_name = value; } 
        }
        public int Strength 
        { 
            get { return this.k_strength; }
            set { this.k_strength = value; }
        }
        public int Intelligence
        {
            get { return this.k_intelligence; }
            set { this.k_intelligence = value; }
        }
        public int Dexterity
        {
            get { return this.k_dexterity; }
            set { this.k_dexterity = value; }
        }
        public int Health 
        { 
            get { return this.k_health; }
            set { this.k_health = value; }
        }


        // +++++++++++++++++++++++++++
        // CLASS METHODS
        // +++++++++++++++++++++++++++
        public void Attack(Human target)
        {
            int dmg = this.k_strength * 5;
            target.k_health -= dmg;
            if(target.k_health <= 0)
            {
                System.Console.WriteLine("YOU KILLED {0}", target.k_name);
            }
        }
    }
}