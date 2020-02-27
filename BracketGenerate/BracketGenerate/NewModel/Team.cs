using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerate.NewModel
{
    public class Team
    {
        public string TeamName { get; set; }
        public List<Participant> ParticipantName { get; set; }
        private Guid _guid => Guid.NewGuid();
        public Guid ID { get => _guid; }
    }
}
