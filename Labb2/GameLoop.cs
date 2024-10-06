using Labb2.Elements;

namespace Labb2
{
    class GameLoop
    {
        private LevelData _levelData;
        public Position Position { get; set; }
        ConsoleKeyInfo keyInput;
        Player player;
        public GameLoop(LevelData levelData)
        {
            _levelData = levelData;
            foreach (var element in levelData.Elements)
            {
                if (element is Player)
                {
                    player = (Player)element;
                }
            }
        }
        public LevelElement CollisionUp(int x, int y)
        {
            int testpositionX = x;
            int testpositionY = y;
            var collisionWith = _levelData.Elements.FirstOrDefault(e => e.Position.X == testpositionX && e.Position.Y == testpositionY - 1);
            return collisionWith;
        }
        public LevelElement CollisionDown(int x, int y)
        {
            int testpositionX = x;
            int testpositionY = y;
            var collisionWith = _levelData.Elements.FirstOrDefault(e => e.Position.X == testpositionX && e.Position.Y == testpositionY + 1)
            return collisionWith;
        }
        public LevelElement CollisionLeft(int x, int y)
        {
            int testpositionX = x;
            int testpositionY = y;
            var collisionWith = _levelData.Elements.FirstOrDefault(e => e.Position.X == testpositionX - 1 && e.Position.Y == testpositionY);
            return collisionWith;
        }
        public LevelElement CollisionRight(int x, int y)
        {
            int testpositionX = x;
            int testpositionY = y;
            var collisionWith = _levelData.Elements.FirstOrDefault(e => e.Position.X == testpositionX + 1 && e.Position.Y == testpositionY);
            return collisionWith;
        }

