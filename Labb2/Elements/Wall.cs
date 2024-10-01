namespace Labb2.Elements
{
    class Wall : LevelElement
    {
        public char wallIcon = '#';
        public Wall()
        {
        }
        public Wall(int x, int y)
        {
            this.horizontalPosition = x;
            this.verticalPosition = y;
        }
        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(wallIcon);
        }
    }
}
