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
                if (testpositionX == _levelData.Elements[i].Position.X && testpositionY - 1 == _levelData.Elements[i].Position.Y)
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
                if (testpositionX == _levelData.Elements[i].Position.X && testpositionY + 1 == _levelData.Elements[i].Position.Y)
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
                if (testpositionX - 1 == _levelData.Elements[i].Position.X && testpositionY == _levelData.Elements[i].Position.Y)
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
                if (testpositionX + 1 == _levelData.Elements[i].Position.X && testpositionY == _levelData.Elements[i].Position.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public int MoveEnemyUp(LevelElement element, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            element.Position = new Position(element.Position.X, element.Position.Y - 1);
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            return element.Position.Y;
        }
        public int MoveEnemyDown(LevelElement element, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            element.Position = new Position(element.Position.X, element.Position.Y + 1);
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            return element.Position.Y;
        }          
        public int MoveEnemyRight(LevelElement element, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            element.Position = new Position(element.Position.X + 1, element.Position.Y);
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            return element.Position.X;
        }           
        public int MoveEnemyLeft(LevelElement element, int x, int y)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            element.Position = new Position(element.Position.X - 1, element.Position.Y);
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            return element.Position.X;
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
                    if (dice.DiceResult == 1 && CollisionUp(element.Position.X, element.Position.Y) == false && !(element.Position.X == x && element.Position.Y - 1 == y))
                    {
                        y = MoveEnemyUp(element, element.Position.X, element.Position.Y);
                        element.Draw();
                    }
                    else if (dice.DiceResult == 2 && CollisionRight(element.Position.X, element.Position.Y) == false && !(element.Position.X + 1 == x && element.Position.Y == y))
                    {
                        x = MoveEnemyRight(element, element.Position.X, element.Position.Y);
                        element.Draw();
                    }
                    else if (dice.DiceResult == 3 && CollisionDown(element.Position.X, element.Position.Y) == false && !(element.Position.X == x && element.Position.Y + 1 == y))
                    {
                        y = MoveEnemyDown(element, element.Position.X, element.Position.Y);
                        element.Draw();
                    }
                    else if (dice.DiceResult == 4 && CollisionLeft(element.Position.X, element.Position.Y) == false && !(element.Position.X == x -1 && element.Position.Y == y))
                    {
                        x = MoveEnemyLeft(element, element.Position.X, element.Position.Y);
                        element.Draw();
                    }
                }
                if (element is Snake)
                {
                    if (Math.Abs(player.Position.X - element.Position.X) + Math.Abs(player.Position.Y - element.Position.Y) <= 2)
                    {
                        if (player.Position.Y > element.Position.Y)
                        {
                            if (CollisionUp(element.Position.X, element.Position.Y) == false)
                            {
                                y = MoveEnemyUp(element, element.Position.X, element.Position.Y);
                                element.Draw();
                            }
                        }
                        else if (player.Position.X < element.Position.X)
                        {
                            if (CollisionRight(element.Position.X, element.Position.Y) == false)
                            {
                                x = MoveEnemyRight(element, element.Position.X, element.Position.Y);
                                element.Draw();
                            }
                        }
                        else if (player.Position.Y < element.Position.Y)
                        {
                            if (CollisionDown(element.Position.X, element.Position.Y) == false)
                            {
                                y = MoveEnemyDown(element, element.Position.X, element.Position.Y);
                                element.Draw();
                            }
                        }
                        else if (x > element.Position.X)
                        {
                            if (CollisionLeft(element.Position.X, element.Position.Y) == false)
                            {
                                x = MoveEnemyLeft(element, element.Position.X, element.Position.Y);
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
            player.Position = new Position(player.Position.X, player.Position.Y-1);
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            return player.Position.Y;
        }
        public int MovePlayerDown(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            player.Position = new Position(player.Position.X, player.Position.Y+1);
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            return player.Position.Y;
        }
        public int MovePlayerRight(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            player.Position = new Position(player.Position.X + 1, player.Position.Y);
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            return player.Position.X;
        }
        public int MovePlayerLeft(int x, int y)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            player.Position = new Position(player.Position.X - 1, player.Position.Y);
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            return player.Position.X;
        }


        public void MovePlayer()
        {
            
            int x = player.Position.X;
            int y = player.Position.Y;
            bool isRunning = true;
            do
            {
                keyInput = Console.ReadKey(true);

                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (CollisionUp(x, y) == false)
                        {
                            y = MovePlayerUp(x, y);
                            player.Draw();

                        }                   // börja koda in vad jag krockar med om collision är false här, uppdatera med metoder allt eftersom och kalla dice från respektive klass
                        break;

                    case ConsoleKey.DownArrow:
                        if (CollisionDown(x, y) == false)
                        {
                            y = MovePlayerDown(x, y);
                            player.Draw();
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (CollisionLeft(x, y) == false)
                        {
                            x = MovePlayerLeft(x, y);
                            player.Draw();
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (CollisionRight(x, y) == false)
                        {
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
