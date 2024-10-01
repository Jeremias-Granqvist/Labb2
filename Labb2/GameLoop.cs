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

        public void Collision(int x, int y)
        {
            

        }



        public void MovePlayer()
        {

            int x = player.Position.X;
            int y = player.Position.Y;
            bool isRunning = true;
            do
            {
                keyInput = Console.ReadKey(true);

                int testX = x; //??
                int testY = y; //??

                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:

//                        for (int i = 0; i < LevelData.Elements.Count; i++)
                        {

                        
                        if (true)

                        {
                            //skapa en "testposition", testa den mot positioner i "levelData.Elements", om dom inte existerar breaka
                            //om den existerar, avbryt flyttet.
                            //ev. skapa en bool? skifta värde om den uppfylls och breaka loopen?
                        }
                        }
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        y--;
                        Console.SetCursorPosition(x, y);
                        player.Draw();
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        y++;
                        Console.SetCursorPosition(x, y);
                        player.Draw();
                        break;

                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        x--;
                        Console.SetCursorPosition(x, y);
                        player.Draw();
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        x++;
                        Console.SetCursorPosition(x, y);
                        player.Draw();
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
