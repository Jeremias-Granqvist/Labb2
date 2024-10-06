
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.Elements
{
    class Snake :Enemy
    {
        //ärver från "Enemy"
        //implementerar Update() metod
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(snakeIcon);
        }
        public override void Update(int combatResult)
        {
            HealthPoints = HealthPoints - combatResult;
        }

    }
}
