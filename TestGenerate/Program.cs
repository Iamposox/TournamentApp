using BracketGenerate.Model;
using BracketGenerate.Interfaces;
using System;
using System.Collections.Generic;
using Tournaments.WPF.Model;
using BracketGenerate;
using System.Linq;
using BracketGenerate.NewModel;

namespace TestGenerate
{
    class Program
    {
        public static List<Participant> CurrentParticipants { get; set; }
        static void Main(string[] args)
        {
            CurrentParticipants = new List<Participant>();
            SeedCrap();

            var e = new MainClass(CurrentParticipants);
            e.start();
        }
        private static void SeedCrap()
        {
            for (int i = 0; i < 63; i++)
            {
                CurrentParticipants.Add
                    (
                       new Participant()
                            {
                                FirstName = "SomeName",
                                LastName = "SomeLastName",
                                Patronymic = "SomePatronymic",
                            }
                    );
            }
        }
    }
}
