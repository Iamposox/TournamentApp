using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerate.Interface
{
    public interface IParticipant
    {
        Guid ID { get; }
        string DisplayName();
        string DisplayDetailedName();
    }
}
