using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */
        Die dieFirst = new Die(); Die dieSecond = new Die(); Die dieThird = new Die();

        //Methods
        public void RollDie()
        {
            int firstRoll = dieFirst.Roll(); Console.WriteLine("Die 1: " + firstRoll);
            int secondRoll = dieSecond.Roll(); Console.WriteLine("Die 2: " + secondRoll);
            int thirdRoll = dieThird.Roll(); Console.WriteLine("Die 3: " + thirdRoll);
            Console.WriteLine("SUM = " + (firstRoll + secondRoll + thirdRoll));
        }
    }
}
