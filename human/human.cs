namespace human
{
    public class Human
    {
        public string name;
        public int strength;
        public int intelligence;
        public int dexterity;
        public int health;
        public Human(string val)
        {
            name = val;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;

        }
        public Human(string name, int str, int intell, int dex, int hlth)
        {
            name = name;
            strength = str;
            intelligence = intell;
            dexterity = dex;
            health = hlth;

        }
        public void Attack(Human user)
        {
            user.health -= 5*strength;
        }


    }
}