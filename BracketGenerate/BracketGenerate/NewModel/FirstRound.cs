using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBracketGenerator.Helper;

namespace BracketGenerate.NewModel
{
    public delegate void MatchEndedDelegate(object sender, Participant _winner);
    public class FirstRound
    {
        public Match BlueCornerPair { get; set; }
        public Match RedCornerPair { get; set; }
        public Participant BlueCorner { get; set; }
        public Participant RedCorner { get; set; }
        public int ID { get; set; }
        public event MatchEndedDelegate EndMatch;
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
                EndMatch.Invoke(this, _participant);
                return true;
            }
            return false;
        }
    }
}
