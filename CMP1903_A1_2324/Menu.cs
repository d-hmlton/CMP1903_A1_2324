using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    /// <summary>
    /// The primary class for the program. Loops a "main menu", which calls all the other functions of the program.
    /// </summary>
    internal class Menu {
        //Object instantiations
        private SevensOut _sevensOut = new SevensOut();
        private ThreeOrMore _threeOrMore = new ThreeOrMore();
        private Statistics _statistics = new Statistics();
        private Testing _testing = new Testing();

        /// <summary>
        /// Ran when the program starts. Instantiates one of itself to call the "main menu" method - C# hates doing it any other way.
        /// Uses a while loop to keep the program running indefinitely.
        /// </summary>
        static void Main(string[] args) {
            //Needed to call classes in this object
            Menu altMenu = new Menu();
           
            while (true)
            {
                Console.WriteLine("--Menu--");
                altMenu.MainMenu();
            }
        }

        /// <summary>
        /// The Main Menu.
        /// When user enters 1 or 2, it starts a game; 1 for "Sevens Out", 2 for "Three Or More".
        /// When user enters 3, the program prints some statistics data from "Statistics".
        /// When user enters 4, the program calls "Testing" to run some tests.
        /// </summary>
        /// <remarks>
        /// To go into more detail, the Main Menu runs a while loop in which the player is asked to give an input, saved to 'input'.
        /// If the player gives an invalid input (not 1/2/3/4) it will print an error / exception handling message and ask them to try again.
        /// The input is only treated as a string to minimise the complexity of the code and potential for things to go wrong.
        /// 
        /// Entering 1 and 2 will create a handful of boolean variables; 'isPlayer1', 'isLastTurn', and 'isPartner' - set as the return val of 'PartnerPrompt()'.
        /// It then starts a while loop, which should run twice for each round; first round with 'isLastTurn' false, second with 'isLastTurn' true.
        /// The while loop starts by figuring out what to save to 'player'; if 'isPlayer1' then Player 1, else if 'isPartner' then Player 2, else Computer.
        /// The loop checks what the input was. If 1, it calls 'GameRules()' in '_sevensOut'; if 2, also 'GameRules()' in '_threeOrMore', passing it 'player'.
        /// Both methods will return a string for the program to print to console. This is saved to the 'toPrint' string variable.
        /// The code checks if new scores are greater than the high scores in '_statistics'. If they are, they're overwritten - current 'player' is passed too.
        /// Finally, if 'isLastTurn' is set to false, it's set to true, and if it's set to true, the while loop breaks, meaning both rounds have finished.
        /// 
        /// Entering 3 will print a series of values fetched from inside the '_statistics' object. See Statistics.cs for more information.
        /// Entering 4 will call '_testing's testing method, printing when it starts and when it ends. See Testing.cs for more information.
        /// Not entering a valid input will bring up an exception handling message, instructing the user to try again, and then looping back to the prompt.
        /// </remarks>
        protected void MainMenu()
        {
            //Opening text
            Console.WriteLine("\nPlease select one of the following options:");
            Console.WriteLine(" 1: Instantiate the Sevens Out game.\n 2: Instantiate the Three Or More game.");
            Console.WriteLine(" 3: View statistics data.\n 4: Perform tests in Testing class.");

            //String variables
            string player = "Error"; //Stores the current player - could be "Player 1", "Player 2", or "Computer"
            string input; //Stores the input given by user
            string toPrint; //Stores return strings from methods

            //Prompt loop
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

                    //Game loop
                    while (true)
                    {
                        if (isPlayer1 == true)
                        {
                            player = "Player 1";
                            isPlayer1 = false; //Flips it for next loop
                        }
                        else if (isPlayer1 == false) //If this is not Player 1's turn
                        {
                            if (isPartner == true) { player = "Player 2"; } //If there is a second player...
                            if (isPartner == false) { player = "Computer"; } //If playing against the computer...

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

                            if (_statistics.ThreesPlays < _threeOrMore.Plays)
                            {
                                _statistics.ThreesWinner = player;
                                _statistics.ThreesPlays = _threeOrMore.Plays;
                            }
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

                break;
            }
        }

        /// <summary>
        /// A simple method to ask the user if they would like to play games with a second player or against the computer.
        /// Will loop the prompt until a valid input is given. When one is given, it returns a boolean 'isPartner' indicating the choice made.
        /// </summary>
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
