using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerate.NewModel
{
    public class Team : Interface.IParticipant
    {
        public string TeamName { get; set; }
        public List<Interface.IParticipant> TeamMember { get; set; }
        private Guid _guid => Guid.NewGuid();
        public Guid ID { get => _guid; }

        public string DisplayName() => TeamName;        

        public string DisplayDetailedName()
        {
            var result =new StringBuilder();
            result.Append(TeamName);
            foreach (var item in TeamMember)
            {
                result.Append(item.DisplayDetailedName());
            }
            return result.ToString();
        }
    }
}
