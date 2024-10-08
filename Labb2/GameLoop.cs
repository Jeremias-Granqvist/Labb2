using Labb2.Elements;
using System;
using System.Xml.Linq;

namespace Labb2
{
    class GameLoop
    {
        private LevelData _levelData;
        public Position Position { get; set; }
        ConsoleKeyInfo keyInput;
        Player player;
        int turn = 0;
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
            var collisionWith = _levelData.Elements.FirstOrDefault(e => e.Position.X == testpositionX && e.Position.Y == testpositionY + 1);
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
                    else if (CollisionUp(element.Position.X, element.Position.Y) is Player player)
                    {
                        player.Update(CombatResult(EnemyAttack((Enemy)element).enemyAttack, PlayerDefend().playerDefence));
                        CombatLogLineTwo(EnemyAttack((Enemy)element).diceString, PlayerDefend().diceString, CombatResult(EnemyAttack((Enemy)element).enemyAttack, PlayerDefend().playerDefence));
                    }
                    if (dice.DiceResult == 2 && CollisionRight(element.Position.X, element.Position.Y) == null && !(element.Position.X + 1 == x && element.Position.Y == y))
                    {
                        x = MoveEnemyRight(element, element.Position.X, element.Position.Y);
                        element.Draw();
                    }
                    else if (CollisionRight(element.Position.X, element.Position.Y) is Player player)
                    {
                        player.Update(CombatResult(EnemyAttack((Enemy)element).enemyAttack, PlayerDefend().playerDefence));
                        CombatLogLineTwo(EnemyAttack((Enemy)element).diceString, PlayerDefend().diceString, CombatResult(EnemyAttack((Enemy)element).enemyAttack, PlayerDefend().playerDefence));
                    }
                    if (dice.DiceResult == 3 && CollisionDown(element.Position.X, element.Position.Y) == null && !(element.Position.X == x && element.Position.Y + 1 == y))
                    {
                        y = MoveEnemyDown(element, element.Position.X, element.Position.Y);
                        element.Draw();
                    }
                    else if (CollisionDown(element.Position.X, element.Position.Y) is Player player)
                    {
                        player.Update(CombatResult(EnemyAttack((Enemy)element).enemyAttack, PlayerDefend().playerDefence));
                        CombatLogLineTwo(EnemyAttack((Enemy)element).diceString, PlayerDefend().diceString, CombatResult(EnemyAttack((Enemy)element).enemyAttack, PlayerDefend().playerDefence));
                    }
                    if (dice.DiceResult == 4 && CollisionLeft(element.Position.X, element.Position.Y) == null && !(element.Position.X == x - 1 && element.Position.Y == y))
                    {
                        x = MoveEnemyLeft(element, element.Position.X, element.Position.Y);
                        element.Draw();
                    }
                    else if (CollisionLeft(element.Position.X, element.Position.Y) is Player player)
                    {
                        player.Update(CombatResult(EnemyAttack((Enemy)element).enemyAttack, PlayerDefend().playerDefence));
                        CombatLogLineTwo(EnemyAttack((Enemy)element).diceString, PlayerDefend().diceString, CombatResult(EnemyAttack((Enemy)element).enemyAttack, PlayerDefend().playerDefence));
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
                        if (player.Position.X < element.Position.X)
                        {
                            if (CollisionRight(element.Position.X, element.Position.Y) == null)
                            {
                                x = MoveEnemyRight(element, element.Position.X, element.Position.Y);
                                element.Draw();
                            }
                        }
                        if (player.Position.Y < element.Position.Y)
                        {
                            if (CollisionDown(element.Position.X, element.Position.Y) == null)
                            {
                                y = MoveEnemyDown(element, element.Position.X, element.Position.Y);
                                element.Draw();
                            }
                        }
                        if (x > element.Position.X)
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
        public (int playerAttack, string diceString) PlayerAttack()
        {
            Dice atk = new Dice(player.NumOfDice, player.SideOfDice, player.AtkModifier);
            string diceString = atk.ToString();
            return (atk.Throw(player.NumOfDice, player.SideOfDice, player.AtkModifier), diceString);
        }
        public (int playerDefence, string diceString) PlayerDefend()
        {
            Dice def = new Dice(player.NumOfDice, player.SideOfDice, player.DefModifier);
            string diceString = def.ToString();
            return (def.Throw(player.NumOfDice, player.SideOfDice, player.DefModifier), diceString);
        }
        public (int enemyAttack, string diceString) EnemyAttack(Enemy enemy)
        {
            Dice def = new Dice(enemy.NumOfAtkDice, enemy.SideOfAtkDice, enemy.AtkModifier);
            string diceString = def.ToString();
            return (def.Throw(enemy.NumOfAtkDice, enemy.SideOfAtkDice, enemy.AtkModifier), diceString);
        }
        public (int enemyDefence, string diceString) EnemyDefend(Enemy enemy)
        {
            Dice def = new Dice(enemy.NumOfDefDice, enemy.SideOfDefDice, enemy.DefModifier);
            string diceString = def.ToString();

            return (def.Throw(enemy.NumOfDefDice, enemy.SideOfDefDice, enemy.DefModifier), diceString);
        }
        public int CombatResult(int Atk, int Def)
        {
            if (Atk - Def < 0)
            {
                return 0;
            }
            else
            {
                return Atk - Def;
            }
            
        }
        public void StatusWindow()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Playername: {player.playerIcon} Health: {player.HealthPoints.ToString()} Turn: {turn.ToString()}      ");
            Console.ResetColor();
        }
        public void CombatLog(string atkdie, string defdie, int combatResult)
        {
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Player Combat Log: The player rolled {atkdie} attack versus the enemies {defdie} defence roll and deals {combatResult} damage ");
            Console.ResetColor();
        }
        public void CombatLogLineTwo(string defdie, string atkdie, int combatResult)
        {
            Console.SetCursorPosition(0, 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Enemy Combat Log: The enemy rolled {atkdie} attack versus the players {defdie} defence roll and deals {combatResult} damage ");
            Console.ResetColor();
        }

        public void Visibility()
        {
            for (int i = 0; i < _levelData.Elements.Count; i++)
            {
                if (Position.DistanceTo(player.Position))
                {

                }

            }

        }
        public void TurnCycle()
        {
            int x = player.Position.X;
            int y = player.Position.Y;
            bool isRunning = true;
            do
            {
                Visibility();
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
                            enemy.Update(CombatResult(PlayerAttack().playerAttack, EnemyDefend(enemy).enemyDefence));
                            CombatLog(PlayerAttack().diceString, EnemyDefend(enemy).diceString, CombatResult(PlayerAttack().playerAttack, EnemyDefend(enemy).enemyDefence));
                            if (enemy.HealthPoints <= 0)
                            {
                                _levelData.Elements.Remove(enemy);
                            }
                            if (CombatResult(EnemyAttack(enemy).enemyAttack, PlayerDefend().playerDefence) >= 0)
                            {
                                CombatLogLineTwo(EnemyAttack(enemy).diceString, PlayerDefend().diceString, CombatResult(EnemyAttack(enemy).enemyAttack, PlayerDefend().playerDefence));
                                player.Update(CombatResult(EnemyAttack(enemy).enemyAttack, PlayerDefend().playerDefence));
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (CollisionDown(x, y) is null)
                        {
                            y = MovePlayerDown(x, y);       //kanske lägga in playerupdate för yposition? 
                            player.Draw();
                        }
                        else if (CollisionDown(x, y) is Enemy enemy)
                        {
                            enemy.Update(CombatResult(PlayerAttack().playerAttack, EnemyDefend(enemy).enemyDefence));
                            CombatLog(PlayerAttack().diceString, EnemyDefend(enemy).diceString, CombatResult(PlayerAttack().playerAttack, EnemyDefend(enemy).enemyDefence));
                            if (enemy.HealthPoints <= 0)
                            {
                                _levelData.Elements.Remove(enemy);
                            }
                            if (CombatResult(EnemyAttack(enemy).enemyAttack, PlayerDefend().playerDefence) >= 0)
                            {
                                CombatLogLineTwo(EnemyAttack(enemy).diceString, PlayerDefend().diceString, CombatResult(EnemyAttack(enemy).enemyAttack, PlayerDefend().playerDefence));
                                player.Update(CombatResult(EnemyAttack(enemy).enemyAttack, PlayerDefend().playerDefence));
                            }
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
                            enemy.Update(CombatResult(PlayerAttack().playerAttack, EnemyDefend(enemy).enemyDefence));
                            CombatLog(PlayerAttack().diceString, EnemyDefend(enemy).diceString, CombatResult(PlayerAttack().playerAttack, EnemyDefend(enemy).enemyDefence));

                            if (enemy.HealthPoints <= 0)
                            {
                                _levelData.Elements.Remove(enemy);
                            }
                            if (CombatResult(EnemyAttack(enemy).enemyAttack, PlayerDefend().playerDefence) >= 0)
                            {
                                CombatLogLineTwo(EnemyAttack(enemy).diceString, PlayerDefend().diceString, CombatResult(EnemyAttack(enemy).enemyAttack, PlayerDefend().playerDefence));
                                player.Update(CombatResult(EnemyAttack(enemy).enemyAttack, PlayerDefend().playerDefence));
                            }

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
                            enemy.Update(CombatResult(PlayerAttack().playerAttack, EnemyDefend(enemy).enemyDefence));
                            CombatLog(PlayerAttack().diceString, EnemyDefend(enemy).diceString, CombatResult(PlayerAttack().playerAttack, EnemyDefend(enemy).enemyDefence));
                            if (enemy.HealthPoints <= 0)
                            {
                                _levelData.Elements.Remove(enemy);
                            }
                            if (CombatResult(EnemyAttack(enemy).enemyAttack, PlayerDefend().playerDefence) >= 0 )
                            {
                                CombatLogLineTwo(EnemyAttack(enemy).diceString, PlayerDefend().diceString, CombatResult(EnemyAttack(enemy).enemyAttack, PlayerDefend().playerDefence));
                                player.Update(CombatResult(EnemyAttack(enemy).enemyAttack, PlayerDefend().playerDefence));
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        isRunning = !isRunning;
                        break;
                    default:
                        break;
                }
                turn++;
                StatusWindow();
                EnemyMovement(x, y);


            } while (isRunning);
        }
    }
}
