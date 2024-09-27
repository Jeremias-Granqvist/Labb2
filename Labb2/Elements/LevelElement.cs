namespace Labb2
{
    abstract class LevelElement
    {

        //ska ha property för X
        //ska ha property för Y

        public int horizontalPosition;
        public int verticalPosition;
        public LevelElement()
        {
           
        }

        public LevelElement(int x, int y)
        {
            this.horizontalPosition = x;
            this.verticalPosition = y;
        }

        //char som lagrar vilket tecken en klass ritas ut med, t.ex. # för wall

        public virtual void Draw()
        {

        }
        // public "Draw()" metod (utan param) för för att rita upp allt med rätt färg och på rätt plats
        //en consolecolor för vilken färg tecknet skall ha


        


    }
}
