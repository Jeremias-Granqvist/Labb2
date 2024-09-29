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
        //public int playerPositionX;
        //public int playerPositionY;

        public int enemyPositionX;
        public int enemyPositionY;
        
        public void getEnemyPosition(int x, int y)
        {
            this.enemyPositionX = x;
            this.enemyPositionY = y;
        }
        
        //property för x och y, kan användas för att lagra positioner
        //player.position.x
        //snake.position.y

        //metod för att ta in en annan position (pythagoras sats)
    }
}
