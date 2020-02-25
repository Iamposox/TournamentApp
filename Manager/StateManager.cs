using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentBracketGenerator;
using TournamentBracketGenerator.Model;
using Tournaments.WPF.Interface;
using Tournaments.WPF.Model;

namespace Tournaments.WPF.Manager
{
    public class StateManager
    {
        public List<Participant_Wrapper> CurrentParticipants { get; set; }
        private readonly IPrintingService m_PrintingService;
        
        public StateManager(IPrintingService _printSevice)
        {
            m_PrintingService = _printSevice;
            CurrentParticipants = new List<Participant_Wrapper>();
            SeedCrap();

            var e = new Tournament(CurrentParticipants.Select(x => x.Model).ToList());
            //e.GenerateTournamemtBrackets();
        }
        
        public void Print(UIElement _elementToPrint)
        {
            m_PrintingService.TryPrintData(_elementToPrint, "Test");
        }
        private void SeedCrap()
        {
            for (int i = 0; i < 64; i++)
            {
                CurrentParticipants.Add
                    (
                        new Participant_Wrapper
                        (
                            _participant: new Participant()
                            {
                                Name = "SomeName",
                                LastName = "SomeLastName",
                                Patronymic = "SomePatronymic",
                            },
                            _id:+1
                        )
                    );
            }
        }
    }
}
