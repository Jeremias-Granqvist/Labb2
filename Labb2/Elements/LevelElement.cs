namespace Labb2
{
    abstract class LevelElement
    {

        //ska ha property för X
        //ska ha property för Y
        public Position Position { get; set; }


        public LevelElement()
        {
           
        }
        public abstract void Replace(char icon);

        public LevelElement(int x, int y)
        {
        }
        public abstract void Update(LevelElement element, int x, int y);

        public virtual void Draw()
        {

        }
        public bool IsVisible { get; set; } = false;
    }
}
