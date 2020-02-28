using BracketGenerate.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerate.NewModel
{
    public class Match
    {
        public IParticipant BlueCorner { get; set; }
        public IParticipant RedCorner { get; set; }
        public Team BlueCornerTeam { get; set; }
        public Team RedCornerTeam { get; set; }
        public TeamUnion UnionBlue { get; set; }
        public TeamUnion UnionRed { get; set; }
        //Class Pair (even tho i am convice that Match is better name
        //Doesnt need to hold objects of next pair
        //Also it doesnt make sense that it hold two pairs.
        //Please decribe the logic
        public Match BlueCornerPair { get; set; }
        public Match RedCornerPair { get; set; }

        //use this type of comments please
        /// <summary>
        /// Pair ID
        /// </summary>
        public int ID { get; set; }

        //see this is why Match would sound better
        
        public Match() { }
        public Match(Participant one, Participant two) 
        {
            BlueCorner = one;
            RedCorner = two;
        }
    }
}
