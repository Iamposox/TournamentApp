using BracketGenerate.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerate.NewModel
{
    public class Match:IMatch
    {
        public IParticipant BlueCorner { get; private set; }
        public IParticipant RedCorner { get; private set; }
        /// <summary>
        /// Pair ID
        /// </summary>
        public int ID { get; private set; }

        //see this is why Match would sound better
        public Match(IParticipant one, IParticipant two, int id) 
        {
            ID = id;
            BlueCorner = one;
            RedCorner = two;
        }
        public event MatchEndedDelegate EndMatch;
        
        private IParticipant m_PairWinner;
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
