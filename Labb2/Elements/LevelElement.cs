namespace Labb2
{
    abstract class LevelElement
    {

        //ska ha property för X
        //ska ha property för Y

        public char gameElementChar = 'x';
        public LevelElement()
        {
           
        }
        public LevelElement(char gameElementChar)
        {
            this.gameElementChar = gameElementChar;
        }

        //char som lagrar vilket tecken en klass ritas ut med, t.ex. # för wall

        public void Draw()
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(gameElementChar);
        }
        // public "Draw()" metod (utan param) för för att rita upp allt med rätt färg och på rätt plats
        //en consolecolor för vilken färg tecknet skall ha


        


    }
}
