using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Labb2
{
    class GameLoop
    {
        private LevelData _levelData;

        public Position Position { get; set; }
        ConsoleKeyInfo keyInput;

        Player player;


        public GameLoop(LevelData levelData)
        {
            _levelData = levelData;


            //iterera min elements loop, när jag hittar min spelare, assigna till fältet player och return.
            foreach (var element in levelData.Elements)
            {
                if (element is Player)
                {
                    player = (Player)element;
                }    
            }

        }

        

        public void MovePlayer()
        {
            do
            {
                player.Position = Position;

                keyInput = Console.ReadKey(true);

                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(player.Position.X, player.Position.Y);
                        Console.Write(' ');

                        player.Position.Y--;
                        Console.SetCursorPosition(player.Position.X, player.Position.Y);
                        player.Draw();

                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(player.Position.X, player.Position.Y);
                        Console.Write(' ');

                        player.Position.Y++;
                        Console.SetCursorPosition(player.Position.X, player.Position.Y);
                        player.Draw();
                        break;

                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(player.Position.X, player.Position.Y);
                        Console.Write(' ');

                        player.Position.X--;
                        Console.SetCursorPosition(player.Position.X, player.Position.Y);
                        player.Draw();
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(player.Position.X, player.Position.Y);
                        Console.Write(' ');

                        player.Position.X++;
                        Console.SetCursorPosition(player.Position.X, player.Position.Y);
                        player.Draw();
                        break;

                    default:
                        break;
                }
            } while (true);
        }




        //gameloop: varje gång man trycker en tangent genomförs en ny iteration av loopen.

        //utför spelarens drag (flytta/attackera)
        //se om det är möjligt att gå dit, eller om det är blockerat.

        //om det är blockerat av "Wall" flytta inte, attackera inte.
        //om det är blockerat av "Enemy" flytta inte, attackera.
        //om man blev attackerad förra rundan, attackera tillbaka direkt.
        //behåll ursprungsposition. 

        //utför fiendens drag  (flytta/attackera)
        //om det är blockerat av "Wall" flytta inte, attackera inte.
        //om det är blockerat av "Enemy" flytta inte, attackera inte.
        //om det är blockerat av "Player" flytta inte, attackera.
        //om den blev attackerad förra rundan, attackera tillbaka.

        //om attack sker, räkna ut skada och uppdatera värden.
        
    }
}
