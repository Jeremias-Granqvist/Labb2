using Labb2;

LevelData game = new LevelData();
game.Load($"\\Levels\\Level1.txt");

GameLoop turn = new GameLoop(game);

turn.Visibility();
turn.TurnCycle();
Console.ReadLine();