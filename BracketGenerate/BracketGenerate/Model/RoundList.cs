using BracketGenerate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBracketGenerator.Helper;

namespace TournamentBracketGenerator.Model
{
    public delegate void QualifiedDelegate(object sender, List<IParticipant> _totalParticipant);
    public delegate void RoundEndsDelegate(object sender, ICollection<IParticipant> _winners);
    public class RoundList
    {
        private List<IParticipant> WinnersList = new List<IParticipant>();
        public event RoundEndsDelegate RoundEnded;
        public event QualifiedDelegate Qualified;
        public RoundList(ICollection<IParticipant> _participants)
        {
            GenerateMatches(_participants);
        }

        private void GenerateMatches(ICollection<IParticipant> _participants)
        {
            var match = new Game(_participants.ToArray());
            match.WinnerWasSetEvent += Match_WinnerWasSetEvent;
            // Based on the Participents and its count the Matches can be generated including pre-qualification(also based on IMatch Interface)
            // once the generation is completed, it can be add to the list of the IMatches over
            // this.AddRange(IMatches collection)
        }

        private void Match_WinnerWasSetEvent(object sender, IParticipant _winner)
        {
            WinnersList.Add(_winner);
            if (/*ensure that all matches are finished*/)
                RoundEnded.Invoke(this, WinnersList);
        }
    }
}
