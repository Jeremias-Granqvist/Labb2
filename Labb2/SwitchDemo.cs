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
        //      annat test för att flytta rad 98 och framåt i gameloop
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
                "down" => () => pl.CombatUpdate(2),
                "up" => () => pl.CombatUpdate(3),
                "left" => () => något(pl),
                "hej" => () => hej(input),
                _ => () => pl.CombatUpdate(4)
            };

            nextMove();
        }

        void något(Player pl)
        {
            if (true)
            {
                pl.CombatUpdate(7);
            }
            
        }
        void hej(string h)
        {

        }


        
    }
        

    
}
