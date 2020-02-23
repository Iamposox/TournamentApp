using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerate.InterfaceExample
{
    #region Interfaces
    public interface IMatch
    {
        IParticipent RedCorder { get; }
        IParticipent BlueCorder { get; }
    }

    public interface IPosition { }

    public interface IParticipent 
    {
        string DisplayName { get; set; }
    }
    #endregion

    public delegate void MatchUpdateDelegate(object sender, IParticipent _winner);
    public delegate void RoundEndsDelegate(object sender, ICollection<IParticipent> _winners);

    public class RoundList : List<IMatch>
    {
        private List<IParticipent> WinnersList = new List<IParticipent>();
        public event RoundEndsDelegate RoundEnded;
        public RoundList(ICollection<IParticipent> _participents)
        {
            GenerateMatches(_participents);
        }

        private void GenerateMatches(ICollection<IParticipent> _participents)
        {
            var match = new Match(_participents.ToArray());
            match.WinnerWasSetEvent += Match_WinnerWasSetEvent;
            // Based on the Participents and its count the Matches can be generated including pre-qualification(also based on IMatch Interface)
            // once the generation is completed, it can be add to the list of the IMatches over
            // this.AddRange(IMatches collection)
        }

        private void Match_WinnerWasSetEvent(object sender, IParticipent _winner)
        {
            WinnersList.Add(_winner);
            if (/*ensure that all matches are finished*/)
                RoundEnded.Invoke(this, WinnersList);
        }


    }

    public class Match : IMatch, IEquatable<IMatch>
    {
        public IParticipent RedCorder { get; }
        public IParticipent BlueCorder { get; }
        
        private IParticipent Winner;
        
        public event MatchUpdateDelegate WinnerWasSetEvent;

        public Match(IParticipent[] _participents)
        {
            RedCorder = _participents[0];
            BlueCorder = _participents[1];
        }

        public void AssignTheWinner(IParticipent _participent)
        {
            Winner = _participent;
            WinnerWasSetEvent.Invoke(this, Winner);
        }

        //We need this in order to compair two instances of the Match
        public bool Equals(IMatch other)
        {
            if (RedCorder.DisplayName == other.RedCorder.DisplayName)
                return true;
            return false;
        }
    }


}
