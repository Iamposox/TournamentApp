using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tournaments.WPF.ViewModel
{
    public class ParticipantListViewModel:Abstract.BaseViewModel
    {
        public ICommand AddNewParticipantCommand { get; set; }
        public ICommand RemoveParticipantCommand { get; set; }

        public ObservableCollection<Model.Participant> Participants { get; set; } = new ObservableCollection<Model.Participant>
        {
            new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },new Model.Participant
            {
                Name= "SomeName",
                LastName ="SomeLastName",
                Patronymic = "SomePatronymic"
            },
        };
    }
}
