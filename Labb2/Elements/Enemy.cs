using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.Elements
{
    abstract class Enemy : LevelElement
    {
        //property för "name", "health", "atkDice" (hämtas från Dice), "defDice" (hämtas från Dice)
        public string name { get; set; }
        public int health { get; set; }

        public int attackDice { get; set; }
        public int defenseDice { get; set; }

        //abstract "Update()"

    }
}
