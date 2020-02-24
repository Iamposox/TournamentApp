using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerate.Interfaces
{
    public interface IGame
    {
        IParticipant RedCorner { get; }
        IParticipant BlueCorner { get; }
    }
}
