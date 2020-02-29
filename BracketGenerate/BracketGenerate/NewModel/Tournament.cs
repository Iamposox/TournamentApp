using BracketGenerate.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerate.NewModel
{
    public delegate void EndRounds(object sender);
    public class Tournament
    {
        public List<IMatch> FirstRounds{ get; set; }
        public event EndRounds EndRounds;
        public void FillRounds() 
        {
            EndRounds.Invoke(this);
        }
    }
}
