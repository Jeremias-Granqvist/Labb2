using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.Elements
{
    internal class Rat : Enemy
    {
        public char ratIcon = 'r';

        public Rat()
        {
        }
        public Rat(int x, int y)
        {

            Position = new Position(x, y);

        }
        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(ratIcon);
            Console.ResetColor();
        }
    }
}
