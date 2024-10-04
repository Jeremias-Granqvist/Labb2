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

        public Position(Position position) : this(position.X, position.Y)
        {
        }
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int VerticalDistanceTo(Position position) => Math.Abs(position.X - this.X);
        public int HorizontalDistanceTo(Position position) => Math.Abs(position.Y - this.Y);

        //public double DistanceTo(Position position)
        //{
        //    return (VerticalDistanceTo - HorizontalDistanceTo);
        //}

        //property för x och y, kan användas för att lagra positioner
        //player.position.x
        //snake.position.y

        //metod för att ta in en annan position (pythagoras sats)
    }
}
