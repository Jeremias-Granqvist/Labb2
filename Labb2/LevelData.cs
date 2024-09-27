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
        private List<LevelElement> _elements = new List<LevelElement>();
        public List<LevelElement> Elements { get { return _elements; } }

        char currentObject;
        public void Load(string filename)
        {
            string path = Directory.GetCurrentDirectory();
            StreamReader lvlData = new StreamReader($"{path}\\Levels\\Level1.txt");

            currentObject = (char)lvlData.Read();
            int x = 1;
            int y = 1;
            while (lvlData.EndOfStream == false)
            {
                //in med x och y counters som ökar med varje loop av while variabeln
                x++;


                if (currentObject == '#')
                {
                    Wall wall = new Wall(x, y);
                    _elements.Add(wall);                    
                }
                if (currentObject == 's')   
                {   
                    Snake snake = new Snake(x, y);  
                    _elements.Add(snake);
                }
                if (currentObject == 'r')
                {
                    Rat rat = new Rat(x, y);
                    _elements.Add(rat);
                }
                if (currentObject == '@') 
                {
                    Player player1 = new Player();
                }
                currentObject = (char)lvlData.Read();
                if (currentObject == '\n')
                {
                    y++;
                    x = 0;
                }
                Console.ResetColor();
            }
            lvlData.Close();
        }
    }
}
