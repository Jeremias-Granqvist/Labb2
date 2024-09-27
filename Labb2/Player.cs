using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Labb2
{
    class Player
    {

        public char playerIcon = '@';
        
        //hårdkoda följande värden
        // Player: HP = 100, AttackDice = 2d6+2, DefenceDice = 2d6+0

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(playerIcon);
        }
    }
}
