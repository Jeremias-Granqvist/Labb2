using Labb2.Elements;

namespace Labb2
{


    class LevelData
    {
        private List<LevelElement> elements = new List<LevelElement>();
        public string Elements { get; private set; }

        //private field "elements" som ska vara en "List<LevelElements>"

        //ska exponeras som en public readonly property "elements"

        //metod "Load(string filename)" som ska läsa in Level1.txt
        //ska läsa igenom filen och anropa rätt klass och instansera den när den stöter på ett tecken (# wall,@ player, s snake, r rat)
        //ska också referera "elements" listan för att spara värdet samt position på tecknet.
        //när filen är inläst ska det finnas en instans för varje tecken i "elements listan" 
        //behöver hålla koll på position på varje tecken.

        //när Load har körts borde "Draw()" kunna hämta från "elements"-listan för att rita upp hela leveln med hjälp av en foreach-loop.

        public void Load(string filename)
        {
            StreamReader lvlData = new StreamReader("C:\\Users\\Taros\\source\\repos\\Labb2\\Labb2\\Levels\\Level1.txt");
            
            char currentObject = (char)lvlData.Read();

            while (lvlData.EndOfStream == false)
            {
                if (currentObject == '#')
                {
                    Wall wall1 = new Wall();
                    wall1.WallColor();
                }
                if (currentObject == 's')
                {
                    Snake snake1 = new Snake();
                    snake1.snakeColor();
                }
                if (currentObject == 'r')
                {
                    Rat rat1 = new Rat();
                    rat1.ratColor();
                }
                if (currentObject == '@')
                {
                    Player player1 = new Player();
                    player1.playerColor();
                } 

                Console.Write(currentObject);
                currentObject = (char)lvlData.Read();
                Console.ResetColor();
            }
            lvlData.Close();
            //Console.ReadLine();
        }

    }
}
