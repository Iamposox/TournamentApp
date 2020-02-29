using BracketGenerate.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBracketGenerator.Helper;

namespace BracketGenerate.NewModel
{
    public delegate void MatchEndedDelegate(object sender, IParticipant _winner);
    //public delegate void MatchTeamEndedDelegate(object sender, Team _winner);
    //public delegate void MatchTeamUnionEndedDelegate(object sender, TeamUnion _winner);
    public class FirstRound
    {
        public IMatch BlueCornerPair { get; set; }
        public IMatch RedCornerPair { get; set; }
        public IParticipant BlueCorner { get; private set; }
        public IParticipant RedCorner { get; private set; }
        public int ID { get; set; }
        public event MatchEndedDelegate EndMatch;
        private IParticipant m_PairWinner;

        
            /// <summary>
        /// Sets the winner of the current pair
        /// </summary>
        /// <param name="_participant">Participant who won the current pair game</param>
        /// <returns>
        /// if provided participent was not taken part of the current match return false
        /// </returns>
        public bool SetWinnerOfThePair(IParticipant _participant)
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
