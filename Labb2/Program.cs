using Labb2;
using System.Collections.Generic;
LevelData levelData = new LevelData();
GameController gameController = new GameController(levelData);
levelData.Load($"\\Levels\\Level1.txt", gameController);
GameLoop turn = new GameLoop(gameController, levelData);
gameController.Visibility();
turn.TurnCycle();
Console.ReadLine();
