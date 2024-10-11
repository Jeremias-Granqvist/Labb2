using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    class Dice
    {
        public int DiceSides { get; set; }
        public int NumOfDice { get; set; }
        public int BonusModifier { get; set; }
        public int DiceResult { get; set; }
        public int RandomResult { get; set; }

        Random randomDiceResult = new Random();
        //konstruktor som tar 3 params, numberOfDice, sidesPerDice, modifier
        //instansera för att kunna skapa d4, d6, d20 etc.
        
        public Dice(int numberOfDice, int sidesPerDice, int modifier)
        {
            this.NumOfDice = numberOfDice;
            this.DiceSides = sidesPerDice;
            this.BonusModifier = modifier;
        }
        public Dice(int sidesOfDice)
        {
            DiceResult = randomDiceResult.Next(1, sidesOfDice+1); 
        }


        // hur många tärningar, hur många sidor har dom och vad är basvärdet?
        // t.ex. 3d4+2 (slå 3 stycken 4sidiga tärningar och plussa på din attack som är 2)

        public int Throw(int numberOfDice, int sidesPerDice, int modifier)
        {
            for (int i = 1; i <= numberOfDice; i++)
            {
                DiceResult = 0;
                RandomResult = randomDiceResult.Next(0, sidesPerDice+1);
                DiceResult += RandomResult;
            }
            return DiceResult+modifier;

        }
        //public Throw() returnerar ett heltal med poäng när man slår tärningarna enligt
        //objektets konfiguration (player, snake och rat kan ha olika konfig på tärningar.
        //varje anrop är ett nytt slag med tärningarna

        public override string ToString()
        {
            return $"{NumOfDice}D{DiceSides}+{BonusModifier}";
        }

        
        //metod atkDice() ska vara olika för "player", "rat" och "snake" 
        //metod defDice() ska vara olika för "player", "rat" och "snake"
        //båda kastar tärningar enligt sin konfiguration och om def är högre eller lika mycker som atk tar man ingen skada.
        //om atk är högre än def tar man så mycket skada som mellanskillnaden är.



    }
}
