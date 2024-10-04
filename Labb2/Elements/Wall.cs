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
            Position = new Position(x, y);

        }
        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(wallIcon);
        }
    }
}
