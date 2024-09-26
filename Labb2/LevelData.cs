using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{

    
    class LevelData
    {
        private List<LevelElement> Elements = new List<LevelElement>();
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
            string symbol;

            StreamReader lvlData = new StreamReader("C:\\Users\\Taros\\source\\repos\\Labb2\\Labb2\\Levels\\Level1.txt");

            symbol = lvlData.ReadLine();

            while (symbol != null)
            {
                Console.WriteLine(symbol);
                symbol = lvlData.ReadLine();

                Elements.Add(symbol);
            }

            lvlData.Close();
            Console.ReadLine();

        }

    }
}
