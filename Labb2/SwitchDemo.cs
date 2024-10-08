using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Labb2
{
    public class SwitchDemo
    {

        //
        //
        //
        //      exempel för rad 98 i gameloop (enemy is Rat)
        //
        //
        //
        //

        public void GameLoop(string input)
        {
            Player pl = new Player(2, 2);

            Action nextMove = input switch
            {
                "down" => () => pl.Update(2),
                "up" => () => pl.Update(3),
                "left" => () => något(pl),
                "hej" => () => hej(input),
                _ => () => pl.Update(4)
            };

            nextMove();
        }

        void något(Player pl)
        {
            if (true)
            {
                pl.Update(7);
            }
            
        }
        void hej(string h)
        {

        }


        
    }
        

    
}
