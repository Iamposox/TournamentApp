using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBracketGenerator.Helper;

namespace BracketGenerate.NewModel
{
    public class FirstRound:List<Pair>
    {
        public Pair BlueCornerPair { get; set; }
        public Pair RedCornerPair { get; set; }
        public Participant BlueCorner { get; set; }
        public Participant RedCorner { get; set; }
        public int ID { get; set; }
    }
}
