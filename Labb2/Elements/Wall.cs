using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Labb2.Elements
{
    class Wall : LevelElement
    {
        //hårdkoda färg "grå"
        //hårdkoda tecken för "wall" #

        public char wallIcon = '#';
        
        public Wall()
        {

        }
        public Wall(int x, int y)
        {
            this.horizontalPosition = x;
            this.verticalPosition = y;
        }



        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(wallIcon);
        }
    }
}
