using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.Elements
{
    abstract class Enemy : LevelElement
    {
        public char Name { get; set; }
        public int HealthPoints { get; set; }
        public int NumOfAtkDice { get; set; }
        public int NumOfDefDice { get; set; }
        public int SideOfDice { get; set; }
        public int SideOfAtkDice { get; set; }
        public int SideOfDefDice { get; set; }
        public int AtkModifier { get; set; }
        public int DefModifier { get; set; }
        //abstract "Update()"

        public override void Replace(char icon)
        {
        }
        public abstract void CombatUpdate(int combatResult);
        public override void Update(LevelElement element, int x, int y)
        {

        }
    }

}
