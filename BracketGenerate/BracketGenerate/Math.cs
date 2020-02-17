using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracketGenerator
{
    public class Match
    {
        public int id { get; set; }
        public int teamid1 { get; set; }
        public int teamid2 { get; set; }
        public int roundnumber { get; set; }
        public int winner { get; set; }

        public Match(int id, int teamid1, int teamid2, int roundnumber, int winner)
        {
            this.id = id;
            this.teamid1 = teamid1;
            this.teamid2 = teamid2;
            this.roundnumber = roundnumber;
            this.winner = winner;
        }
    }

}
