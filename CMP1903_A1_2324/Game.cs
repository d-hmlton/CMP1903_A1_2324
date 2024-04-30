using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    /// <summary>
    /// Rolls three Die objects and adds up the "Sum", while calculating averages for total rolls. Has a method to print values.
    /// </summary>
    /// <remarks>
    /// The method to print values is PrintRoll(), and will print the three individual die values and then the sum.
    /// The purpose of this, rather than just having it as part of DieRoll(), is so printing is optional when running tests.
    /// Includes a separate method, GetRolls(int), to return the int values of the three Die objects to the Testing class.
    /// The program updates two properties - the number of games (_games, int), and the average (_average, double) every game.
    /// On the first game, it only has to set _games to 1 and set _average to the current sum. (_sum)
    /// After that, it multiplies _average by _games, adds the current sum, increments _games by 1, then divides _average by _games.
    /// </remarks>
    internal class Game {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */

        //Properties
        //protected int _sum = -1;

        //Stats to print at end
        //protected int _games = -1;
        //protected double _average = -1.00d;

        //Instantiating a die object
        Die dice = new Die();

        //Methods
        /// <summary>
        /// A method to call "Sevens Out" or "Three Or More", and handle the (stastics? update this later)
        /// </summary>
        public void GameHandler()
        {
            Console.WriteLine("\n--Game--\n");
        }

        /*
        /// <summary>
        /// A method that rolls two die - or, calls "RollDie" while passing it an integer list with a capacity of two.
        /// It repeats this until the sum of the die rolled - the two values in the list returned by RollDie() - is equal to 7.
        /// It has two local integer variables, 'sum' and 'plays', and an integer list, 'rollStore'.
        /// 'sum' holds the sum of the values in the list returned by RollDie().
        /// 'plays' holds the number of times that RollDie() needs to be called in order to get a seven.
        /// 'rollDie' starts empty with a defined capacity of two, gets passed to RollDie(), and is overwritten by RollDie()'s returned list.
        /// </summary>
        /// <returns></returns>
        protected int SevensOut()
        {
            //Variables
            List<int> rollStore = new List<int>(2);
            int total = 0;
            int sum = 0;
            int plays = 1;

            Console.WriteLine("Sevens Out!");

            //Loop
            while (sum != 7)
            {
                rollStore = RollDie(rollStore);
                sum = rollStore[0] + rollStore[1];
                Console.WriteLine($"THROW {plays} = {rollStore[0]}, {rollStore[1]}");
                if (sum == 7)
                {
                    Console.WriteLine($"\n{rollStore[0]} + {rollStore[1]} = 7!\nSum of all throws: {total}");
                    return plays; //Exit
                }
                else
                {
                    if (rollStore[0] == rollStore[1]) { sum *= 2; } //Doubles check
                    total += sum; //Adds sum of numbers to "total"
                    plays += 1;
                }
            }

            //Exception
            return -1;
        }
        */

        /// <summary>
        /// Takes and returns an integer list - 'rollStore'.
        /// Rolls die as many times as there is capacity in the provided list.
        /// The list MUST be empty to begin with, and be full when returned.
        /// </summary>
        /// <param name="rollStore"></param>
        /// <returns></returns>
        protected List<int> RollDie(List<int> rollStore)
        {
            //Exception handling
            if (rollStore.Count != 0)
            {
                throw new ArgumentOutOfRangeException("List given to RollDie() method must be empty!");
            }
            
            for (int i = 0; i < rollStore.Capacity; i++)
            {
                rollStore.Add(dice.Roll());
            }

            return rollStore;
        }


        /*
        public int RollDie(int rolls)
        {
            List<int> rollList = new List<int>();
            _sum = 0;

            for (int i = 0; i < rolls; i++)
            {
                rollList.Add(dice.Roll());
                _sum = _sum + rollList[i];
            }

            //Average property updating
            if (_games == -1) {
                //Runs for the first game only - sets initial values for these properties
                _games = 1;
                _average = _sum;
            } else if (_games > 0) {
                //Average calculation
                _average *= _games; //Takes current average and multiplies it by games played (previously)...
                _average += _sum;   //Adds the sum from this game to the value...
                _games++;           //Increments games played by one...
                _average /= _games; //Then divides by games played (currently) to get the average
            } else {
                throw new ArgumentOutOfRangeException($"The \'_games\' property cannot be equal to {_games}.");
            }

            return _sum;
        }
        */

        /*
        public int Sum { get { return _sum; } set { _sum = value; } }
        public int Games { get { return _games; } set { _games = value; } }
        public double Average { get { return _average; } set { _average = value; } }
        */
    }
}
