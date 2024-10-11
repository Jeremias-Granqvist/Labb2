using Labb2.Elements;
using System.Collections.Generic;
using System.Numerics;

namespace Labb2
{
    class GameLoop
    {
        bool isRunning = true;

        public GameController _gameController;
        public List<LevelElement> elementsList;
        public LevelElement _levelElement;
        Player player;
        private LevelData _levelData;

        public Position Position { get; set; }
        ConsoleKeyInfo keyInput;
        
        int turnCounter = 0;
        public GameLoop(GameController gamecontroller, LevelData levelData)
        {

            _gameController = gamecontroller;
            _levelData = levelData;
        }
        public void StatusWindow()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Playername: {player.playerIcon}     ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Health: {player.HealthPoints.ToString()}     ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Turn: {turnCounter.ToString()}      ");
            Console.ResetColor();
        }
        public void HandleGameOver()
        {
            isRunning = !isRunning;
            Console.SetCursorPosition(25, 25);
            Console.WriteLine($"Game over :(");
        }
        public void TurnCycle()
        {
            player = _levelData.Elements.OfType<Player>().FirstOrDefault();
            int x = player.Position.X;
            int y = player.Position.Y;
            do
            {
                keyInput = Console.ReadKey(true);
                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (_gameController.CollisionUp(x, y) is null)
                        {
                            y = _gameController.MovePlayerUp(x, y);
                        }
                        else if (_gameController.CollisionUp(x, y) is Enemy enemy)
                        {
                            enemy.CombatUpdate(_gameController.CombatResult(_gameController.PlayerAttack().playerAttack, _gameController.EnemyDefend(enemy).enemyDefence));
                            _gameController.CombatLog(_gameController.PlayerAttack().diceString, _gameController.EnemyDefend(enemy).diceString, _gameController.CombatResult(_gameController.PlayerAttack().playerAttack, _gameController.EnemyDefend(enemy).enemyDefence));
                            if (enemy.HealthPoints <= 0)
                            {
                                _gameController.RemoveEnemy(enemy);
                            }
                            if (_gameController.CombatResult(_gameController.EnemyAttack(enemy).enemyAttack, _gameController.PlayerDefend().playerDefence) >= 0)
                            {
                                _gameController.CombatLogLineTwo(_gameController.EnemyAttack(enemy).diceString, _gameController.PlayerDefend().diceString, _gameController.CombatResult(_gameController.EnemyAttack(enemy).enemyAttack, _gameController.PlayerDefend().playerDefence));
                                player.CombatUpdate(_gameController.CombatResult(_gameController.EnemyAttack(enemy).enemyAttack, _gameController.PlayerDefend().playerDefence), this);
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (_gameController.CollisionDown(x, y) is null)
                        {
                            y = _gameController.MovePlayerDown(x, y);
                        }
                        else if (_gameController.CollisionDown(x, y) is Enemy enemy)
                        {
                            enemy.CombatUpdate(_gameController.CombatResult(_gameController.PlayerAttack().playerAttack, _gameController.EnemyDefend(enemy).enemyDefence));
                            _gameController.CombatLog(_gameController.PlayerAttack().diceString, _gameController.EnemyDefend(enemy).diceString, _gameController.CombatResult(_gameController.PlayerAttack().playerAttack, _gameController.EnemyDefend(enemy).enemyDefence));
                            if (enemy.HealthPoints <= 0)
                            {
                                _gameController.RemoveEnemy(enemy);
                            }
                            if (_gameController.CombatResult(_gameController.EnemyAttack(enemy).enemyAttack, _gameController.PlayerDefend().playerDefence) >= 0)
                            {
                                _gameController.CombatLogLineTwo(_gameController.EnemyAttack(enemy).diceString, _gameController.PlayerDefend().diceString, _gameController.CombatResult(_gameController.EnemyAttack(enemy).enemyAttack, _gameController.PlayerDefend().playerDefence));
                                player.CombatUpdate(_gameController.CombatResult(_gameController.EnemyAttack(enemy).enemyAttack, _gameController.PlayerDefend().playerDefence), this);
                            }
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (_gameController.CollisionLeft(x, y) is null)
                        {
                            x = _gameController.MovePlayerLeft(x, y);
                        }
                        else if (_gameController.CollisionLeft(x, y) is Enemy enemy)
                        {
                            enemy.CombatUpdate(_gameController.CombatResult(_gameController.PlayerAttack().playerAttack, _gameController.EnemyDefend(enemy).enemyDefence));
                            _gameController.CombatLog(_gameController.PlayerAttack().diceString, _gameController.EnemyDefend(enemy).diceString, _gameController.CombatResult(_gameController.PlayerAttack().playerAttack, _gameController.EnemyDefend(enemy).enemyDefence));

                            if (enemy.HealthPoints <= 0)
                            {
                                _gameController.RemoveEnemy(enemy);
                            }
                            if (_gameController.CombatResult(_gameController.EnemyAttack(enemy).enemyAttack, _gameController.PlayerDefend().playerDefence) >= 0)
                            {
                                _gameController.CombatLogLineTwo(_gameController.EnemyAttack(enemy).diceString, _gameController.PlayerDefend().diceString, _gameController.CombatResult(_gameController.EnemyAttack(enemy).enemyAttack, _gameController.PlayerDefend().playerDefence));
                                player.CombatUpdate(_gameController.CombatResult(_gameController.EnemyAttack(enemy).enemyAttack, _gameController.PlayerDefend().playerDefence), this);
                            }

                        }
                        break;
                    case ConsoleKey.RightArrow:
                        _gameController.CollisionRight(x, y);
                        if (_gameController.CollisionRight(x, y) is null)
                        {
                            x = _gameController.MovePlayerRight(x, y);
                        }
                        else if (_gameController.CollisionRight(x, y) is Enemy enemy)
                        {
                            enemy.CombatUpdate(_gameController.CombatResult(_gameController.PlayerAttack().playerAttack, _gameController.EnemyDefend(enemy).enemyDefence));
                            _gameController.CombatLog(_gameController.PlayerAttack().diceString, _gameController.EnemyDefend(enemy).diceString, _gameController.CombatResult(_gameController.PlayerAttack().playerAttack, _gameController.EnemyDefend(enemy).enemyDefence));
                            if (enemy.HealthPoints <= 0)
                            {
                                _gameController.RemoveEnemy(enemy);
                            }
                            if (_gameController.CombatResult(_gameController.EnemyAttack(enemy).enemyAttack, _gameController.PlayerDefend().playerDefence) >= 0)
                            {
                                _gameController.CombatLogLineTwo(_gameController.EnemyAttack(enemy).diceString, _gameController.PlayerDefend().diceString, _gameController.CombatResult(_gameController.EnemyAttack(enemy).enemyAttack, _gameController.PlayerDefend().playerDefence));
                                player.CombatUpdate(_gameController.CombatResult(_gameController.EnemyAttack(enemy).enemyAttack, _gameController.PlayerDefend().playerDefence), this);

                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        isRunning = !isRunning;
                        break;
                    default:
                        break;
                }
                turnCounter++;
                StatusWindow();
                _gameController.Visibility();
                _gameController.EnemyMovement(x, y);

            } while (isRunning);
        }
    }
}

