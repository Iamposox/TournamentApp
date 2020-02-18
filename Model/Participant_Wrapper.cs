using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournaments.WPF.Model
{
    /// <summary>
    /// Should be moved to domain layer and replayed with a Participant_Wrapper class
    /// </summary>
    public class Participant_Wrapper : TournamentBracketGenerator.Model.Participant
    {
        /// <summary>
        /// For addictional control, having ID is making some operation easier
        /// </summary>
        public Guid ID { get; set; }
    }
}
