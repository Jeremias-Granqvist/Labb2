using Labb2;

LevelData game = new LevelData();
game.Load($"\\Levels\\Level1.txt");
GameLoop turn = new GameLoop(game);

turn.CombatLog(null, null);

foreach (var element in game.Elements)
{
    Console.SetCursorPosition(element.Position.X, element.Position.Y);
    element.Draw();
}
turn.TurnCycle();

Console.ReadLine();