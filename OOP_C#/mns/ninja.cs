using System;
using System.Collections.Generic;

namespace mns
{
    public class Ninja: Human
    {

        public Ninja(string val): base(val)
        {
            dexterity = 175;
        }

        public void Steal(object obj)
        {
            Human enemy = obj as Human;
            base.attack(enemy);
            this.health += 10;

        }

        public void Get_Away()
        {
            this.health -= 15;
        }
    }
}