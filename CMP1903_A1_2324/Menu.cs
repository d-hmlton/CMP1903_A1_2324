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
        //Object instantiations
        private SevensOut _sevensOut = new SevensOut();
        private ThreeOrMore _threeOrMore = new ThreeOrMore();
        private Statistics _statistics = new Statistics();
        private Testing _testing = new Testing();

        static void Main(string[] args) {
            //Needed to call classes in this object
            Menu altMenu = new Menu();
           
            while (true)
            {
                Console.WriteLine("--Menu--");
                altMenu.MainMenu();
                break;
            }
        }

        protected void MainMenu()
        {
            Console.WriteLine("\nPlease select one of the following options:");
            Console.WriteLine(" 1: Instantiate the Sevens Out game.\n 2: Instantiate the Three Or More game.");
            Console.WriteLine(" 3: View statistics data.\n 4: Perform tests in Testing class.");

            string input;
            string player = "Error";
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
                            player = "Player 1";
                            isPlayer1 = false;
                        }
                        else if (isPlayer1 == false)
                        {
                            if (isPartner == true) { player = "Player 2"; }
                            if (isPartner == false) { player = "Computer"; }

                            isPlayer1 = true;
                        }

                        Console.WriteLine($"\n-{player}'s Turn-\n");
                        Console.Write($"{player}");

                        if (input == "1")
                        {
                            toPrint = _sevensOut.GameRules();

                            if (_statistics.SevensScore < _sevensOut.Total)
                            {
                                _statistics.SevensScoreWinner = player;
                                _statistics.SevensScore = _sevensOut.Total;
                            }

                            if (_statistics.SevensPlays < _sevensOut.Plays)
                            {
                                _statistics.SevenPlaysWinner = player;
                                _statistics.SevensPlays = _sevensOut.Plays;
                            }
                        }
                        else if (input == "2")
                        {
                            toPrint = _threeOrMore.GameRules(player);

                            _statistics.ThreesWinner = player;
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
                    Console.WriteLine("\n--Statistics--");
                    Console.WriteLine("\nSevens Out - High Scores");
                    Console.WriteLine($"Best Score: {_statistics.SevensScore} ({_statistics.SevensScoreWinner})");
                    Console.WriteLine($"Most Plays: {_statistics.SevensPlays} ({_statistics.SevenPlaysWinner})");
                    Console.WriteLine("\nThree Or More - High Score");
                    Console.WriteLine($"Least Plays: {_statistics.ThreesPlays} ({_statistics.ThreesWinner})");
                }

                else if (input == "4")
                {
                    Console.WriteLine("\n--Testing--\n");
                    Console.WriteLine("Starting test...");
                    _testing.ForTest();
                    Console.WriteLine("No issues found.");
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
            bool isPartner;

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
