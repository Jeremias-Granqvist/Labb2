﻿using Labb2.Elements;

namespace Labb2
{
    class LevelData
    {
        private List<LevelElement> _elements = new List<LevelElement>();
        public List<LevelElement> Elements { get { return _elements; } }
        private GameController _gameController;
        char currentObject;

        public LevelData()
        {
        }


        public void Load(string filename, GameController gameController)
        {
            string path = Directory.GetCurrentDirectory();
            StreamReader lvlData = new StreamReader($"{path}\\Levels\\Level1.txt");
            _gameController = gameController;
            currentObject = (char)lvlData.Read();
            int x = 1;
            int y = 3;
            while (lvlData.EndOfStream == false)
            {
                x++;
                if (currentObject == '#')
                {
                    Wall wall = new Wall(x, y);
                    _elements.Add(wall);
                }
                if (currentObject == 's')
                {
                    Snake snake = new Snake(x, y, this, _gameController);
                    _elements.Add(snake);
                }
                if (currentObject == 'r')
                {
                    Rat rat = new Rat(x, y, this, _gameController);
                    _elements.Add(rat);
                }
                if (currentObject == '@')
                {
                    Player player = new Player(x, y);
                    _elements.Add(player);

                }
                currentObject = (char)lvlData.Read();

                if (currentObject == '\n')
                {
                    y++;
                    x = 0;
                }
                Console.ResetColor();
            }
            lvlData.Close();
        }
    }
}
