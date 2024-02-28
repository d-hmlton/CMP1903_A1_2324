﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    /// <summary>
    /// Generates a random number between 1 and 6 and returns it.
    /// </summary>
    internal class Die {
        /*
         * The Die class should contain one property to hold the current die value,
         * and one method that rolls the die, returns and integer and takes no parameters.
         */

        //Properties
        protected int _dieVal = -1;
        private static Random random = new Random(); //Creates a single instance of "random" for number generation

        //Methods
        public int Roll() {
            _dieVal = random.Next(1, 7); //Assigns _dieVal a random value between 1 and 6
            return _dieVal; //Returns the value
        }

        public int DieVal { get { return _dieVal; } set { _dieVal = value; } }
    }
}
