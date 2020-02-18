using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBracketGenerator.Model;

namespace TournamentBracketGenerator
{
    public class Bracket
    {
        public int BracketId { get; set; }
        //public List<ParticipantPair> Competitors { get; set; } = new List<ParticipantPair>();
        public Participant RedCorner { get; set; }
        public Participant BlueCorner { get; set; }
        public Bracket RedCornerBracket { get; set; }
        public Bracket BlueCornerBracket { get; set; }
        public Participant Winner { get; set; }

        public Participant RunnerUp { get; set; }
        private string _winnerName = string.Empty;
        private string _sectionRed = string.Empty;
        private string _sectionBlue = string.Empty;

        public string WinnerName
        {
            get
            {
                if(!string.IsNullOrWhiteSpace(_sectionRed) && !string.IsNullOrWhiteSpace(_sectionBlue))
                {
                    _winnerName = _sectionRed + _sectionBlue;
                }
                //Switch case doesnt exists (not mentioning pattern matching)....
                if (string.IsNullOrWhiteSpace(_winnerName))
                {
                    if (Winner == null)
                    {
                        if(RedCorner != null)
                        {
                            _sectionRed = $"Winner of : {RedCorner.FullName} / ";
                        }
                        else if(RedCornerBracket != null)
                        {
                            _sectionRed = $"Winner of : Bracket {RedCornerBracket.BracketId} {RedCornerBracket.WinnerName} | ";
                        }
                        if (BlueCorner != null)
                        {
                            _sectionBlue = $"{BlueCorner.FullName}";
                        }
                        else if(BlueCornerBracket != null)
                        {
                            _sectionBlue = $"Bracket {BlueCornerBracket.BracketId} {BlueCornerBracket.WinnerName}";
                        }
                    }
                    else
                    {
                        _winnerName = $"{Winner.FullName}";
                    }
                }
                return _winnerName;


            }
        }
    }
}
