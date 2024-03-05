using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    /// <summary>
    /// Creates a Game and Testing object, and calls their central methods - .RollDie() and .ForTest(). Asks if user wants to roll again.
    /// </summary>
    /// <remarks>
    /// Runs the Testing object first, then the Game object.
    /// Puts the .RollDie() call in a loop, which is broken when the user says they don't want to roll again.
    /// The roll again prompt has it's own loop so that input can be validated. The program loops until it gets a valid input.
    /// The user is asked to input "Y" or "N", but input is set to lowercase, so "y" and "n" are also valid.
    /// When the loop is broken, the program prints some statistics stores by the Game object - the number of games and averages.
    /// </remarks>
    internal class Program {
        static void Main(string[] args) {
            /*
             * Create a Game object and call its methods.
             * Create a Testing object to verify the output and operation of the other classes.
             */

            //Creating new 'Game' and 'Testing' objects
            Testing test = new Testing();
            Game game = new Game();

            //Doing Testing first
            test.ForTest();

            //Game loop - loop implemented to enable continuous die rolls
            Console.WriteLine("--Game--");
            while (true) {
                game.RollDie();
                game.PrintRoll();

                string input; //Creates input variable early; I ran into problems using it outside the validation loop
                Console.WriteLine("\nWould you like to roll again?");

                //Input validation loop
                while (true) {
                    Console.WriteLine("Please enter \"Y\" or \"N\".");
                    input = Console.ReadLine();

                    try {
                        input = input.ToLower(); //Sets the input to lowercase, so uppercase/lowercase Y/N are all valid.
                    } catch (Exception ex) {
                        Console.WriteLine("\nAn unknown error occured converting the input to lowercase: " + ex);
                        continue; //Resets the validation loop - so, asking user to input something else
                    }

                    if (input != "y" && input != "n") { //If the input provided is both not Y/y AND not N/n
                        Console.WriteLine("\nThe input provided is invalid - not \"Y\" or \"N\".");
                        continue; //Resets loop
                    }

                    break; //Exits this loop if input is validated
                }

                if (input != "y") { break; } //Exits the game loop if anything other than "Y" is given - so, if "N" is given
                else { Console.WriteLine(); }
            }

            //Statistics printing
            Console.WriteLine("\n--Statistics--");
            Console.WriteLine($"TOTAL GAMES: {game.Games}");
            Console.WriteLine($"AVERAGE DIE: {(game.Average / 3).ToString("#.##")}");
            Console.WriteLine($"AVERAGE SUM: {(game.Average).ToString("#.##")}");

            Console.ReadLine(); //Just keeps terminal open
        }
    }
}
