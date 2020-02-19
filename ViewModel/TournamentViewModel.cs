using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TournamentBracketGenerator;
using TournamentBracketGenerator.Model;
using Tournaments.WPF.Abstract;
using Tournaments.WPF.Model;

namespace Tournaments.WPF.ViewModel
{
    public class TournamentViewModel : Abstract.BaseViewModel
    {
        public ICommand LoadFileCommand { get => new RelayCommand(TestLoad); }
        public ICommand SaveFileCommand { get => new RelayCommand(TestSave); }
        public List<Participant_Wrapper> participants { get; set; }

        public CanvasField Grid { get; set; } 

        public TournamentViewModel()
        {

            var CurrentState = (Manager.StateManager)App.ServiceContainer.GetService(typeof(Manager.StateManager));
            participants = CurrentState.CurrentParticipants;
            Grid = new CanvasField(participants.Count * 2, participants.Count);
        }



        private void TestLoad()
        {
            var CurrentState = (Manager.StateManager)App.ServiceContainer.GetService(typeof(Manager.StateManager));
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                CurrentState.CurrentParticipants = JsonConvert.DeserializeObject<List<Participant_Wrapper>>(File.ReadAllText(openFileDialog.FileName));
        }

        private void TestSave()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            var CurrentState = (Manager.StateManager)App.ServiceContainer.GetService(typeof(Manager.StateManager));
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(CurrentState.CurrentParticipants, Formatting.Indented));
        }


    }
}
