using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBracketGenerator.Helper;
using TournamentBracketGenerator.Model;

namespace BracketGenerate
{
    public class ParticipantOperator
    {
        TimeSpan TimeSpanOriginalTimer = new TimeSpan();
        TimeSpan TimeSpanInlineTimer = new TimeSpan();
        Stopwatch stopwatch = new Stopwatch();
        Stopwatch stopwatch2 = new Stopwatch();

        private Participant GetRandomParticipant(List<Participant> participantsFrom, List<Bracket> dest, List<Bracket> destTWO)
        {
            stopwatch.Start();
            var Id = dest.Union(destTWO).SelectMany(x => new[] { x.BlueCorner?.ID, x.RedCorner?.ID }).ToList();
            var result = participantsFrom.Where(x => !Id.Any(y => y == x.ID)).Random();

            stopwatch.Stop();
            TimeSpanOriginalTimer = TimeSpanOriginalTimer.Add(stopwatch.Elapsed);

            stopwatch2.Start();
            GetRandomParticipantTest(participantsFrom, dest, destTWO);
            stopwatch2.Stop();
            TimeSpanInlineTimer = TimeSpanInlineTimer.Add(stopwatch2.Elapsed);

            return result;
        }

        public Participant GetRandomParticipantTest
            (
                List<Participant> participantsFrom,
                List<Bracket> dest,
                List<Bracket> destTWO
            )
            =>
                participantsFrom
                .Where(x =>
                    !dest.Union(destTWO).SelectMany(d => new[] { d.BlueCorner?.ID, d.RedCorner?.ID }).ToList()
                    .Any(y => y == x.ID))
                .ToList()
                .Random();
    }
}
