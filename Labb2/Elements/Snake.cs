
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.Elements
{
    class Snake :Enemy
    {
        //ärver från "Enemy"
        //implementerar Update() metod
        public char snakeIcon = 's';

        public Snake()
        {

        }

        public Snake(int x, int y)
        {
            this.horizontalPosition = x;
            this.verticalPosition = y;
        }

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(snakeIcon);
        }
    }
}
