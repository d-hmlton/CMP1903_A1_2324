using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    /// <summary>
    /// An abstract class inherited by games, such as "SevensOut" and "ThreeOrMore". Passes a method to process multiple die rolls to it's children.
    /// </summary>
    internal abstract class Game {
        //Instantiating a die object
        protected Die _dice = new Die();

        //Methods
        /// <summary>
        /// Takes and returns an integer list - 'rollStore'. Calls '_dice's 'Roll()' as many times as there is capacity in the provided list.
        /// The list MUST be empty to begin with; otherwise, the code will throw an exception.
        /// </summary>
        protected List<int> RollDie(List<int> rollStore)
        {
            //Exception handling
            if (rollStore.Count != 0)
            {
                throw new ArgumentOutOfRangeException("List given to RollDie() method must be empty!");
            }
            
            for (int i = 0; i < rollStore.Capacity; i++)
            {
                rollStore.Add(_dice.Roll());
            }

            return rollStore;
        }
    }
}
