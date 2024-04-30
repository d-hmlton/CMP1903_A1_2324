using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Statistics
    {
        //High Scores
        //Sevens
        protected string _sevensScoreWinner = "N/A";
        protected int _sevensScore = 0;
        protected string _sevensPlaysWinner = "N/A";
        protected int _sevensPlays = 0;

        //Threes
        protected string _threesWinner = "N/A";
        protected int _threesPlays = 0;

        //Get-Set Methods
        public string SevensScoreWinner { get { return _sevensScoreWinner; } set { _sevensScoreWinner = value; } }
        public int SevensScore { get { return _sevensScore; } set { _sevensScore = value; } }
        public string SevenPlaysWinner { get { return _sevensPlaysWinner; } set { _sevensPlaysWinner = value; } }
        public int SevensPlays { get { return _sevensPlays; } set { _sevensPlays = value; } }

        public string ThreesWinner { get { return _threesWinner; } set { _threesWinner = value; } }
        public int ThreesPlays { get { return _threesPlays; } set { _threesPlays = value; } }
    }
}
