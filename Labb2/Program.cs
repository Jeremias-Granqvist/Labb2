using Labb2;

LevelData game = new LevelData();
game.Load($"\\Levels\\Level1.txt");

foreach (var element in game.Elements)
{
    Console.SetCursorPosition(element.Position.X, element.Position.Y);
    element.Draw();
}
GameLoop turn = new GameLoop(game);
turn.TurnCycle();

Console.ReadLine();