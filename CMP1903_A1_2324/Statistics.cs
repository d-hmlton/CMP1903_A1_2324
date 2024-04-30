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
        protected int _sevensScore;
        protected int _sevensPlays;

        //Threes
        protected int _threesPlays;

        //Get-Set Methods
        public int SevensScore { get { return _sevensScore; } set { _sevensScore = value; } }
        public int SevensPlays { get { return _sevensPlays; } set { _sevensPlays = value; } }
        public int ThreesPlays { get { return _threesPlays; } set { _threesPlays = value; } }
    }
}
