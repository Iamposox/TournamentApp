using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracketGenerator.Model
{
    public class Participant
    {
        public Participant()
        {
        }

        public Participant(string name, string lastName, string patronymic)
        {
            Name = name;
            LastName = lastName;
            Patronymic = patronymic;
        }

        public string Patronymic { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }
        private Guid _ID = Guid.NewGuid();
        public Guid ID { get => _ID; }
        public interface IParticipent
        {
            string DisplayName { get; set; }
        }
    }
}
