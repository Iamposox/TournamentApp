using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerate.NewModel
{
    public class Pair
    {
        public Participant BlueCorner { get; set; }
        public Participant RedCorner { get; set; }

        //Class Pair (even tho i am convice that Match is better name
        //Doesnt need to hold objects of next pair
        //Also it doesnt make sense that it hold two pairs.
        //Please decribe the logic
        public Pair BlueCornerPair { get; set; }
        public Pair RedCornerPair { get; set; }

        //use this type of comments please
        /// <summary>
        /// Pair ID
        /// </summary>
        public int ID { get; set; }


        //see this is why Match would sound better
        private Participant m_PairWinner;

        //Match again would sound better
        /// <summary>
        /// Sets the winner of the current pair
        /// </summary>
        /// <param name="_participant">Participant who won the current pair game</param>
        /// <returns>
        /// if provided participent was not taken part of the current match return false
        /// </returns>
        public bool SetWinnerOfThePair(Participant _participant)
        {
            //See Participant class for the comparison logic
            if (BlueCorner == _participant || RedCorner == _participant)
            {
                m_PairWinner = _participant;
                return true;
            }
            return false;
        }
    }
}
