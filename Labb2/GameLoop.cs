using Labb2.Elements;
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
            foreach (var element in levelData.Elements)
            {
                if (element is Player)
                {
                    player = (Player)element;
                }
            }
        }
        public bool CollisionUp(int x, int y)
        {
            int testpositionX = x;
            int testpositionY = y;
            for (int i = 0; i < _levelData.Elements.Count; i++)
            {
                if (testpositionX == _levelData.Elements[i].horizontalPosition && testpositionY - 1 == _levelData.Elements[i].verticalPosition)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CollisionDown(int x, int y)
        {
            int testpositionX = x;
            int testpositionY = y;
            for (int i = 0; i < _levelData.Elements.Count; i++)
            {
                if (testpositionX == _levelData.Elements[i].horizontalPosition && testpositionY + 1 == _levelData.Elements[i].verticalPosition)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CollisionLeft(int x, int y)
        {
            int testpositionX = x;
            int testpositionY = y;
            for (int i = 0; i < _levelData.Elements.Count; i++)
            {
                if (testpositionX - 1 == _levelData.Elements[i].horizontalPosition && testpositionY == _levelData.Elements[i].verticalPosition)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CollisionRight(int x, int y)
        {
            int testpositionX = x;
            int testpositionY = y;
            for (int i = 0; i < _levelData.Elements.Count; i++)
            {
                if (testpositionX + 1 == _levelData.Elements[i].horizontalPosition && testpositionY == _levelData.Elements[i].verticalPosition)
                {
                    return true;
                }
            }
            return false;
        }

        public int MoveEnemyUp(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            y--;
            Console.SetCursorPosition(x, y);
            return y;
        }           // av någon anledning så duplicerar sig karaktärerna här ibland
        public int MoveEnemyDown(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            y++;
            Console.SetCursorPosition(x, y);
            return y;
        }           // av någon anledning så duplicerar sig karaktärerna här ibland
        public int MoveEnemyRight(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            x++;
            Console.SetCursorPosition(x, y);
            return x;
        }           // av någon anledning så duplicerar sig karaktärerna här ibland
        public int MoveEnemyLeft(int x, int y)              // av någon anledning så duplicerar sig karaktärerna här ibland
        {

            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            x--;
            Console.SetCursorPosition(x, y);
            return x;
        }

        public void EnemyMovement(int x, int y)
        {
            foreach (var element in _levelData.Elements)
            {
                if (element is Wall)
                {
                    continue;
                }
                if (element is Rat)
                {
                    Dice dice = new Dice();
                    if (dice.DiceResult == 1 && CollisionUp(element.horizontalPosition, element.verticalPosition) == false)
                    {
                        //MoveEnemyUp(element.horizontalPosition, element.verticalPosition);
                        //element.verticalPosition = y;
                        Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                        Console.Write(' ');
                        element.verticalPosition--;
                        Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                        
                        element.Draw();
                    }
                    else if (dice.DiceResult == 2 && CollisionRight(element.horizontalPosition, element.verticalPosition) == false)
                    {
                        //MoveEnemyRight(element.horizontalPosition, element.verticalPosition);
                        //element.horizontalPosition = x;
                        Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                        Console.Write(' ');
                        element.horizontalPosition++;
                        Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                       
                        element.Draw();
                    }
                    else if (dice.DiceResult == 3 && CollisionDown(element.horizontalPosition, element.verticalPosition) == false)
                    {
                        //MoveEnemyDown(element.horizontalPosition, element.verticalPosition);
                        //element.verticalPosition = y;

                        Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                        Console.Write(' ');
                        element.verticalPosition++;
                        Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                        element.Draw();
                    }
                    else if (dice.DiceResult == 4 && CollisionLeft(element.horizontalPosition, element.verticalPosition) == false)
                    {
                        //MoveEnemyLeft(element.horizontalPosition, element.verticalPosition);
                        //element.horizontalPosition = x;

                        Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                        Console.Write(' ');
                        element.horizontalPosition--;
                        Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                        element.Draw();
                    }
                }
                if (element is Snake)
                {
                    if (Math.Abs(x - element.horizontalPosition) + Math.Abs(y - element.verticalPosition) <= 2)
                    {
                        if (y > element.verticalPosition)
                        {
                            if (CollisionUp(element.horizontalPosition, element.verticalPosition) == false)
                            {
                                Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                                Console.Write(' ');
                                element.verticalPosition++;
                                Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                                element.Draw();
                            }
                        }
                        else if (x < element.horizontalPosition)
                        {
                            if (CollisionRight(element.horizontalPosition, element.verticalPosition) == false)
                            {
                                Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                                Console.Write(' ');
                                element.horizontalPosition++;
                                Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                                element.Draw();
                            }
                        }
                        else if (y < element.verticalPosition)
                        {
                            if (CollisionDown(element.horizontalPosition, element.horizontalPosition) == false)
                            {
                                Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                                Console.Write(' ');
                                element.verticalPosition++;
                                Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                                element.Draw();
                            }
                        }
                        else if (x > element.horizontalPosition)
                        {
                            if (CollisionLeft(element.horizontalPosition, element.verticalPosition) == false)
                            {
                                Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                                Console.Write(' ');
                                element.horizontalPosition--;
                                Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
                                element.Draw();
                            }
                        }


                    }
                }
            }
        }

        public int MovePlayerUp(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            y--;
            Console.SetCursorPosition(x, y);
            return y;
        }
        public int MovePlayerDown(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            y++;
            Console.SetCursorPosition(x, y);
            return y;
        }
        public int MovePlayerRight(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            x++;
            Console.SetCursorPosition(x, y);
            return x;
        }
        public int MovePlayerLeft(int x, int y)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            x--;
            Console.SetCursorPosition(x, y);
            return x;
        }


        public void MovePlayer()
        {

            int x = player.Position.X;
            int y = player.Position.Y;
            bool isRunning = true;
            do
            {
                player.horizontalPosition = x;
                player.verticalPosition = y;
                keyInput = Console.ReadKey(true);

                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (CollisionUp(x, y) == false)
                        {
                            MovePlayerUp(x, y);
                            y = MovePlayerUp(x, y);
                            player.Draw();
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (CollisionDown(x, y) == false)
                        {
                            MovePlayerDown(x, y);
                            y = MovePlayerDown(x, y);
                            player.Draw();
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (CollisionLeft(x, y) == false)
                        {
                            MovePlayerLeft(x, y);
                            x = MovePlayerLeft(x, y);
                            player.Draw();
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (CollisionRight(x, y) == false)
                        {
                            MovePlayerRight(x, y);
                            x = MovePlayerRight(x, y);
                            player.Draw();
                        }
                        break;

                    case ConsoleKey.Escape:
                        isRunning = !isRunning;
                        break;
                    default:
                        break;
                }

                EnemyMovement(x, y);

            } while (isRunning);
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
