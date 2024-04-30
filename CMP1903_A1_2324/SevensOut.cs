using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class SevensOut : Game
    {
        protected int _total = -1;
        protected int _plays = -1;

        public string GameRules()
        {
            //Variables
            List<int> rollStore = new List<int>(2);
            _total = 0;
            _plays = 1;
            int sum = 0;

            //Loop
            while (sum != 7)
            {
                rollStore = RollDie(rollStore);
                sum = rollStore[0] + rollStore[1];
                //Console.WriteLine($"THROW {plays} = {rollStore[0]}, {rollStore[1]}");

                if (rollStore[0] == rollStore[1]) { sum *= 2; } //Doubles check
                _total += sum; //Adds sum of numbers to "total"

                if (sum != 7)
                {
                    _plays += 1;
                    rollStore.Clear();
                }
            }

            return $" rolled 7, ({rollStore[0]} + {rollStore[1]}) after {_plays} plays, and a total score of {_total}.";
        }
    }
}
