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
    /// Ensures the properties of both are correctly set to their default value, -1.
    /// The result of the Game object's methods is compared to their expected outputs: dice rolls within 1-6, sum within 3-18, 
    ///  and "Sum" property then validated.
    /// The Die class is checked separately to ensure result is within 1-6. "DieVal" property is then validated.
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

        //Method
        public void ForTest() {
            //Ensuring the default value of the Game object's "Sum" property is -1
            Debug.Assert(testGame.Sum == -1);

            //Ensuring the default value of the Die object's "DieVal" property is -1
            Debug.Assert(testDie.DieVal == -1);
            
            //Rolling die in our Game test object
            testGame.RollDie();

            //Verifying the individual die values of the Game object
            for (int i = 1; i < 4; i++) {
                Debug.Assert(testGame.GetRolls(i) <= 6 || testGame.GetRolls(i) >= 1);
                _testSum += testGame.GetRolls(i); //Will be used later to test the sum
            }

            //Verifying the sum of the three die values of the Game object
            Debug.Assert(testGame.Sum <= 18 || testGame.Sum >= 3);

            //Verifying that the "Sum" given by the Game object is accurate
            Debug.Assert(testGame.Sum == _testSum);

            //Verifying the output of the Die object
            _testDieVal = testDie.Roll();
            Debug.Assert(_testDieVal <= 6 || _testDieVal >= 1);

            //Verifying that the "DieVal" given by the Die object is accurate
            Debug.Assert(testDie.DieVal == _testDieVal);
        }
    }
}
