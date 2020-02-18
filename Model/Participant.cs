using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournaments.WPF.Model
{
    /// <summary>
    /// Should be moved to domain layer and replayed with a Participant_Wrapper class
    /// </summary>
    public class Participant
    {
        /// <summary>
        /// For addictional control, having ID is making some operation easier
        /// </summary>
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        /// <summary>
        /// I am not quite sure which format you prefer.
        /// Regardless this will be better to devine in UI and not over method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} {Patronymic} {LastName}";
        }
    }
}
