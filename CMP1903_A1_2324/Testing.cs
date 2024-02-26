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
    /// The first of these tests ensures the properties of both are correctly set to their default value, -1.
    /// The result of the Game object's methods is then compared to their expected outputs. This means the dice rolls are
    ///  checked to see if they're within 1-6, the sum to see if it's within 3-18, and the "Sum" property is validated by
    ///  having the Testing class perform it's own sum calculation.
    /// Similarly, the Die class is also checked to ensure the result is within 1-6, and the "DieVal" property is validated
    ///  by comparing it to the result the Die class returned.
    /// </remarks>
    internal class Testing {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        //Properties
        Game tesGame = new Game();
        Die tesDie = new Die();
        int tesSum = 0; int tesDieVal = 0;

        //Method
        public void ForTest() {
            //Ensuring the default value of the Game object's "Sum" property is -1
            Debug.Assert(tesGame.Sum == -1);

            //Ensuring the default value of the Die object's "DieVal" property is -1
            Debug.Assert(tesDie.DieVal == -1);
            
            //Rolling die in our Game test object
            tesGame.RollDie();

            //Verifying the individual die values of the Game object
            for (int i = 1; i < 4; i++) {
                Debug.Assert(tesGame.GetRolls(i) <= 6 || tesGame.GetRolls(i) >= 1);
                tesSum += tesGame.GetRolls(i); //Will be used later to test the sum
            }

            //Verifying the sum of the three die values of the Game object
            Debug.Assert(tesGame.Sum <= 18 || tesGame.Sum >= 3);

            //Verifying that the "Sum" given by the Game object is accurate
            Debug.Assert(tesGame.Sum == tesSum);

            //Verifying the output of the Die object
            tesDieVal = tesDie.Roll();
            Debug.Assert(tesDieVal <= 6 || tesDieVal >= 1);

            //Verifying that the "DieVal" given by the Die object is accurate
            Debug.Assert(tesDie.DieVal == tesDieVal);
        }
    }
}
