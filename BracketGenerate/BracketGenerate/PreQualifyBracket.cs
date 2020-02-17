using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracketGenerator
{
    public class PreQualifyBracket 
    {
        public int PreQualifyBracketId { get; set; }
        public List<ParticipantPair> Competitors { get; set; } = new List<ParticipantPair>();
    }
}
