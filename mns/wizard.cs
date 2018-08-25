using System;
using System.Collections.Generic;

namespace mns
{
    public class Wizard : Human
    {

        public Wizard(string person): base(person)
        {
            health = 50;
            intelligence = 25;
        }

        public void Heal()
        {
            this.health += 10*this.intelligence;
        }

         public void Fireball(object obj)
        {
            Human enemy = obj as Human;
            if(enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                Random rand = new Random();
                enemy.health -= rand.Next(20,50);
            }
        }
    }
}