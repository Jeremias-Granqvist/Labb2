﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.Elements
{
    internal class Rat : Enemy
    {


        //ärver från "Enemy"
        //implementerar Update() metod
        
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        
    }
}
