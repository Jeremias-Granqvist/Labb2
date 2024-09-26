using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.Elements
{
    class Wall : LevelElement
    {
        //hårdkoda färg "grå"
        //hårdkoda tecken för "wall" #

        public char wall = '#';
        ConsoleColor wallColor = ConsoleColor.Gray;
    }
}
