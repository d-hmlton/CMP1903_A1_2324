using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    /// <summary>
    /// Class to perform tests on a couple of the classes in the program - Die, SevensOut, and ThreeOrMore.
    /// </summary>
    internal class Testing {
        //Parameters
        protected Die _testDie = new Die();
        protected SevensOut _testSevens = new SevensOut();
        protected ThreeOrMore _testThrees = new ThreeOrMore();

        /// <summary>
        /// Tests Die by calling 'Roll()' and checking the result is between 1 and 6.
        /// Tests SevensOut by calling 'GameRules()' and checking that the values of it's int list '_testStore' parameter add up to 7.
        /// Tests ThreeOrMore by calling 'GameRules()' and checking the total is equal to or greater than 20.
        /// </summary>
        public void ForTest() {
            //Die Test
            //Rolling
            int testDieVal = _testDie.Roll();

            //Verifying output is between 1 and 6
            Debug.Assert(testDieVal <= 6 && testDieVal >= 1);

            //Verifying output is the same as the Die object's dieVal parameter
            Debug.Assert(testDieVal == _testDie.DieVal);


            //Sevens Out Tests
            //Executes the Sevens Out game
            _testSevens.GameRules();

            //Ensures that the sum of the die roll is 7
            Debug.Assert((_testSevens.TestStore[0] + _testSevens.TestStore[1]) == 7);

            //Ensures that both values / die rolls are between 1 and 6
            Debug.Assert(_testSevens.TestStore[0] <= 6 && _testSevens.TestStore[0] >= 1);
            Debug.Assert(_testSevens.TestStore[1] <= 6 && _testSevens.TestStore[1] >= 1);

            //Ensures that the number of plays isn't impossible (below 1)
            Debug.Assert(_testSevens.Plays > 0);


            //Three Or More Tests
            //Executes the Three Or More game
            _testThrees.GameRules("Computer");

            //Ensures that the total is equal to or greater than 20 when Three Or More has ended
            Debug.Assert(_testThrees.Total >= 20);

            //Ensures that the number of plays isn't impossible (below 1)
            Debug.Assert(_testThrees.Plays > 0);
        }
    }
}
