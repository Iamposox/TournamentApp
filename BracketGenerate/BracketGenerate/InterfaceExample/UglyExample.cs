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

    }

    public interface IPosition { }

    public interface IParticipent { }
    #endregion

    public class RoundList : List<IMatch>
    {
        public RoundList(List<IParticipent> _participents)
        {
            GenerateMatches(_participents);
        }

        private void GenerateMatches(List<IParticipent> _participents)
        {
            // Based on the Participents and its count the Matches can be generated including pre-qualification(also based on IMatch Interface)
            // once the generation is completed, it can be add to the list of the IMatches over
            // this.AddRange(IMatches collection)
        }
    }

    public class Match : IMatch
    {
        private IParticipent RedCorder;
        private IParticipent BlueCorder;
        private IParticipent Winner;
        public Match(IParticipent[] _participents)
        {
            RedCorder = _participents[0];
            BlueCorder = _participents[1];
        }

        public void AssignTheWinner(IParticipent _participent)
        {
            Winner = _participent;
        }

        public IParticipent GetWinner()
            => Winner is null ?
                throw new Exception("Winner not assigned") :
                Winner;
    }


}
