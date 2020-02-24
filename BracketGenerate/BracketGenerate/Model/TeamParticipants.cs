using BracketGenerate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerate.Model
{
    public class TeamParticipants:IParticipant 
    {
        public string DisplayName { get; set; }
        private ICollection<IParticipant> participants;
        public void add(IParticipant _participant)
        {
            participants.Add(_participant);
        }
        public TeamParticipants(ICollection<IParticipant> _participants) 
        {
            participants = _participants;
        }
        
    }
}
