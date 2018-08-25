using System;
using System.Collections.Generic;

namespace mns
{
    public class Samurai: Human
    {
        public Samurai(string val): base(val)
        {
            health = 200;
        }

        public void Death_Blow(object obj)
        {
            Human enemy = obj as Human;
            base.attack(enemy);
            if(enemy.health < 50)
            {
                enemy.health = 0;
            }
        }

        public void meditate()
        {
            health = 200;
        }

    }
}