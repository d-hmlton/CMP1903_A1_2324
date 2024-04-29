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
    internal class Menu {
        SevensOut _sevensOut = new SevensOut();

        static void Main(string[] args) {
            //Needed to call classes in this object
            Menu altMenu = new Menu();

            Game game = new Game();
            

            while (true)
            {
                Console.WriteLine("--Menu--");
                altMenu.MainMenu();
                break;
            }

            /*
             * Create a Game object and call its methods.
             * Create a Testing object to verify the output and operation of the other classes.
             */

            /* 
            //Creating new 'Game' and 'Testing' objects
            Testing test = new Testing();
            Game game = new Game();

            //Doing Testing first
            test.ForTest();

            //Game loop - loop implemented to enable continuous die rolls
            Console.WriteLine("--Game--");
            while (true) {
                int sum = game.RollDie(3);
                Console.WriteLine($"Sum = {sum}");

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

            */
        }

        protected void MainMenu()
        {
            Console.WriteLine("\nPlease select one of the following options:");
            Console.WriteLine(" 1: Instantiate the Sevens Out game.\n 2: Instantiate the Three Or More game.");
            Console.WriteLine(" 3: View statistics data.\n 4: Perform tests in Testing class.");

            string input;
            while (true)
            {
                Console.WriteLine("\nPlease enter \"1\", \"2\", \"3\", or \"4\".");
                Console.Write("> "); input = Console.ReadLine();
                if ((input == "1") || (input == "2"))
                {
                    //Boolean variables
                    bool isPlayer1 = true; //If the loop runs Player 1's turn. Set to 'false' if you want player to go after opponent
                    bool isLastTurn = false; //Ends game at end of next while loop if set to true
                    bool isPartner = true; //Default value is true

                    //Partner vs. Computer
                    Console.WriteLine("\nWould you like to play:\n 1: With a partner?\n 2: Against the computer?")
                    while (true)
                    {
                        Console.WriteLine("\nPlease enter \"1\" or \"2\".")
                        Console.Write("> "); input = Console.ReadLine();

                        if (input == "1")
                        {
                            isPartner = true;
                            break;
                        }
                        else if (input == "2")
                        {
                            isPartner = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nThe input provided is invalid - not \"1\" or \"2\".");
                            continue;
                        }
                    }

                    while (true)
                    {
                        if (isPlayer1 == true)
                        {

                        }
                        else if (isPlayer1 == false)
                        {

                        }
                    }

                }

                if (input == "1")
                {
                    
                    
                    string toPrint = _sevensOut.GameRules();
                    Console.WriteLine(toPrint);
                }
                else if (input == "2")
                {
                    //Insert Three Or More call here
                }
                else if (input == "3")
                {
                    //Insert Statistics call here
                }
                else if (input == "4")
                {
                    //Insert Testing call here
                }
                else
                {
                    Console.WriteLine("\nThe input provided is invalid - not \"1\", \"2\", \"3\", or \"4\".");
                    continue;
                }
            }
        }
    }
}
