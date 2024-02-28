using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    /// <summary>
    /// Creates a Game and Testing object, and calls their central methods - .RollDie() and .ForTest().
    /// </summary>
    internal class Program {
        static void Main(string[] args) {
            /*
             * Create a Game object and call its methods.
             * Create a Testing object to verify the output and operation of the other classes.
             */

            //Creating new 'Game' and 'Testing' objects
            Game game = new Game();
            Testing test = new Testing();

            //
            game.RollDie();
            Console.WriteLine("\n--Testing--");
            test.ForTest();
        }
    }
}
