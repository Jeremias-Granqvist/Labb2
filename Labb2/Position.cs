using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    struct Position
    {

        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        //property för x och y, kan användas för att lagra positioner
        //player.position.x
        //snake.position.y

        //metod för att ta in en annan position (pythagoras sats)
    }
}
