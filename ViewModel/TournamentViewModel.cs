using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Tournaments.WPF.Abstract;
using Tournaments.WPF.Model;

namespace Tournaments.WPF.ViewModel
{
    public class TestMainTab
    {
        public List<string> MyProperty { get; set; }

    }
    public class TournamentViewModel : Abstract.BaseViewModel
    {
        public ICommand PrintCanvasCommand { get => new RelayCommand<object>(PrintCanvas); }
        public ICommand LoadFileCommand { get => new RelayCommand(TestLoad); }
        public ICommand SaveFileCommand { get => new RelayCommand(TestSave); }
        public List<Participant_Wrapper> participants { get; set; }

        public CanvasField Grid { get; set; }

        private readonly Manager.StateManager CurrentState;

        public TournamentViewModel()
        {
            CurrentState = (Manager.StateManager)App.ServiceContainer.GetService(typeof(Manager.StateManager));
            participants = CurrentState.CurrentParticipants;
            Grid = new CanvasField(participants.Count * 2, participants.Count);
        }

        private void PrintCanvas(object _UIElement)
        {
            if (_UIElement is UIElement)
            {
                var CurrentState = (Manager.StateManager)App.ServiceContainer.GetService(typeof(Manager.StateManager));
                CurrentState.Print((UIElement)_UIElement);
            }
            else
                throw new Exception("The Print requered a UI Element Parameter which should be printed");
        }

        private void TestLoad()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                CurrentState.CurrentParticipants = JsonConvert.DeserializeObject<List<Participant_Wrapper>>(File.ReadAllText(openFileDialog.FileName));
        }

        private void TestSave()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(CurrentState.CurrentParticipants, Formatting.Indented));
        }


    }
}
