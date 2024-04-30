using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    internal class Testing {
        //Properties
        Die testDie = new Die();
        protected int _testDieVal = 0;
        
        protected SevensOut _testSevens = new SevensOut();
        protected ThreeOrMore _testThrees = new ThreeOrMore();

        //Method
        public void ForTest() {
            //Sevens Out Tests
            //Executes the Sevens Out game
            _testSevens.GameRules();

            //Ensures that the sum of the die roll is 7
            Debug.Assert((_testSevens.TestStore[0] + _testSevens.TestStore[1]) == 7);


            //Three Or More Tests
            //Executes the Three Or More game
            _testThrees.GameRules("Computer");

            //Ensures that the total is equal to or greater than 20 when Three Or More has ended
            Debug.Assert(_testThrees.Total >= 20);


            //Die Test
            //Rolling
            _testDieVal = testDie.Roll();

            //Verifying output is between 1 and 6
            Debug.Assert(_testDieVal <= 6 && _testDieVal >= 1);
        }
    }
}
