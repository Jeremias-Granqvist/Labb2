
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.Elements
{
    class Snake :Enemy
    {
        public char snakeIcon = 's';
        GameController _gameController;
        LevelData _levelData;
        public Snake()
        {
        }
        public Snake(int x, int y,LevelData levelData, GameController gameController)
        {
            _gameController = gameController;
            _levelData = levelData;
            Position = new Position(x, y);
            this.Name = snakeIcon;
            this.HealthPoints = 25;
            this.NumOfAtkDice = 3;
            this.SideOfAtkDice = 4;
            this.AtkModifier = 2;
            this.NumOfDefDice = 1;
            this.SideOfDefDice = 8;
            this.DefModifier = 3;
        }
        public override void Draw()
        {
            if (IsVisible)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(snakeIcon);
            }
            else
            {
                Console.Write(' ');
            }
        }
        public override void CombatUpdate(int combatResult)
        {
            HealthPoints = HealthPoints - combatResult;
        }

        public override void Replace(char icon)
        {
            throw new NotImplementedException();
        }
        public bool IsPlayerNearby(Player player, Snake element)
        {
            return Math.Abs(player.Position.X - element.Position.X) + Math.Abs(player.Position.Y - element.Position.Y) <= 2;

        }
        private void MoveAwayFromPlayer(Player player)
        {
            int newX = this.Position.X;
            int newY = this.Position.Y;

           
            if (player.Position.Y > this.Position.Y) 
            {
                newY--; 
            }
            else if (player.Position.X < this.Position.X) 
            {
                newX++; 
            }
            else if (player.Position.Y < this.Position.Y) 
            {
                newY++; 
            }
            else if (player.Position.X > this.Position.X) 
            {
                newX--; 
            }

            // Update position if there's no collision
            if (_gameController.CollisionAt(newX, newY) == null)
            {
                this.Position = new Position(newX, newY);
            }
        }
        public override void Update(int x, int y)
        {
            Player player = _levelData.Elements.OfType<Player>().FirstOrDefault();
            _gameController.ErasePreviousPosition(this.Position.X, this.Position.Y);

            if (player != null && IsPlayerNearby(player, this))
            {
                MoveAwayFromPlayer(player);
            }

        }
    }
}
