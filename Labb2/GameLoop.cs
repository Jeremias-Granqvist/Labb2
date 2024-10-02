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
                            Console.SetCursorPosition(x, y);
                            Console.Write(' ');
                            y--;
                            Console.SetCursorPosition(x, y);
                            player.Draw();
                        }
                        break;

                    case ConsoleKey.DownArrow:

                        if (CollisionDown(x, y) == false)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(' ');
                            y++;
                            Console.SetCursorPosition(x, y);
                            player.Draw();

                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (CollisionLeft(x, y) == false)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(' ');
                            x--;
                            Console.SetCursorPosition(x, y);
                            player.Draw();
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (CollisionRight(x, y) == false)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(' ');
                            x++;
                            Console.SetCursorPosition(x, y);
                            player.Draw();
                        }
                        break;

                    case ConsoleKey.Escape:
                        isRunning = !isRunning;
                        break;
                    default:
                        break;
                }
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
