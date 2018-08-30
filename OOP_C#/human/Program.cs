using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Human human1 = new Human("Joe");
            Console.WriteLine("Human: {0}, strength: {1}, intelligence: {2}, dexterity: {3}, health: {4}", human1.name, human1.strength, human1.intelligence, human1.dexterity, human1.health);

            Human new_constructor = new Human("jef", 2, 2, 1, 85);
            Console.WriteLine("Human: {0}, strength: {1}, intelligence: {2}, dexterity: {3}, health: {4}", new_constructor.name, new_constructor.strength, new_constructor.intelligence, new_constructor.dexterity, new_constructor.health);


            human1.Attack(new_constructor);
            Console.WriteLine("Human: {0}, strength: {1}, intelligence: {2}, dexterity: {3}, health: {4}", new_constructor.name, new_constructor.strength, new_constructor.intelligence, new_constructor.dexterity, new_constructor.health);

        }
    }
}
