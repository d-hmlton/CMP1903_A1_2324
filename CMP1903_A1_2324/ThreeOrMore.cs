using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class ThreeOrMore : Game
    {
        int _total = 0;
        int _plays = 0;

        public string GameRules(bool isPlayer1, bool isPartner)
        {
            //Variables
            List<int> rollStore = new List<int>(5);
            List<int> threeRollStore = new List<int>(3);
            int kind = 0;
            int temp = 0;
            int valueStore = 0;
            int tempValStore = 0;
            bool willRollThree = true;

            _total = 0;
            _plays = 0;

            while (_total < 20)
            {
                _plays += 1;

                rollStore = RollDie(rollStore);

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
                        else if (rollStore[i] != rollStore[j])
                        {
                            break;
                        }
                    }

                    if (temp > kind) { kind = temp; }

                    if (kind > 2) { break; }
                    if (kind == 2) { tempValStore = valueStore; }

                    valueStore = 0;
                    temp = 0;
                }

                if (kind == 2)
                {
                    //Question prompt - uses Console.WriteLine. Would need to change if GUI implementation wanted
                    if (isPartner == true || isPlayer1 == true)
                    {
                        //Asks player(s) if they want to roll three or advance to five
                        willRollThree = TwoKindPrompt(tempValStore, isPlayer1);
                    } 

                    if (willRollThree == true)
                    {
                        threeRollStore = RollDie(threeRollStore);

                        threeRollStore[0] = valueStore;
                        temp = 0;

                        for (int i = 0; i < 3; i++)
                        {
                            if (threeRollStore[i] == valueStore) { temp += 1; }

                            if (threeRollStore[i] == tempValStore) { kind += 1; }
                        }

                        if (temp > kind) { kind = temp; }
                        threeRollStore.Clear();
                    }
                }
                
                if (kind == 3) { _total += 3; }
                else if (kind == 4) { _total += 6; }
                else if (kind == 5) { _total += 12; }

                kind = 0;
                temp = 0;
                valueStore = 0;
                rollStore.Clear();
            }

            return $" reached a score of {_total} after {_plays} plays!\n";
        }

        protected bool TwoKindPrompt(int value, bool isPlayer1)
        {
            string input;
            bool willRollThree = true;

            Console.WriteLine($" got a two of a kind (a pair of {value}), which gets no points.");
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

            //NOTE - The code here looks for the INVERSE, as Menu flips 'isPlayer1' before it calls 'GameRules()'
            if (isPlayer1 == true) { Console.Write("\nPlayer 1"); }
            else if (isPlayer1 == false) { Console.Write("\nPlayer 2"); }
            return willRollThree;
        }

        public int Plays { get { return _plays; } set { _plays = value; } }
    }
}
