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
        public Position Position { get; set; }

        public char playerIcon = '@';


        //hårdkoda följande värden
        // Player: HP = 100, AttackDice = 2d6+2, DefenceDice = 2d6+0

        public Player(int x, int y)
        {
            Position = new Position(x, y);

            Console.SetCursorPosition(Position.X, Position.Y);
            Draw();
        }

        public void Draw()
        {
            Console.Write(playerIcon);
        }
    }
}
