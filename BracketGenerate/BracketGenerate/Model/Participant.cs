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
        public Participant() { }

        public Participant(string fullName)
        {
            FullName = fullName;
        }

        public Participant(string fullName, int id)
        {
            FullName = fullName;
            ID = id;
        }

        public Participant(string fullName, int id, short weight)
        {
            FullName = fullName;
            ID = id;
            Weight = weight;
        }

        public string Patronymic { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }


        public string FullName { get; set; }


        public int ID { get; set; }
        public short Weight { get; set; }

    }
}
