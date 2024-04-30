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
        ThreeOrMore _threeOrMore = new ThreeOrMore();
        Statistics _statistics = new Statistics();

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
            string toPrint; //Stores return strings from methods

            while (true)
            {
                Console.WriteLine("\nPlease enter \"1\", \"2\", \"3\", or \"4\".");
                Console.Write("> "); input = Console.ReadLine();

                if ((input == "1") || (input == "2"))
                {
                    if (input == "1") { Console.WriteLine("\n--Sevens Out--"); }
                    else if (input == "2") { Console.WriteLine("\n--Three Or More--"); }

                    //Boolean variables
                    bool isPlayer1 = true; //If the loop runs Player 1's turn. Set to 'false' if you want player to go after opponent
                    bool isLastTurn = false; //Ends game at end of next while loop if set to true

                    //Partner vs. Computer
                    bool isPartner = PartnerPrompt();

                    while (true)
                    {
                        if (isPlayer1 == true)
                        {
                            Console.WriteLine("\n-Player 1's Turn-\n");
                            Console.Write("Player 1");
                            isPlayer1 = false;
                        }
                        else if (isPlayer1 == false)
                        {
                            if (isPartner == true)
                            {
                                Console.WriteLine("\n-Player 2's Turn-\n");
                                Console.Write("Player 2");
                            }
                            if (isPartner == false)
                            {
                                Console.WriteLine("\n-Computer's Turn-\n");
                                Console.Write("Computer");
                            }
                            isPlayer1 = true;
                        }

                        if (input == "1")
                        {
                            toPrint = _sevensOut.GameRules();

                            if (_statistics.SevensScore < _sevensOut.Total)
                            {
                                _statistics.SevensScore = _sevensOut.Total;
                            }

                            if (_statistics.SevensPlays < _sevensOut.Plays)
                            {
                                _statistics.SevensPlays = _sevensOut.Plays;
                            }
                        }
                        else if (input == "2")
                        {
                            toPrint = _threeOrMore.GameRules(!isPlayer1, isPartner); //Flips 'isPlayer1' since it was flipped earlier
                            _statistics.ThreesPlays = _threeOrMore.Plays;
                        }
                        else { toPrint = "ERROR"; }

                        Console.WriteLine(toPrint);

                        if (isLastTurn == true) { break; }
                        else if (isLastTurn == false) { isLastTurn = true; }
                    }

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

        protected bool PartnerPrompt()
        {
            string input;
            bool isPartner = true;

            Console.WriteLine("\nWould you like to play:\n 1: With a partner?\n 2: Against the computer?");
            while (true)
            {
                Console.WriteLine("\nPlease enter \"1\" or \"2\".");
                Console.Write("> "); input = Console.ReadLine();

                if (input == "1") { isPartner = true; }
                else if (input == "2") { isPartner = false; }
                else
                {
                    Console.WriteLine("\nThe input provided is invalid - not \"1\" or \"2\".");
                    continue;
                }

                break;
            }

            Console.WriteLine();
            return isPartner;
        }
    }
}
