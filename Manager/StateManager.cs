using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBracketGenerator;
using TournamentBracketGenerator.Model;
using Tournaments.WPF.Model;

namespace Tournaments.WPF.Manager
{
    public class StateManager
    {
        public List<Participant> CurrentParticipants { get; set; }
        public StateManager()
        {
            CurrentParticipants = new List<Participant>();
        }
    }
}
