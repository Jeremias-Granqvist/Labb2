using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    class GameLoop
    {

        public Position Position { get; set; }
        ConsoleKeyInfo keyInput;


        public void MovePlayer()
        {
            do
            {
                int horizontalPosition = Position.X;
                int verticalPosition = Position.Y;
                keyInput = Console.ReadKey(true);

                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(horizontalPosition, verticalPosition);
                        Console.Write(' ');
                        verticalPosition--;
                        Console.SetCursorPosition(Position.X, Position.Y);
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(Position.X, Position.Y);
                        Console.Write(' ');
                        verticalPosition++;
                        Console.SetCursorPosition(Position.X, Position.Y);

                        break;
         
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(Position.X, Position.Y);
                        Console.Write(' ');
                        horizontalPosition--;
                        Console.SetCursorPosition(Position.X, Position.Y);

                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(Position.X, Position.Y);
                        Console.Write(' ');
                        horizontalPosition++;
                        Console.SetCursorPosition(horizontalPosition, verticalPosition);
                        
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
        public GameLoop()
        {
        }
    }
}
