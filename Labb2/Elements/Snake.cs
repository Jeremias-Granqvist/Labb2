
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.Elements
{
    class Snake :Enemy
    {
        public char snakeIcon = 's';
        public Snake()
        {
        }
        public Snake(int x, int y)
        {
            Position = new Position(x, y);
            this.Name = snakeIcon;
            this.HealthPoints = 25;
            this.NumOfAtkDice = 3;
            this.SideOfAtkDice = 4;
            this.AtkModifier = 2;
            this.NumOfDefDice = 1;
            this.SideOfDefDice = 8;
            this.DefModifier = 3;
        }
        public override void Draw()
        {
            if (IsVisible)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(snakeIcon);
            }
            else
            {
                Console.Write(' ');
            }
        }
        public override void CombatUpdate(int combatResult)
        {
            HealthPoints = HealthPoints - combatResult;
        }

        public override void Replace(char icon)
        {
            throw new NotImplementedException();
        }

        public override void Update(LevelElement element, int x, int y)
        {

        }
    }
}
