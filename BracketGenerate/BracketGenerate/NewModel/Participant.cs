using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerate.NewModel
{
    public class Participant : IEquatable<Participant>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string FullName { get; set; }
        private Guid _ID = Guid.NewGuid();
        public Guid ID { get => _ID; }

        public Participant(string name) => FirstName = name;
        public Participant(string firstName, string lastName, string patronymic)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            FullName = $"{firstName} {lastName} {patronymic}";
        }
        public Participant() { }

        //public override bool Equals(object obj)
        //{
        //    if (obj is Participant)
        //        return Equals((Participant)obj);
        //    return false;
        //}

        public override int GetHashCode()
        {
            return 1213502048 + ID.GetHashCode();
        }

        public bool Equals(Participant other)
        {
            return other is Participant participant &&
                              ID.Equals(participant.ID);
        }
    }
}
