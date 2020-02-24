using BracketGenerate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracketGenerator.Model
{
    public delegate void MatchUpdateDelegate(object sender, IParticipant _winner);
    public class Game : IGame, IEquatable<IGame>
    {
        public IParticipant RedCorner { get; }
        public IParticipant BlueCorner { get; }

        private IParticipant Winner;

        public event MatchUpdateDelegate WinnerWasSetEvent;

        public Game(IParticipant[] _participents)
        {
            RedCorner = _participents[0];
            BlueCorner = _participents[1];
        }

        public void AssignTheWinner(IParticipant _participent)
        {
            Winner = _participent;
            WinnerWasSetEvent.Invoke(this, Winner);
        }

        //We need this in order to compair two instances of the Match
        public bool Equals(IGame other)
        {
            if (RedCorner.DisplayNames == other.RedCorner.DisplayNames)
                return true;
            return false;
        }
    }
}
