using System;

namespace mns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Human human1 = new Human("Alex");
            Console.WriteLine(human1.name);
            Human human2 = new Human("Tim");
            Console.WriteLine(human2.name);
            Human human3 = new Human("TEST");
            Console.WriteLine(human3.name);
            Wizard wizard1 = new Wizard("Kevin");
            Console.WriteLine(wizard1.name);
            Wizard wizard2 = new Wizard("Tony");
            Console.WriteLine(wizard2.name);
            Ninja ninja1 = new Ninja("Alex");
            Console.WriteLine(ninja1.name);
            Ninja ninja2 = new Ninja("Vlad");
            Console.WriteLine(ninja2.name);
            Samurai samurai1 = new Samurai("Andrew");
            Console.WriteLine(samurai1.name);
            Samurai samurai2 = new Samurai("Philip");
            Console.WriteLine(samurai2.name);




            Console.WriteLine("*******************************");
            wizard1.Fireball(human1);
            Console.WriteLine(human1.health);
            Console.WriteLine("*******************************");
            wizard1.Fireball(wizard2);
            Console.WriteLine(wizard2.health);
            Console.WriteLine(human1.health);
            Console.WriteLine("*******************************");
            wizard2.Fireball(human2);
            Console.WriteLine(human2.health);
            Console.WriteLine(human1.health);
            Console.WriteLine(wizard2.health);
            Console.WriteLine("*******************************");
            wizard2.Fireball(wizard1);
            Console.WriteLine(wizard1.health);
            Console.WriteLine(human1.health);
            Console.WriteLine(wizard2.health);
            Console.WriteLine(human2.health);
            Console.WriteLine("*******************************");
            Console.WriteLine("*******************************");
            Console.WriteLine("*******************************");


            ninja1.Steal(human3);
            Console.WriteLine(ninja1.health);
            Console.WriteLine(human3.health);
            Console.WriteLine("*******************************");
            ninja1.Steal(human1);
            Console.WriteLine(ninja1.health);
            Console.WriteLine(human1.health);
            Console.WriteLine("*******************************");
            ninja2.Steal(wizard2);
            Console.WriteLine(ninja2.health);
            Console.WriteLine(wizard2.health);
            Console.WriteLine("*******************************");
            Console.WriteLine("*******************************");
            Console.WriteLine("*******************************");

            ninja1.Get_Away();
            Console.WriteLine(ninja1.health);
            Console.WriteLine(ninja2.health);

            Console.WriteLine("*******************************");

            ninja1.Get_Away();
            Console.WriteLine(ninja1.health);

            Console.WriteLine("*******************************");

            ninja1.Get_Away();
            Console.WriteLine(ninja1.health);
            Console.WriteLine("*******************************");
            Console.WriteLine("*******************************");
            Console.WriteLine("*******************************");

            Console.WriteLine(ninja1.health);
            samurai1.Death_Blow(ninja1);
            Console.WriteLine(ninja1.health);
            Console.WriteLine("*******************************");

            Console.WriteLine(ninja1.health);
            samurai1.Death_Blow(ninja1);
            Console.WriteLine(ninja1.health);
            Console.WriteLine("*******************************");

            Console.WriteLine(wizard1.health);
            samurai2.Death_Blow(wizard1);
            Console.WriteLine(wizard1.health);
            Console.WriteLine("*******************************");

            wizard1.Fireball(samurai1);
            Console.WriteLine(samurai1.health);
            Console.WriteLine("*******************************");
            samurai1.meditate();
            Console.WriteLine(samurai1.health);

        }
    }
}
