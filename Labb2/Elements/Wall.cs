using System.Diagnostics.CodeAnalysis;

namespace Labb2.Elements
{
    class Wall : LevelElement
    {
        public char wallIcon = '#';
        public Wall()
        {
        }
        public override void Replace(char icon)
        {
            wallIcon = icon;
        }
        public Wall(int x, int y)
        {
            Position = new Position(x, y);

        }
        public override void Draw()
        {
            if (IsVisible)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(wallIcon);
            }
            else
            {
                Console.Write(' ');
            }
        }

        public override void Update(LevelElement element, int x, int y)
        {
        }
    }
}
