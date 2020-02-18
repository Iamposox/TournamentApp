using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tournaments.WPF.ViewModel
{
    public class ParticipantListViewModel : Abstract.BaseViewModel
    {
        public ICommand AddNewParticipantCommand { get; set; }
        public ICommand RemoveParticipantCommand { get; set; }

        public ObservableCollection<Model.Participant> Participants { get; set; }

        private readonly Manager.StateManager CurrentState;
        public ParticipantListViewModel()
        {
            CurrentState = (Manager.StateManager)App.ServiceContainer.GetService(typeof(Manager.StateManager));
            SeedCrap();

            Participants = new ObservableCollection<Model.Participant>(CurrentState.CurrentParticipants);

        }

        private void SeedCrap()
        {
            for (int i = 0; i < 64; i++)
            {
                CurrentState.CurrentParticipants.Add(new Model.Participant
                {
                    Name = "SomeName",
                    LastName = "SomeLastName",
                    Patronymic = "SomePatronymic"
                });
            }

        }
    }
}
