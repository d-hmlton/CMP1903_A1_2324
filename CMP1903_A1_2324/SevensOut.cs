using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    /// <summary>
    /// A child class of 'Game' that plays a game called "Sevens Out".
    /// Two die are rolled repeatedly until the player rolls a (sum of) 7, at which point the game ends.
    /// The objective is to avoid rolling a seven, with the sums of the rolls added to your score
    /// If the player rolls double the same die, the sum added to the score is doubled.
    /// </summary>
    /// <remarks>
    /// These are the exact rules for the game:
    /// "Roll the two dice, noting the total rolled each time.
    ///  If it is a 7 - stop.
    ///  If it is any other number - add it to your total.
    ///  If it is a double - add double the total to your score (3,3 would add 12 to your total)"
    /// </remarks>
    internal class SevensOut : Game
    {
        //Parameters
        protected int _total = 0;
        protected int _plays = 0;
        protected List<int> _testStore;

        /// <summary>
        /// After using 'RollDie' to roll two die, calculates the sum and checks if it's 7 or not. If not, adds it to the score as detailed.
        /// Repeats this in a while loop until a sum of 7 is rolled.
        /// </summary>
        /// <remarks>
        /// Starts by defining a couple variables - 'rollStore', an empty integer list with a capacity of 2, and 'sum' to hold what's returned by 'RollDie'.
        /// Starts a while loop that runs until sum isn't equal to 7. Increments '_plays' by 1 every time the loop repeats.
        /// Starts by passing 'rollStore' to 'RollDie()', and saving what's returned over 'rollStore'. Then adds up the two values it holds, saving to 'sum'.
        /// If the first value in 'rollStore' ([0]) is equal to the second ([1]), doubles sum.
        /// Adds 'sum' to the current value of '_total'. If sum isn't equal to 7, then uses 'Clear()' on 'rollStore'.
        /// When the loop ends and the game is over, saves 'rollStore' to '_testStore' for testing purposes, then returns a string detailing the game results.
        /// </remarks>
        /// <returns></returns>
        public string GameRules()
        {
            //Variables
            List<int> rollStore = new List<int>(2);
            int sum = 0;

            //Loop
            while (sum != 7)
            {
                _plays += 1;
                rollStore = RollDie(rollStore);
                sum = rollStore[0] + rollStore[1];

                if (rollStore[0] == rollStore[1]) { sum *= 2; } //Doubles check
                _total += sum; //Adds sum of numbers to "total"

                if (sum != 7) { rollStore.Clear(); }
            }

            _testStore = rollStore; //For testing purposes
            return $" rolled 7, ({rollStore[0]} + {rollStore[1]}) after {_plays} plays, and a total score of {_total}!\n";
        }

        public int Total { get { return _total; } }
        public int Plays { get { return _plays; } }
        public List<int> TestStore { get { return _testStore; } }
    }
}
