﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.Elements
{
    internal class Rat : Enemy
    {
        public char ratIcon = 'r';

        public Rat()
        {
        }
        public Rat(int x, int y)
        {

            Position = new Position(x, y);
            this.Name = ratIcon;

            this.HealthPoints = 10;
            
            this.NumOfAtkDice = 1;
            this.SideOfAtkDice = 6;
            this.AtkModifier = 3;

            this.NumOfDefDice = 1;
            this.SideOfDefDice = 6;
            this. DefModifier = 1;
        }

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(ratIcon);
            Console.ResetColor();
        }
    }
}
