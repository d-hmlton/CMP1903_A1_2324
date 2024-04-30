using System;
using System.Collections.Generic;
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
    internal abstract class Game {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */

        //Instantiating a die object
        Die dice = new Die();

        //Methods
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
    }
}
