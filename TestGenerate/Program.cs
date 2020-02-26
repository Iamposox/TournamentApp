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
        private static int number;
        static async Task Main(string[] args)
        {
            CurrentParticipants = new List<Participant>();
            SeedCrap();
            var tour = new GenerateTournament(CurrentParticipants);
            var matches = tour.LaunchGeneration();
            Console.WriteLine("Выберите пару");
            number = Convert.ToInt32(Console.ReadLine());
            var onematch = new Match(matches.FirstRounds[number - 1].BlueCorner, matches.FirstRounds[number - 1].RedCorner);
            onematch.EndMatch += EndMatches;
            onematch.SetWinnerOfThePair(matches.FirstRounds[number-1].RedCorner);
            #region task 
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
            #endregion
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
        public static void EndMatches(object sender, Participant participant)
        {
            Console.WriteLine($"Победитель в паре {number} {participant.FullName}");
        }
        private static void AssignedRandomMatchWinner(List<Match> _matches)
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

        private static List<Match> SetPairs(List<Participant> _users)
        {
            var result = new List<Match>();
            for (int i = 0; i < _users.Count; i += 2)
            {
                result.Add(new Match() { RedCorner = _users[i], BlueCorner = _users[i + 1] });
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
                       new Participant("SomeName", "SomeLastName", "SomePatronymic")
                       {
                           //FirstName = "SomeName",
                           //LastName = "SomeLastName",
                           //Patronymic = "SomePatronymic",
                       }
                    );
            }
        }
    }
}
