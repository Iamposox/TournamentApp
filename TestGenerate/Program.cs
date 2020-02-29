using System;
using System.Collections.Generic;
using Tournaments.WPF.Model;
using BracketGenerate;
using System.Linq;
using BracketGenerate.NewModel;
using System.Threading.Tasks;
using BracketGenerate.Interface;

namespace TestGenerate
{
    class Program
    {
        public static List<IParticipant> CurrentParticipants { get; set; } = new List<IParticipant>();
        private static int i;
        static async Task Main(string[] args)
        {
            SeedCrap();
            var tournament = new GenerateTournament(CurrentParticipants);
            var matchesTeam = tournament.LaunchGeneration();
            var firstTeamMatches = matchesTeam.FirstRounds;
            for (i = 0; i < firstTeamMatches.Count; i++) 
            {
                firstTeamMatches[i].EndMatch += EndMatches;
                firstTeamMatches[i].SetWinnerOfThePair(matchesTeam.FirstRounds[i].RedCornerPair.RedCorner);

            }
            matchesTeam.EndRounds += EndRounds;
            matchesTeam.FillRounds();
            SeedCrap();
            var tour = new GenerateTournament(CurrentParticipants);
            var matches = tour.LaunchGeneration();
            var firstmatches = matches.FirstRounds;
            for(i=0; i < firstmatches.Count; i++) 
            {
                firstmatches[i].EndMatch += EndMatches;
                firstmatches[i].SetWinnerOfThePair(matches.FirstRounds[i].RedCorner);
            }
            matches.EndRounds += EndRounds;
            matches.FillRounds();
            #region task 
            //var Matches = SetPairs(CurrentParticipants);
            await Task.Run(async () =>
            {
                while (true)
                {
                    Console.WriteLine("App is running");
                    //AssignedRandomMatchWinner(Matches);
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
                Console.WriteLine(d.FirstRounds[i].RedCorner.DisplayName() + "-" + d.FirstRounds[i].BlueCorner.DisplayName());
            }


            Console.ReadLine();
            #endregion
        }
        public static void EndMatches(object sender, IParticipant participant)
        {
            Console.WriteLine($"Победитель в паре {i} {participant.DisplayDetailedName()}");
        }
        public static void EndRounds(object sender)
        {
            Console.WriteLine($"Все победители в раунде назначены");
        }
        private static void AssignedRandomMatchWinner(List<Match> _matches)
        {
            Random Rnd = new Random();
            Task.Run(async () =>
            {
                await Task.Delay(200);
                Console.WriteLine("200 passed");
                int index = Rnd.Next(_matches.Count);
                //_matches[index].SetWinnerOfThePair(_matches[index].RedCorner);
            });
        }
        private static void Match_MatchEnded(object _sender, Participant _winner)
        {
            Console.WriteLine(_winner.FirstName);
        }
        private static void SeedCrap()
        {
            for (int i = 0; i < 5; i++)
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
