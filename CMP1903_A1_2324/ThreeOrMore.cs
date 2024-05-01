using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    /// <summary>
    /// A child class of 'Game' that plays a game called "Three Or More".
    /// Five die are rolled, and the results are searched to see if the same number is rolled.
    /// Scores are saved to the parameters '_total' and '_plays', though the objective is to get the lowest number of 'plays' and the 'total' doesn't matter.
    /// </summary>
    /// <remarks>
    /// These are the rules for the game:
    /// "If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice. (Interpreted this as: throw 3 die vs. proceed to next loop)
	///  3-of-a-kind: 3 points
	///  4-of-a-kind: 6 points
	///  5-of-a-kind: 12 points
    ///  First to a total of 20."
    /// However, the rewards for 3/4/5 are defined as parameters below this comment, so if you wanted to change them it would be fairly simple.
    /// </remarks>
    internal class ThreeOrMore : Game
    {
        //Score parameters
        protected int _total = 0;
        protected int _plays = 0;

        //Reward parameters - allows for adjustment if wanted
        protected int _threeReward = 3;
        protected int _fourReward = 6;
        protected int _fiveReward = 12;

        /// <summary>
        /// After using 'RollDie' (an inherited method) to roll five die, searches the result to see if there are 2/3/4/5-of-a-kind.
        /// It's pretty involved code, so "remarks" is dense this time.
        /// </summary>
        /// <remarks>
        /// The method starts by defining a lot of variables: two empty integer lists, four integers set to zero, and one boolean set to true.
        /// 'rollStore' has a capacity of five, and 'threeRollStore' a capacity of three. Former is for normal gameplay, latter for two-of-a-kind rerolls.
        /// The '_total' and '_plays' parameters are also set to zero, so it's important that 'Statistics' is handled before starting the game again.
        /// 
        /// A while loop runs while '_total' - the score - is less than 20. The objective is to reach 20 or above.
        /// At the start of each loop, '_plays' is incremented by 1.
        /// The method calls 'RollDie', passing it 'rollStore', which at this point will be empty and have a capacity of five.
        /// 'RollDie' will return the result of five die rolls, which will be saved over the original 'rollStore' list.
        /// 
        /// The method runs a for loop, which will run four times, positioning itself at the first four positions in 'rollStore' Moves up each loop.
        /// Inside that loop is another for loop. This loop goes from the current position to the last position in 'rollStore'. Moves up each loop.
        /// So, if the first loop is at pos 0, second loop runs four times ([1] to [4]). If first loop is at pos 3, second loop runs only once (just [4]).
        /// 
        /// The method checks if the value at the position marked in loop 1 is equal to one for loop 2.
        /// If it is, it increments 'temp', an integer variable.
        /// If that was the first 'of-a-kind' found, it also saves the value to 'valueStore', and increments 'temp' an extra time.
        /// Else, if the values aren't the same, the loop continues.
        /// 
        /// After loop 2 concludes, it checks if the value in 'kind' (set to zero at start) is less than in 'temp'.
        /// If it is, it overwrites 'kind' with the value in 'temp'. ('kind' indicates what "of-a-kind" level the player has achieved, to be clear.)
        /// It then checks if the value in 'kind' is greater than 2. If it is, it breaks loop 1 to advance to the next part of the code.
        /// If it isn't, but 'kind' is equal to 2, it stores the value in 'valueStore' to 'tempValueStore' for safe-keeping.
        /// The previous is required, as the loop then sets 'valueStore' and 'temp' back to zero. 
        /// Loop 1 then repeats until it's finished looking at position [3] in the integer list 'rollStore'.
        /// 
        /// After the loop ends, the method looks at the 'kind' variable to see if points should be alloted - but first, if a two-of-a-kind happened.
        /// 
        /// If a two-of-a-kind did happen (if kind == 2), the method has to run some special behaviour.
        /// Firstly, it checks if 'player' is "Computer" or not.
        /// If the 'player' is not "Computer", it calls 'TwoKindPrompt()'. The boolean it returns is saved over 'willRollThree'.
        /// If the 'player' is "Computer", it goes with the default value of 'willRollThree', which is 'true'.
        /// If 'willRollThree' is true, it sends the empty 'threeRollStore' integer list to 'RollDie()', then saving over the list with the results.
        /// 'temp' is set back to 0 at this point.
        /// The method then saves the value at [0] to 'valueStore', and then runs a for loop to go from [0] to [2], checking if:
        /// a) the value in that position is equal to the value in 'valueStore' (will always be true for [0]), and/or
        /// b) the value in that position is equal to the value in 'tempValueStore'.
        /// If a) is true, it increments 'temp' by 1, and if b) is true, it increments 'kind' by 1.
        /// After that, it checks if 'temp' is greater than 'kind' - if the die rolled gave a three-of-a-kind different than the two-of-a-kind.
        /// If so, 'kind' is set to the value in 'temp'. Either way, 'threeRollStore' is then cleared (with Clear()) for the next game, and the code moves on.
        /// If 'willRollThree' was set to 'false', though, all that is skipped and the code will just repeat the (while _total < 20) loop.
        /// 
        /// Finally, the code rewards the player with points based on what "of-a-kind" they achieved.
        /// If the player got a three-of-a-kind (kind == 3), '_threeReward' is added to '_total'. By default, '_threeReward' is 3.
        /// If four-of-a-kind, '_fourReward' is added, which is 6 by default.
        /// If five-of-a-kind, '_fiveReward' - 12 by default.
        /// After that, to prepare for the next game, some variables are reset: 'kind', 'temp', 'valueStore' set to 0, and 'rollStore' cleared with 'Clear()'.
        /// 
        /// When the while loop has ended and the game is over, the method then returns a string with details on the results of the game.
        /// </remarks>
        public string GameRules(string player)
        {
            //Variables
            List<int> rollStore = new List<int>(5);
            List<int> threeRollStore = new List<int>(3);
            int kind = 0;
            int temp = 0;
            int valueStore = 0;
            int tempValueStore = 0;
            bool willRollThree = true;

            _total = 0;
            _plays = 0;

            while (_total < 20)
            {
                _plays += 1;

                rollStore = RollDie(rollStore);

                //Hunting for kinds in 'rollStore'
                for (int i = 0; i < 4; i++) //Loop 1 - Goes from list[0] to list[3]
                {
                    for (int j = i; j < 5; j++) //Loop 2 - Checks to a max of list[4]
                    {
                        if (rollStore[i] == rollStore[j])
                        {
                            if (temp == 0)
                            {
                                valueStore = rollStore[i];
                                temp++;
                            }
                            temp += 1;
                        }
                    }

                    if (temp > kind) { kind = temp; }

                    if (kind > 2) { break; }

                    if (kind == 2) { tempValueStore = valueStore; }
                    valueStore = 0;
                    temp = 0;
                }

                //Looking over the results of the kind hunting
                if (kind == 2)
                {
                    //Question prompt - uses Console.WriteLine. Would need to change if GUI implementation wanted
                    if (player != "Computer")
                    {
                        //Asks player(s) if they want to roll three or advance to five
                        willRollThree = TwoKindPrompt();
                    } 

                    if (willRollThree == true)
                    {
                        threeRollStore = RollDie(threeRollStore);

                        threeRollStore[0] = valueStore;
                        temp = 0;

                        for (int i = 0; i < 3; i++)
                        {
                            if (threeRollStore[i] == valueStore) { temp += 1; }

                            if (threeRollStore[i] == tempValueStore) { kind += 1; }
                        }

                        if (temp > kind) { kind = temp; }
                        threeRollStore.Clear();
                    }
                }
                
                if (kind == 3) { _total += _threeReward; } //     3 by default
                else if (kind == 4) { _total += _fourReward; } // 6 by default
                else if (kind == 5) { _total += _fiveReward; } //12 by default

                kind = 0;
                temp = 0;
                valueStore = 0;
                rollStore.Clear();
            }

            return $" reached {_total} after {_plays} plays!\n";
        }

        /// <summary>
        /// A method to validate the input given when a two-of-a-kind occurs.
        /// The player is asked if they would like to roll an additional three die to try to get a better outcome, or to move on to the next roll.
        /// A boolean saying what the player would like to do will be returned; true for "1", and false for "2".
        /// </summary>
        protected bool TwoKindPrompt()
        {
            string input;
            bool willRollThree;

            Console.WriteLine($"You got a two of a kind, which gets no points.");
            Console.WriteLine($"Would you like to: \n 1: Try your luck by rolling three more die?\n 2: Move on and roll another five?");
            while (true)
            {
                Console.WriteLine("\nPlease enter \"1\" or \"2\".");
                Console.Write("> "); input = Console.ReadLine();

                if (input == "1") { willRollThree = true; }
                else if (input == "2") { willRollThree = false; }
                else
                {
                    Console.WriteLine("\nThe input provided is invalid - not \"1\" or \"2\".");
                    continue;
                }

                break;
            }

            return willRollThree;
        }

        public int Plays { get { return _plays; } }
        public int Total { get { return _total; } }
    }
}
