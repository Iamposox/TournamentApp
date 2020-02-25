using BracketGenerate.NewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBracketGenerator.Helper;

namespace BracketGenerate
{
    public class GenerateTournament
    {
        public List<Participant> TotalParticipant = new List<Participant>();
        private int _initialPairCount;
        private int _qualificationPairCount;
        private int _roundsCount;
        public List<Pair> PreQualifyBrackets = new List<Pair>();
        private List<int> _assignedPrequilifiedBracketsId = new List<int>();
        Random rnd = new Random();

        public List<FirstRound> Rounds = new List<FirstRound>();
        public GenerateTournament(List<Participant> totalParticipant) 
        {
            TotalParticipant = totalParticipant;

        }
        public Tournament LaunchGeneration() 
        {
            CounterOfRounds();
            if (_qualificationPairCount == 0) 
            {
                FillFirstRound();
                var e = new Tournament();
                e.FirstRounds = Rounds;
                return e;
            }
            else 
            {
                generateQualifiedRounds();
                FillFirstRound();
                var e = new Tournament();
                e.FirstRounds = Rounds;
                return e;
            }
        }
        public void CounterOfRounds() 
        {
            // step 1. calculate number of brackets, prequalifier pairs and total rounds in this tournament
            //            // get total number of brackets/pairs in tournament
            _initialPairCount = TournamentCalcHelper.CalcInitialPairCount(TotalParticipant.Count);
            //            // get total number of pre-qualify pairs
            _qualificationPairCount = TournamentCalcHelper.CalcPreQualifyPairCount(TotalParticipant.Count);
            //            // get total number of rounds in this tournament
            _roundsCount = TournamentCalcHelper.CalcRounds(_initialPairCount);

        }
        public void generateQualifiedRounds() 
        {
            for (int i = 0; i < _qualificationPairCount; i++)
            {
                var bracket = new Pair() { ID = PreQualifyBrackets.Count + 1 };
                // get "luckcy" :) prequlifyer for red corner
                bracket.RedCorner = GetRandomParticipantTest(TotalParticipant, PreQualifyBrackets, PreQualifyBrackets);
                bracket.BlueCorner = GetRandomParticipantTest(TotalParticipant, PreQualifyBrackets, PreQualifyBrackets);
                PreQualifyBrackets.Add(bracket);
            }
        }
        private void FillFirstRound()
        {
            var round = Rounds.Find(r => r.ID == 1);

            for (int count = 0; count < _initialPairCount; count++)
            {
                var randomBracket = GetRandomBracket(PreQualifyBrackets, Rounds);

                var bracket = new FirstRound() { ID = Rounds.Count + 1 };
                // add new bracket to round
                Rounds.Add(bracket);
                // if we have bracket use bracket winner else use participants who didn't need qualification
                // red corner
                if (randomBracket != null)
                {
                    bracket.RedCornerPair = randomBracket;
                    _assignedPrequilifiedBracketsId.Add(randomBracket.ID);
                }
                else
                {
                    bracket.RedCorner = GetRandomParticipantTest(TotalParticipant, PreQualifyBrackets, PreQualifyBrackets);
                }
                // blue corner
                randomBracket = GetRandomBracket(PreQualifyBrackets, Rounds);
                if (randomBracket != null)
                {
                    bracket.BlueCornerPair = randomBracket;
                    _assignedPrequilifiedBracketsId.Add(randomBracket.ID);

                }
                else
                {
                    bracket.BlueCorner = GetRandomParticipantTest(TotalParticipant, PreQualifyBrackets, PreQualifyBrackets);
                }
            }
        }
        private Participant GetRandomParticipantTest
            (
                List<Participant> participantsFrom,
                List<Pair> dest,
                List<Pair> destTWO
            )
            =>
                participantsFrom
                .Where(x =>
                    !dest.Union(destTWO).SelectMany(d => new[] { d.BlueCorner?.ID, d.RedCorner?.ID }).ToList()
                    .Any(y => y == x.ID))
                .ToList()
                .Random();
        public Pair GetRandomBracketTest(List<Pair> source, List<FirstRound> dest, List<int> _countId) => (source.Count <= _countId.Count) ? null : source
            .Where(x =>
                !dest.SelectMany(d => new[] { d.RedCornerPair?.ID, d.BlueCornerPair.ID})
                .Any(y => y == x.ID))
            .ToList().Random();
        private Pair GetRandomBracket(List<Pair> sourse, List<FirstRound> dest)
        {
            // if source and dest have same count then return null
            if (sourse.Count <= _assignedPrequilifiedBracketsId.Count)
                return null;

            var id = dest.SelectMany(x => new[] { x.RedCornerPair?.ID, x.BlueCornerPair?.ID}).ToList();
            var list = sourse.Where(x => !id.Any(y => y == x.ID)).ToList();
            return list[rnd.Next(list.Count)];
        }
    }
}
