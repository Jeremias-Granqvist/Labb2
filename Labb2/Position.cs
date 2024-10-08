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

        public int VerticalDistanceTo(Position position) => Math.Abs(position.Y - this.Y);
        public int HorizontalDistanceTo(Position position) => Math.Abs(position.X - this.X);

        public bool DistanceTo(Position position)
        {
            if (VerticalDistanceTo(position) <= 5 && HorizontalDistanceTo(position) <= 5)
            {
                return true;
            }
            return false;                   // måste inte läsa in hela filen? bara läsa in baserat på true/false? 
        }

        //metod för att ta in en annan position (pythagoras sats)
    }
}
