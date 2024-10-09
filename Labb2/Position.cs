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

        public double VerticalDistanceTo(Position position) => Math.Abs(position.Y - this.Y);
        public double HorizontalDistanceTo(Position position) => Math.Abs(position.X - this.X);

        public double DistanceTo(Position position, Position positionPlayer)
        {
            
            return Math.Sqrt(Math.Pow(position.X - positionPlayer.X, 2) + Math.Pow(position.Y - positionPlayer.Y, 2));
        }

        //metod för att ta in en annan position (pythagoras sats)
    }
}
