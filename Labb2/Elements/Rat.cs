using System.Numerics;

namespace Labb2.Elements
{
    class Rat : Enemy
    {

        public char ratIcon = 'r';
        public LevelData ElementsList { get; set; }
        private LevelData _elements;
        LevelData _levelData;
        private GameController _gameController;
        GameLoop _gameLoop;


        public Rat()
        {
        }
        public Rat(int x, int y, LevelData levelData, GameController gameController)
        {
            _gameController = gameController;
            _levelData = levelData;

            Position = new Position(x, y);
            this.Name = ratIcon;
            this.HealthPoints = 10;
            this.NumOfAtkDice = 1;
            this.SideOfAtkDice = 6;
            this.AtkModifier = 3;
            this.NumOfDefDice = 1;
            this.SideOfDefDice = 6;
            this.DefModifier = 1;
        }


        public override void Draw()
        {
            if (IsVisible)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ratIcon);
                Console.ResetColor();
            }
            else
            {
                Console.Write(' ');
            }
        }



        public override void CombatUpdate(int combatResult)
        {


            HealthPoints = HealthPoints - combatResult;

            if (HealthPoints <= 0)
            {
                Position = new Position(0, 0);
                ratIcon = ' ';
                _gameController.RemoveEnemy(this);

            }
        }
        public override void Update(int x, int y)
        {
            Dice dice = new Dice(4); // Corrected to 4 sides
            int newX = x;
            int newY = y;
            _gameController.ErasePreviousPosition(this.Position.X, this.Position.Y);

            // Determine new position based on the dice result
            switch (dice.DiceResult)
            {
                case 1: newY--; break; // Up
                case 2: newX++; break; // Right
                case 3: newY++; break; // Down
                case 4: newX--; break; // Left
            }

            // Check for collision with the player
            Player player = _levelData.Elements.OfType<Player>().FirstOrDefault();
            if (player != null && player.Position.X == newX && player.Position.Y == newY)
            {
                // Combat logic
                player.Update(_gameController.CombatResult(_gameController.EnemyAttack(this).enemyAttack, _gameController.PlayerDefend().playerDefence), _gameController.PlayerDefend().playerDefence);
                _gameController.CombatLogLineTwo(_gameController.EnemyAttack(this).diceString, _gameController.PlayerDefend().diceString, _gameController.CombatResult(_gameController.EnemyAttack(this).enemyAttack, _gameController.PlayerDefend().playerDefence));
            }

                // Check for collisions with walls
                if (_gameController.CollisionAt(newX, newY) == null) // Up
                {
                    this.Position = new Position(newX, newY);
                }
                else if (_gameController.CollisionAt(newX, newY) == null) // Right
                {
                    this.Position = new Position(newX, newY);
                }
                else if (_gameController.CollisionAt(newX, newY) == null) // Down
                {
                    this.Position = new Position(newX, newY);
                }
                else if (_gameController.CollisionAt(newX, newY) == null) // Left
                {
                    this.Position = new Position(newX, newY);
                }

        }

    }
}




