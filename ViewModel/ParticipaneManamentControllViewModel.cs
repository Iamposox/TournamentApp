using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournaments.WPF.ViewModel
{
    public class ParticipaneManamentControllViewModel
    {
        public List<Type> AvalableTypes { get; set; } = new List<Type>();

        public ParticipaneManamentControllViewModel()
        {
            //var type = typeof(IParticipant);
            //AvalableTypes = AppDomain.CurrentDomain.GetAssemblies()
                //.SelectMany(s => s.GetTypes())
               // .Where(p => type.IsAssignableFrom(p))
               // .ToList();
        }
    }
}
