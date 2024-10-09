using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Labb2.Elements
{
    class Rat : Enemy
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
                Draw();
            }
        }

        public override void Update(LevelElement element, int x, int y)             /////kaos här
        {
            Dice dice = new Dice(4);
            if (dice.DiceResult == 1 && turn.CollisionUp(element.Position.X, element.Position.Y) == null && !(element.Position.X == x && element.Position.Y - 1 == y))
            {
                y = turn.MoveEnemyUp(element, element.Position.X, element.Position.Y);
                element.Draw();
            }
            else if (turn.CollisionUp(element.Position.X, element.Position.Y) is Player player)
            {
                player.Update(turn.CombatResult(turn.EnemyAttack((Enemy)element).enemyAttack, turn.PlayerDefend().playerDefence));
                turn.CombatLogLineTwo(turn.EnemyAttack((Enemy)element).diceString, turn.PlayerDefend().diceString, turn.CombatResult(turn.EnemyAttack((Enemy)element).enemyAttack, turn.PlayerDefend().playerDefence));
            }
            if (dice.DiceResult == 2 && turn.CollisionRight(element.Position.X, element.Position.Y) == null && !(element.Position.X + 1 == x && element.Position.Y == y))
            {
                x = turn.MoveEnemyRight(element, element.Position.X, element.Position.Y);
                element.Draw();
            }
            else if (turn.CollisionRight(element.Position.X, element.Position.Y) is Player player)
            {
                player.Update(turn.CombatResultsult(turn.EnemyAttack((Enemy)element).enemyAttack, turn.PlayerDefend().playerDefence));
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
    }
    

}
