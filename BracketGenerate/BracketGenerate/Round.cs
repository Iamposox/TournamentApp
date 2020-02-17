using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracketGenerator
{
    public class Round
    {
        public int RoundId { get; set; }
        public List<Bracket> Brackets { get; set; } = new List<Bracket>();
    }
}
