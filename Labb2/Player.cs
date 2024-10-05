using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Labb2
{
    class Player : LevelElement
    {

        public char playerIcon = '@';
        // Player: HP = 100, AttackDice = 2d6+2, DefenceDice = 2d6+0
        public int HealthPoints { get; set; }
        public int NumOfDice { get; set; }
        public int SideOfDice { get; set; }
        public int AtkModifier { get; set; }
        public int DefModifier { get; set; }
        public Player(int x, int y)
        {
            Position = new Position(x, y);
            HealthPoints = 100;
            NumOfDice = 2;
            SideOfDice = 6;
            AtkModifier = 2;
            DefModifier = 0;

            Console.SetCursorPosition(Position.X, Position.Y);
            Draw();
        }


        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(playerIcon);
            Console.ResetColor();
        }
    }
}
