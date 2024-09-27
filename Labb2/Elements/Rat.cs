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
        //ärver från "Enemy"
        //implementerar Update() metod
        
        public Rat()
        {

        }

        public Rat(int x, int y)
        {
            this.horizontalPosition = x;
            this.verticalPosition = y;
        }

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(ratIcon);
        }
        
    }
}
