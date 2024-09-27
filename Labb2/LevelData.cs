using Labb2.Elements;

namespace Labb2
{       
    //private field "elements" som ska vara en "List<LevelElements>"

    //ska exponeras som en public readonly property "elements"

    //metod "Load(string filename)" som ska läsa in Level1.txt
    //ska läsa igenom filen och anropa rätt klass och instansera den när den stöter på ett tecken (# wall,@ player, s snake, r rat)
    //ska också referera "elements" listan för att spara värdet samt position på tecknet.
    //när filen är inläst ska det finnas en instans för varje tecken i "elements listan" 
    //behöver hålla koll på position på varje tecken.

    //när Load har körts borde "Draw()" kunna hämta från "elements"-listan för att rita upp hela leveln med hjälp av en foreach-loop.


    class LevelData
    {
        private List<LevelElement> elements = new List<LevelElement>();
        public LevelElement Elements_ { get; private set; }

        char currentObject;
        public void Load(string filename)
        {
            string path = Directory.GetCurrentDirectory();
            StreamReader lvlData = new StreamReader($"{path}\\Levels\\Level1.txt");

            currentObject = (char)lvlData.Read();

            while (lvlData.EndOfStream == false)
            {
                if (currentObject == '#')
                {
                    Wall wall1 = new Wall();
                    wall1.Draw();
                    Elements();
                }
                if (currentObject == 's')
                {
                    Snake snake1 = new Snake();
                    snake1.Draw();
                    Elements();
                }
                if (currentObject == 'r')
                {
                    Rat rat1 = new Rat();
                    rat1.Draw();
                    Elements();
                }
                if (currentObject == '@')
                {
                    Player player1 = new Player();
                    player1.playerColor();
                    Elements();
                }
                Console.Write(currentObject);

                currentObject = (char)lvlData.Read();
                Console.ResetColor();
            }
            lvlData.Close();
        }
        public void Elements()
        {
            Elements_ = currentObject;
            elements.Add(Elements_);
        }
    }
}
