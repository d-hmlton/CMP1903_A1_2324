using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    /// <summary>
    /// A class to roll a six-sided dice.
    /// </summary>
    internal class Die {
        //Properties
        protected int _dieVal = -1;
        protected static Random _random = new Random(); //Creates a single instance of "random" for number generation

        //Methods
        /// <summary>
        /// Generates a random number between 1 and 6, and returns it.
        /// </summary>
        public int Roll() {
            _dieVal = _random.Next(1, 7); //Assigns _dieVal a random value between 1 and 6
            return _dieVal; //Returns the value
        }

        public int DieVal { get { return _dieVal; } set { _dieVal = value; } }
    }
}