        public int MoveEnemyUp(LevelElement element, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            element.Position = new Position(element.Position.X, element.Position.Y - 1);
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            return element.Position.Y;
        }
        public int MoveEnemyDown(LevelElement element, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            element.Position = new Position(element.Position.X, element.Position.Y + 1);
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            return element.Position.Y;
        }
        public int MoveEnemyRight(LevelElement element, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            element.Position = new Position(element.Position.X + 1, element.Position.Y);
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            return element.Position.X;
        }
        public int MoveEnemyLeft(LevelElement element, int x, int y)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            element.Position = new Position(element.Position.X - 1, element.Position.Y);
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            return element.Position.X;
        }
        public void EnemyMovement(int x, int y)
        {
            foreach (var element in _levelData.Elements)
            {
                if (element is Wall)
                {
                    continue;
                }
                if (element is Rat)
                {
                    Dice dice = new Dice(4);
                    if (dice.DiceResult == 1 && CollisionUp(element.Position.X, element.Position.Y) == null && !(element.Position.X == x && element.Position.Y - 1 == y))
                    {
                        y = MoveEnemyUp(element, element.Position.X, element.Position.Y);
                        element.Draw();
                    }
                    else if (dice.DiceResult == 2 && CollisionRight(element.Position.X, element.Position.Y) == null && !(element.Position.X + 1 == x && element.Position.Y == y))
                    {
                        x = MoveEnemyRight(element, element.Position.X, element.Position.Y);
                        element.Draw();
                    }
                    else if (dice.DiceResult == 3 && CollisionDown(element.Position.X, element.Position.Y) == null && !(element.Position.X == x && element.Position.Y + 1 == y))
                    {
                        y = MoveEnemyDown(element, element.Position.X, element.Position.Y);
                        element.Draw();
                    }
                    else if (dice.DiceResult == 4 && CollisionLeft(element.Position.X, element.Position.Y) == null && !(element.Position.X == x - 1 && element.Position.Y == y))
                    {
                        x = MoveEnemyLeft(element, element.Position.X, element.Position.Y);
                        element.Draw();
                    }
                }
                if (element is Snake)
                {
                    if (Math.Abs(player.Position.X - element.Position.X) + Math.Abs(player.Position.Y - element.Position.Y) <= 2)
                    {
                        if (player.Position.Y > element.Position.Y)
                        {
                            if (CollisionUp(element.Position.X, element.Position.Y) == null)
                            {
                                y = MoveEnemyUp(element, element.Position.X, element.Position.Y);
                                element.Draw();
                            }
                        }
                        else if (player.Position.X < element.Position.X)
                        {
                            if (CollisionRight(element.Position.X, element.Position.Y) == null)
                            {
                                x = MoveEnemyRight(element, element.Position.X, element.Position.Y);
                                element.Draw();
                            }
                        }
                        else if (player.Position.Y < element.Position.Y)
                        {
                            if (CollisionDown(element.Position.X, element.Position.Y) == null)
                            {
                                y = MoveEnemyDown(element, element.Position.X, element.Position.Y);
                                element.Draw();
                            }
                        }
                        else if (x > element.Position.X)
                        {
                            if (CollisionLeft(element.Position.X, element.Position.Y) == null)
                            {
                                x = MoveEnemyLeft(element, element.Position.X, element.Position.Y);
                                element.Draw();
                            }
                        }
                    }
                }
            }
        }
        public int MovePlayerUp(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            player.Position = new Position(player.Position.X, player.Position.Y - 1);
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            return player.Position.Y;
        }
        public int MovePlayerDown(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            player.Position = new Position(player.Position.X, player.Position.Y + 1);
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            return player.Position.Y;
        }
        public int MovePlayerRight(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            player.Position = new Position(player.Position.X + 1, player.Position.Y);
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            return player.Position.X;
        }
        public int MovePlayerLeft(int x, int y)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            player.Position = new Position(player.Position.X - 1, player.Position.Y);
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            return player.Position.X;
        }
        public int PlayerAttack()
        {
            Dice atk = new Dice(player.NumOfDice, player.SideOfDice, player.AtkModifier);
            return atk.Throw(player.NumOfDice, player.SideOfDice, player.AtkModifier);
        }
        public int PlayerDefend()
        {
            Dice atk = new Dice(player.NumOfDice, player.SideOfDice, player.DefModifier);
            return atk.Throw(player.NumOfDice, player.SideOfDice, player.DefModifier);
        }
        public int EnemyAttack(Enemy enemy)
        {
            Dice def = new Dice(enemy.NumOfAtkDice, enemy.SideOfAtkDice, enemy.AtkModifier);
            return def.Throw(enemy.NumOfAtkDice, enemy.SideOfAtkDice, enemy.AtkModifier);
        }
        public int EnemyDefend(Enemy enemy)
        {
            Dice def = new Dice(enemy.NumOfDefDice, enemy.SideOfDefDice, enemy.DefModifier);
            return def.Throw(enemy.NumOfDefDice, enemy.SideOfDefDice, enemy.DefModifier);
        }
        public int CombatResult(int Atk, int Def)
        {
            return Atk - Def;
        }
        public void TurnCycle()
        {

            int x = player.Position.X;
            int y = player.Position.Y;
            bool isRunning = true;
            do
            {
                keyInput = Console.ReadKey(true);

                switch (keyInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (CollisionUp(x, y) is null)
                        {
                            y = MovePlayerUp(x, y);
                            player.Draw();
                        }
                        else if (CollisionUp(x, y) is Enemy enemy)
                        {
                            enemy.Update(CombatResult(PlayerAttack(), EnemyDefend(enemy)));
                            if (enemy.HealthPoints <= 0)
                            {
                                _levelData.Elements.Remove(enemy);
                            }
                            player.Update(CombatResult(EnemyAttack(enemy), PlayerDefend()));

                        }

                        break;

                    case ConsoleKey.DownArrow:
                        if (CollisionDown(x, y) is null)
                        {
                            y = MovePlayerDown(x, y);
                            player.Draw();
                        }
                        else if (CollisionDown(x, y) is Enemy enemy)
                        {
                            enemy.Update(CombatResult(PlayerAttack(), EnemyDefend(enemy)));
                            if (enemy.HealthPoints <= 0)
                            {
                                _levelData.Elements.Remove(enemy);
                            }
                            player.Update(CombatResult(EnemyAttack(enemy), PlayerDefend()));

                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (CollisionLeft(x, y) is null)
                        {
                            x = MovePlayerLeft(x, y);
                            player.Draw();
                        }
                        else if (CollisionLeft(x, y) is Enemy enemy)
                        {
                            enemy.Update(CombatResult(PlayerAttack(), EnemyDefend(enemy)));
                            if (enemy.HealthPoints <= 0)
                            {
                                _levelData.Elements.Remove(enemy);
                            }
                            player.Update(CombatResult(EnemyAttack(enemy), PlayerDefend()));

                        }
                        break;

                    case ConsoleKey.RightArrow:
                        CollisionRight(x, y);
                        if (CollisionRight(x, y) is null)
                        {
                            x = MovePlayerRight(x, y);
                            player.Draw();
                        }
                        else if (CollisionRight(x, y) is Enemy enemy)
                        {
                            enemy.Update(CombatResult(PlayerAttack(), EnemyDefend(enemy)));
                            if (enemy.HealthPoints <= 0)
                            {
                                _levelData.Elements.Remove(enemy);
                            }
                            player.Update(CombatResult(EnemyAttack(enemy), PlayerDefend()));
                        }
                        break;

                    case ConsoleKey.Escape:
                        isRunning = !isRunning;
                        break;
                    default:
                        break;
                }

                EnemyMovement(x, y);


            } while (isRunning);
        }
    }
}
