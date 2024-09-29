using Labb2;

LevelData game = new LevelData();
game.Load($"\\Levels\\Level1.txt");

foreach (var element in game.Elements)
{
    Console.SetCursorPosition(element.horizontalPosition, element.verticalPosition);
    element.Draw();
}
