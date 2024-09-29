using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    class Dice
    {
        public int diceSides { get; set; }
        public int numOfDice { get; set; }
        public int bonusModifier { get; set; }
        public int diceResult { get; set; }
        public int randomResult { get; set; }

        Random randomDiceResult = new Random();
        //konstruktor som tar 3 params, numberOfDice, sidesPerDice, modifier
        //instansera för att kunna skapa d4, d6, d20 etc.
        
        public Dice(int numberOfDice, int sidesPerDice, int modifier)
        {
            this.numOfDice = numberOfDice;
            this.diceSides = sidesPerDice;
            this.bonusModifier = modifier;
        }


        // hur många tärningar, hur många sidor har dom och vad är basvärdet?
        // t.ex. 3d4+2 (slå 3 stycken 4sidiga tärningar och plussa på din attack som är 2)

        public int Throw(int numberOfDice, int sidesPerDice, int modifier)
        {
            for (int i = 1; i <= numberOfDice; i++)
            {
                randomResult = randomDiceResult.Next(0, diceSides);
                diceResult += randomResult;
            }
            return randomResult+modifier;

        }
        //public Throw() returnerar ett heltal med poäng när man slår tärningarna enligt
        //objektets konfiguration (player, snake och rat kan ha olika konfig på tärningar.
        //varje anrop är ett nytt slag med tärningarna

        public override string ToString()
        {
            return $"{numOfDice}D{diceSides}+{bonusModifier}";
        }

        
        //metod atkDice() ska vara olika för "player", "rat" och "snake" 
        //metod defDice() ska vara olika för "player", "rat" och "snake"
        //båda kastar tärningar enligt sin konfiguration och om def är högre eller lika mycker som atk tar man ingen skada.
        //om atk är högre än def tar man så mycket skada som mellanskillnaden är.



    }
}
