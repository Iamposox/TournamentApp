using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerate.NewModel
{
    public class TeamUnion
    {
        public Team TeamOne { get; set; }
        public Team TeamTwo { get; set; }
        private Guid _ID = Guid.NewGuid();
        public Guid ID { get => _ID; }
    }
}
