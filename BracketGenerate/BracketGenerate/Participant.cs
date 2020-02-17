using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracketGenerator
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
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

        public string FullName { get; set; }
        public int ID { get; set; }
        public short Weight { get; set; }

    }
}
