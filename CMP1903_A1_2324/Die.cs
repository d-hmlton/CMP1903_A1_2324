﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Die
    {
        /*
         * The Die class should contain one property to hold the current die value,
         * and one method that rolls the die, returns and integer and takes no parameters.
         */

        //Property
        protected int _dieVal = 0;
        private static Random random = new Random(); //Creates an instance of "random" for number generation

        //Method
        public int Roll()
        {
            _dieVal = random.Next(1, 7); //Assigns _dieVal a random value between 1 and 6
            return _dieVal; //Returns the value
        }
    }
}
