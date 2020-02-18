using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TournamentBracketGenerator;
using TournamentBracketGenerator.Model;

namespace Tournaments.WPF.ViewModel
{
    public class ParticipantListViewModel : Abstract.BaseViewModel
    {
        public ICommand AddNewParticipantCommand { get; set; }
        public ICommand RemoveParticipantCommand { get; set; }

        public ObservableCollection<Participant> Participants { get; set; }

        private readonly Manager.StateManager CurrentState;
        public ParticipantListViewModel()
        {
            CurrentState = (Manager.StateManager)App.ServiceContainer.GetService(typeof(Manager.StateManager));
            SeedCrap();

            Participants = new ObservableCollection<Participant>(CurrentState.CurrentParticipants);

        }

        private void SeedCrap()
        {
            for (int i = 0; i < 64; i++)
            {
                CurrentState.CurrentParticipants.Add(new Participant
                {
                    Name = "SomeName",
                    LastName = "SomeLastName",
                    Patronymic = "SomePatronymic"
                });
            }

        }
    }
}
