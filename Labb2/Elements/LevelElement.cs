﻿namespace Labb2
{
    abstract class LevelElement
    {

        public Position Position { get; set; }


        public LevelElement()
        {
           
        }
        public abstract void Replace(char icon);

        public LevelElement(int x, int y)
        {
        }
        public abstract void Update(int x, int y);

        public virtual void Draw()
        {

        }
        public bool IsVisible { get; set; } = false; 

    }
}
