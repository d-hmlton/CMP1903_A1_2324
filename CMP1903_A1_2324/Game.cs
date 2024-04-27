using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    /// <summary>
    /// Rolls three Die objects and adds up the "Sum", while calculating averages for total rolls. Has a method to print values.
    /// </summary>
    /// <remarks>
    /// The method to print values is PrintRoll(), and will print the three individual die values and then the sum.
    /// The purpose of this, rather than just having it as part of DieRoll(), is so printing is optional when running tests.
    /// Includes a separate method, GetRolls(int), to return the int values of the three Die objects to the Testing class.
    /// The program updates two properties - the number of games (_games, int), and the average (_average, double) every game.
    /// On the first game, it only has to set _games to 1 and set _average to the current sum. (_sum)
    /// After that, it multiplies _average by _games, adds the current sum, increments _games by 1, then divides _average by _games.
    /// </remarks>
    internal class Game {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */

        //Properties
        protected int _sum = -1;

        //Stats to print at end
        protected int _games = -1;
        protected double _average = -1.00d;

        //Instantiating a die object
        Die dice = new Die();
        //Die dieSecond = new Die();
        //Die dieThird = new Die();

        //Methods
        public int RollDie(int rolls)
        {
            List<int> rollList = new List<int>();
            _sum = 0;

            for (int i = 0; i < rolls; i++)
            {
                rollList.Add(dice.Roll());
                _sum = _sum + rollList[i];
                Console.WriteLine(dice.DieVal);
            }
            
            //Performing three die rolls
            //int firstRoll = dieFirst.Roll();
            //int secondRoll = dieSecond.Roll();
            //int thirdRoll = dieThird.Roll();



            //Sum calculation
            //_sum = firstRoll + secondRoll + thirdRoll;

            //Average property updating
            if (_games == -1) {
                //Runs for the first game only - sets initial values for these properties
                _games = 1;
                _average = _sum;
            } else if (_games > 0) {
                //Average calculation
                _average *= _games; //Takes current average and multiplies it by games played (previously)...
                _average += _sum;   //Adds the sum from this game to the value...
                _games++;           //Increments games played by one...
                _average /= _games; //Then divides by games played (currently) to get the average
            } else {
                throw new ArgumentOutOfRangeException($"The \'_games\' property cannot be equal to {_games}.");
            }

            return _sum;
        }

        /* public void PrintRoll() {
            Console.WriteLine($"Die 1: {dieFirst.DieVal}");  //Fetches the "DieVal"s of the respective Die objects
            Console.WriteLine($"Die 2: {dieSecond.DieVal}"); //XML comment explains why this is it's own method
            Console.WriteLine($"Die 3: {dieThird.DieVal}");
            Console.WriteLine($"SUM  = {_sum}");
        } */

        //BELOW CODE BREAKS TESTING BEING DISABLED! 
        /* 
        public int GetRolls(int die) {
            //Exception handling - ensures the int passed to the method is between 1 and 3, the accepted range
            if (die < 1 || die > 3) {
                throw new ArgumentOutOfRangeException(die + " is not in the accepted range.");
            }

            if (die == 1) { return dieFirst.DieVal; } //If the int provided is 1, returns value of first dice
            else if (die == 2) { return dieSecond.DieVal; } //If 2, returns second
            else if (die == 3) { return dieThird.DieVal; } //If 3, returns third
            else { return -1; } //If none of the above, returns -1
        } */

        public int Sum { get { return _sum; } set { _sum = value; } }
        public int Games { get { return _games; } set { _games = value; } }
        public double Average { get { return _average; } set { _average = value; } }
    }
}
