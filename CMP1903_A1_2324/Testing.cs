using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    /// <summary>
    /// Uses Debug.Assert() to perform a number of tests on the Game and Die classes.
    /// </summary>
    /// <remarks>
    /// The result of the Game object's methods is compared to their expected outputs: dice rolls within 1-6, sum within 3-18, 
    ///  and "Sum" property then validated. "Games" should be 1, and "Average" should be equal to "Sum".
    /// The Die class is checked separately to ensure result is within 1-6. "DieVal" property is then validated.
    /// The program then rolls dice nine more times, checks "Games" is 10, and "Average" is within 3-18.
    /// </remarks>
    internal class Testing {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        //Properties
        Game testGame = new Game();
        Die testDie = new Die();
        protected int _testSum = 0;
        protected int _testDieVal = 0;
        protected int _testGames = 0;

        //Method
        public void ForTest() {
            /*


            //Game object testing
            //Rolling die in our Game test object
            int sum = testGame.RollDie(3);

            //Verifying the sum of the three die values of the Game object
            Debug.Assert(sum <= 18 && sum >= 3);


            //Die object testing
            //Verifying the output of the Die object
            _testDieVal = testDie.Roll();
            Debug.Assert(_testDieVal <= 6 && _testDieVal >= 1);


            //Game object - average values testing
            //Verifying that "Games" has been updated as expected after a first game
            Debug.Assert(testGame.Games == 1);

            //Verifying that "Average" is equal to "Sum" (as expected) after a first game
            Debug.Assert(testGame.Average == testGame.Sum);


            //Testing averages after ten rolls
            for (int i = 2; i <= 10; i++) {
                testGame.RollDie(3);
                _testGames = i;
            }

            //Verifying that "Average" is within the expected range - 3 and 18
            Debug.Assert(testGame.Average <= 18 && testGame.Average >= 3);

            Console.WriteLine("No issues found while testing.\n");

            */
        }
    }
}
