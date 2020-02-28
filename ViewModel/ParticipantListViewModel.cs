using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TournamentBracketGenerator;
using BracketGenerate.NewModel;
using Tournaments.WPF.Model;

namespace Tournaments.WPF.ViewModel
{
    public class ParticipantListViewModel : Abstract.BaseViewModel
    {
        public ICommand AddNewParticipantCommand { get; set; }
        public ICommand RemoveParticipantCommand { get; set; }

        public ObservableCollection<Participant_Wrapper> Participants { get; set; }

        private readonly Manager.StateManager CurrentState;
        public ParticipantListViewModel()
        {
            CurrentState = (Manager.StateManager)App.ServiceContainer.GetService(typeof(Manager.StateManager));
            Participants = new ObservableCollection<Participant_Wrapper>(CurrentState.CurrentParticipants);

        }

       
    }
}
