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
        public static List<Team> CurrentTeam { get; set; }
        public static List<TeamUnion> CurTeam { get; set; }
        private static int i;
        static async Task Main(string[] args)
        {
            CurTeam = new List<TeamUnion>();
            CurrentTeam = new List<Team>();
            CurrentParticipants = new List<Participant>();
            SeedCrap();
            SeedTeam();
            SeedTeamUnion();
            var tournament = new GenerateTournament(CurTeam);
            var matchesTeam = tournament.LaunchGenerationForUnion();
            var firstTeamMatches = matchesTeam.FirstRounds;
            for (i = 0; i < firstTeamMatches.Count; i++) 
            {
                firstTeamMatches[i].EndMatch += EndMatches;
                firstTeamMatches[i].SetWinnerOfThePair(matchesTeam.FirstRounds[i].RedCorner);

            }
            matchesTeam.EndRounds += EndRounds;
            matchesTeam.FillRounds();
            SeedCrap();
            var tour = new GenerateTournament(CurrentParticipants);
            var matches = tour.LaunchGenerationForParticipant();
            var firstmatches = matches.FirstRounds;
            for(i=0; i < firstmatches.Count; i++) 
            {
                firstmatches[i].EndMatch += EndMatches;
                firstmatches[i].SetWinnerOfThePair(matches.FirstRounds[i].RedCorner);
            }
            matches.EndRounds += EndRounds;
            matches.FillRounds();
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
            var d = e.LaunchGenerationForParticipant();
            for (int i = 0; i < e.Rounds.Count; i++)
            {
                Console.WriteLine(d.FirstRounds[i].RedCorner.LastName + "-" + d.FirstRounds[i].BlueCorner.LastName);
            }


            Console.ReadLine();
            #endregion
        }
        public static void EndMatches(object sender, Participant participant)
        {
            Console.WriteLine($"Победитель в паре {i} {participant.FullName}");
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
        
        public static void SeedTeamUnion() 
        {
            for (int i=0;i<64; i++) 
            {
                CurTeam.Add(new TeamUnion()
                {
                    TeamOne = CurrentTeam[i],
                    TeamTwo = CurrentTeam[i+1]
                });
                i++;
            }
        }
        private static void SeedTeam() 
        {
            for(int i = 0; i < 64; i++) 
            {
                CurrentTeam.Add(new Team()
                {
                    TeamName = "SomeTeamName"+i.ToString(),
                    TeamMember = CurrentParticipants
                });
            }
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
