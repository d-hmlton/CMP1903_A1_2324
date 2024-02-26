using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    /// <summary>
    /// Rolls three dice, represented by three Die objects, prints the values, adds up the "Sum", and prints that too.
    /// </summary>
    /// <remarks>
    /// Includes a separate method, GetRolls(int), to return the int values of the three Die objects to the Testing class.
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
        Die dieFirst = new Die(); Die dieSecond = new Die(); Die dieThird = new Die();

        //Methods
        public void RollDie() {
            int firstRoll = dieFirst.Roll(); Console.WriteLine("Die 1: " + firstRoll);
            int secondRoll = dieSecond.Roll(); Console.WriteLine("Die 2: " + secondRoll);
            int thirdRoll = dieThird.Roll(); Console.WriteLine("Die 3: " + thirdRoll);
            _sum = firstRoll + secondRoll + thirdRoll;
            Console.WriteLine("SUM = " + _sum);
        }

        public int GetRolls(int die) {
            if (die < 1 || die > 3) {
                throw new ArgumentOutOfRangeException(die + " is not in the accepted range.");
            }

            if (die == 1) { return dieFirst.DieVal; }
            else if (die == 2) { return dieSecond.DieVal; }
            else if (die == 3) { return dieThird.DieVal; }
            else { return -1; }
        }

        public int Sum { get { return _sum; } set { _sum = value; } }
    }
}
