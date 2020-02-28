using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBracketGenerator.Helper;

namespace BracketGenerate.NewModel
{
    public delegate void MatchEndedDelegate(object sender, Participant _winner);
    public delegate void MatchTeamEndedDelegate(object sender, Team _winner);
    public delegate void MatchTeamUnionEndedDelegate(object sender, TeamUnion _winner);
    public class FirstRound
    {
        public Match BlueCornerPair { get; set; }
        public Match RedCornerPair { get; set; }
        public Participant BlueCorner { get; set; }
        public Participant RedCorner { get; set; }
        public Team BlueCornerTeam { get; set; }
        public Team RedCornerTeam { get; set; }
        public TeamUnion UnionBlue { get; set; }
        public TeamUnion UnionRed { get; set; }
        public int ID { get; set; }
        public event MatchEndedDelegate EndMatch;
        public event MatchTeamEndedDelegate EndMatchTeam;
        public event MatchTeamUnionEndedDelegate EndMatchTeamUnion;
        private Participant m_PairWinner;
        private Team m_PairTeamWinner;
        private TeamUnion m_PairTeamUniWinner;
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
        public bool SetWinnerOfThePair(Team team)
        {
            //See Participant class for the comparison logic
            if (BlueCornerTeam == team || RedCornerTeam == team)
            {
                m_PairTeamWinner = team;
                EndMatchTeam.Invoke(this, team);
                return true;
            }
            return false;
        }
        public bool SetWinnerOfThePair(TeamUnion teamUni)
        {
            //See Participant class for the comparison logic
            if (UnionBlue == teamUni|| UnionRed == teamUni)
            {
                m_PairTeamUniWinner = teamUni;
                EndMatchTeamUnion.Invoke(this, teamUni);
                return true;
            }
            return false;
        }
    }
}
