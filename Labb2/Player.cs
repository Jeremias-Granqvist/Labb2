namespace Labb2
{
    class Player : LevelElement
    {
        private GameLoop _gameloop;
        public char playerIcon = '@';
        public int HealthPoints { get; set; }
        public int NumOfDice { get; set; }
        public int SideOfDice { get; set; }
        public int AtkModifier { get; set; }
        public int DefModifier { get; set; }
        public Player(int x, int y)
        {
            Position = new Position(x, y);
            HealthPoints = 100;
            NumOfDice = 2;
            SideOfDice = 6;
            AtkModifier = 2;
            DefModifier = 0;

            Console.SetCursorPosition(Position.X, Position.Y);
            Draw();
        }
        public override void Replace(char icon)
        {
            playerIcon = '@';
        }

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(playerIcon);
            Console.ResetColor();
        }

        public void CombatUpdate(int combatResult, GameLoop gameLoop)
        {
            _gameloop = gameLoop;
            HealthPoints -= combatResult;
            if (HealthPoints <= 0)
            {
                _gameloop.HandleGameOver();
            }
        }
        public override void Update(int x, int y)
        {

        }
    }
}
