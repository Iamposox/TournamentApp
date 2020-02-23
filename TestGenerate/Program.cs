using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBracketGenerator;
using TournamentBracketGenerator.Model;
using Tournaments.WPF.Model;

namespace TestGenerate
{
    class Program
    {
        public List<Participant_Wrapper> CurrentParticipants { get; set; }

        static void Main(string[] args)
        {
            //WHY???????????????
            //Why are you creating the the Program in Main if main is in programm ?
            var e = new TestGenerate.Program();
            e.generate();
        }
        private void generate()
        {
            Console.WriteLine($"Турнирная таблица 1/32");

            ///Why do you need Wrapper ???
            CurrentParticipants = new List<Participant_Wrapper>();
            SeedCrap();

            //Okay, but why did you used Wrapper and complicated your code ???
            Tournament CurrentTournament = new Tournament(CurrentParticipants.Select(x => x.Model).ToList());

            // Why didn it do it on ctor ? what the advatage of having it as seperate method?
            CurrentTournament.GenerateTournamemtBrackets();

            //This looks more like First MatchUp. Running it over "Round" is kind of confusing
            //in my opinion
            for (int i = 0; i < CurrentTournament.Rounds[0].Brackets.Count; i++)
            {
                Console.WriteLine(
                    CurrentTournament.Rounds[0].Brackets[i].BlueCorner.LastName + " - " 
                    + CurrentTournament.Rounds[0].Brackets[i].RedCorner.LastName);
            }
            Console.WriteLine("1 / 16");
            
            //WATTTTTT?
            //If I understood correctly you wanted to display {winner of first rounds} are competing with each other?
            for (int i = 0; i < CurrentTournament.Rounds[1].Brackets.Count; i++)
            {
                Console.WriteLine(
                    CurrentTournament.Rounds[1].Brackets[i].BlueCornerBracket.BlueCorner.LastName + "/"+ 
                    CurrentTournament.Rounds[1].Brackets[i].BlueCornerBracket.RedCorner.LastName + " - " + 
                    CurrentTournament.Rounds[1].Brackets[i].RedCornerBracket.BlueCorner.LastName + "/" + 
                    CurrentTournament.Rounds[1].Brackets[i].RedCornerBracket.RedCorner.LastName);
            }
            
            Console.ReadKey();
        }
        private void SeedCrap()
        {
            for (int i = 0; i < 64; i++)
            {
                CurrentParticipants.Add
                    (
                        new Participant_Wrapper
                        (
                            _participant: new Participant()
                            {
                                Name = "SomeName",
                                LastName = "SomeLastName",
                                Patronymic = "SomePatronymic",
                            },
                            _id: +1
                        )
                    );
            }
        }
    }
}
