using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracketGenerator.Model
{
    public class LastRoundBracket : Bracket
    {

        private int _bracketRedId;
        private int _bracketBlueId;
        private Round _round;
        private bool _final = true;
        public LastRoundBracket(Round round, bool final)
        {
            _final = final;
            _round = round;
            setBrackerId();
        }
        //Any reason this is lower case?
        private void setBrackerId()
        {
            Random rnd = new Random();
            _bracketRedId = rnd.Next(0, 1);
            _bracketBlueId = _bracketRedId == 0 ? 1 : 0;
            
        }
        
        //Any reason this is lower case?
        private void setBrackets()
        {
            Random rnd = new Random();
            _bracketRedId = rnd.Next(0, 1);
            _bracketBlueId = _bracketRedId == 0 ? 1 : 0;

            RedCorner = _round.Brackets[_bracketRedId].Winner;
            BlueCorner = _round.Brackets[_bracketBlueId].Winner;


        }

        //public int RedBracketId { get { return _bracketRedId; } }
        //public int BlueBracketId { get { return _bracketBlueId; } }

        public string BlueCornerText 
        {

            get
            {
                
                var text = string.Empty;
                // get blue corner text
                var temp = _final == true ? "winner":"runnerUp";
                text = $"1/2 final bracket {_bracketBlueId+1} {temp}";
                return text;
            }

        }

        public string RedCornerText
        {
            get
            {

                var text = string.Empty;
                // get blue corner text
                var temp = _final == true ? "winner" : "runnerUp";
                text = $"1/2 final bracket {_bracketRedId+1} {temp}";
                return text;
            }

        }
        

    }
}
