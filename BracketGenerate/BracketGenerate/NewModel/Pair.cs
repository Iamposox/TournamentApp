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
        public Pair BlueCornerPair { get; set; }
        public Pair RedCornerPair { get; set; }
        public int ID { get; set; }//number of pair
    }
}
