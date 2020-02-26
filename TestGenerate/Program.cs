using BracketGenerate.Model;
using BracketGenerate.Interfaces;
using System;
using System.Collections.Generic;
using Tournaments.WPF.Model;
using BracketGenerate;
using System.Linq;
using BracketGenerate.NewModel;
using System.Threading.Tasks;

namespace TestGenerate
{
    class Program
    {
        public static List<Participant> CurrentParticipants { get; set; }
        static async Task Main(string[] args)
        {
            CurrentParticipants = new List<Participant>();
            SeedCrap();
            var Matches = SetPairs(CurrentParticipants);
            await Task.Run(async () =>
            {
                while (true)
                {
                    Console.WriteLine("App is running");
                    AssignedRandomMatchWinner(Matches);
                    await Task.Delay(1000);

                    //Enter code here. how and more importain you want to check the 
                    //Changes in the Pair List states
                }
            });
            #region something
            var e = new GenerateTournament(CurrentParticipants);
            var d = e.LaunchGeneration();
            for (int i = 0; i < e.Rounds.Count; i++)
            {
                Console.WriteLine(d.FirstRounds[i].RedCorner.LastName + "-" + d.FirstRounds[i].BlueCorner.LastName);
            }


            Console.ReadLine();
            #endregion
        }

        private static void AssignedRandomMatchWinner(List<Pair> _matches)
        {
            Random Rnd = new Random();
            Task.Run(async () =>
            {
                await Task.Delay(200);
                Console.WriteLine("200 passed");
                int index = Rnd.Next(_matches.Count);
                _matches[index].SetWinnerOfThePair(_matches[index].RedCorner);
            });
        }

        private static List<Pair> SetPairs(List<Participant> _users)
        {
            var result = new List<Pair>();
            for (int i = 0; i < _users.Count; i += 2)
            {
                result.Add(new Pair() { RedCorner = _users[i], BlueCorner = _users[i + 1] });
            }
            return result;

        }

        private static void Match_MatchEnded(object _sender, Participant _winner)
        {
            Console.WriteLine(_winner.FirstName);
        }

        private static void SeedCrap()
        {
            for (int i = 0; i < 64; i++)
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
