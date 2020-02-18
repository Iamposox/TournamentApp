using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournaments.WPF.Manager
{
    public class StateManager
    {
        public List<Model.Participant> CurrentParticipants { get; }

        public StateManager()
        {
            CurrentParticipants = new List<Model.Participant>();
        }
    }
}
