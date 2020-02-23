using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBracketGenerator.Helper;
using TournamentBracketGenerator.Model;

namespace BracketGenerate
{
    public class BracketOperation
    {
        public Bracket GetRandomBracket(List<Bracket> sourse, List<Bracket> dest, List<int> _countId)
        {
            // if source and dest have same count then return null
            if (sourse.Count <= _countId.Count)
                return null;

            var id = dest.SelectMany(x => new[] { x.RedCornerBracket?.BracketId, x.BlueCornerBracket?.BracketId }).ToList();
            var list = sourse.Where(x => !id.Any(y => y == x.BracketId)).Random();
            return list;

        }
        public Bracket GetRandomBracketTest(List<Bracket> source, List<Bracket> dest, List<int> _countId) => (source.Count<=_countId.Count)?null:source
            .Where(x => 
                !dest.SelectMany(d => new[] { d.RedCornerBracket?.BracketId, d.BlueCornerBracket.BracketId })
                .Any(y => y == x.BracketId))
            .ToList().Random();
    }
}
