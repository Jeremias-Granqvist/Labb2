using Labb2.Elements;
using System;
using System.Data;
using System.Xml.Linq;

namespace Labb2
{
    class GameController
    {
        LevelData _levelData;
        private List<LevelElement> _levelElement;
        LevelElement lvlElement;
        public Position Position { get; set; }
        Player player;
        int turnCounter = 0;
        public GameController(LevelData levelData)
        {
            _levelData = levelData;
            player = _levelData.Elements.OfType<Player>().FirstOrDefault();
        }
        public LevelElement CollisionAt(int x, int y)
        {
            return _levelData.Elements.FirstOrDefault(e => e.Position.X == x && e.Position.Y == y);
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
            ErasePreviousPosition(x, y);
            element.Position = new Position(element.Position.X, element.Position.Y - 1);
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            return element.Position.Y;
        }
        public int MoveEnemyDown(LevelElement element, int x, int y)
        {
            ErasePreviousPosition(x, y);
            element.Position = new Position(element.Position.X, element.Position.Y + 1);
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            return element.Position.Y;
        }
        public int MoveEnemyRight(LevelElement element, int x, int y)
        {
            ErasePreviousPosition(x, y);
            element.Position = new Position(element.Position.X + 1, element.Position.Y);
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            return element.Position.X;
        }
        public int MoveEnemyLeft(LevelElement element, int x, int y)
        {

            ErasePreviousPosition(x, y);
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
                if (element is Enemy)
                {
                    element.Update(element.Position.X, element.Position.Y);
                }
            }

            foreach (var element in _levelData.Elements)
            {
                if (element is Enemy)
                {
                    Console.SetCursorPosition(element.Position.X, element.Position.Y);
                    element.Draw();
                }
            }
        }
        

        public int MovePlayerUp(int x, int y)
        {
            ErasePreviousPosition(x, y);
            player.Position = new Position(player.Position.X, player.Position.Y - 1);
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            return player.Position.Y;
        }
        public int MovePlayerDown(int x, int y)
        {
            ErasePreviousPosition(x, y);
            player.Position = new Position(player.Position.X, player.Position.Y + 1);
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            return player.Position.Y;
        }
        public int MovePlayerRight(int x, int y)
        {
            ErasePreviousPosition(x, y);
            player.Position = new Position(player.Position.X + 1, player.Position.Y);
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            return player.Position.X;
        }
        public int MovePlayerLeft(int x, int y)
        {
            ErasePreviousPosition(x, y);
            player.Position = new Position(player.Position.X - 1, player.Position.Y);
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            return player.Position.X;
        }
        public void ErasePreviousPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        public void RemoveEnemy(Enemy enemy)
        {
            _levelData.Elements.Remove(enemy);

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
        public void Visibility()
        {
            player = _levelData.Elements.OfType<Player>().FirstOrDefault();

            for (int i = 0; i < _levelData.Elements.Count; i++)
            {
                if (Position.DistanceTo(_levelData.Elements[i].Position, player.Position) <= 5)
                {
                    _levelData.Elements[i].IsVisible = true;
                }
                if (_levelData.Elements[i] is Enemy && Position.DistanceTo(_levelData.Elements[i].Position, player.Position) <= 5)
                {
                    _levelData.Elements[i].IsVisible = true;
                }
                else if (_levelData.Elements[i] is Enemy && Position.DistanceTo(_levelData.Elements[i].Position, player.Position) >= 5)
                {
                    _levelData.Elements[i].IsVisible = false;

                }
                Console.SetCursorPosition(_levelData.Elements[i].Position.X, _levelData.Elements[i].Position.Y);
                _levelData.Elements[i].Draw();
            }
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
    }
}
