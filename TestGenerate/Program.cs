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
            var e = new TestGenerate.Program();
            e.generate();
        }
        private void generate()
        {
            Console.WriteLine($"Турнирная таблица 1/32");
            CurrentParticipants = new List<Participant_Wrapper>();
            SeedCrap();
            Tournament tour = new Tournament(CurrentParticipants.Select(x => x.Model).ToList());
            tour.GenerateTournamemtBrackets();
            for (int i = 0; i < tour.Rounds[0].Brackets.Count; i++)
            {
                Console.WriteLine(tour.Rounds[0].Brackets[i].BlueCorner.LastName + " - " + tour.Rounds[0].Brackets[i].RedCorner.LastName);
            }
            Console.WriteLine("1 / 16");
            for (int i = 0; i < tour.Rounds[1].Brackets.Count; i++)
            {
                Console.WriteLine(tour.Rounds[1].Brackets[i].BlueCornerBracket.BlueCorner.LastName + "/" + tour.Rounds[1].Brackets[i].BlueCornerBracket.RedCorner.LastName + " - " + tour.Rounds[1].Brackets[i].RedCornerBracket.BlueCorner.LastName + "/" + tour.Rounds[1].Brackets[i].RedCornerBracket.RedCorner.LastName);
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
