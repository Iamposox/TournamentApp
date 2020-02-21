using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TournamentBracketGenerator.Helper;
using TournamentBracketGenerator.Model;

namespace TournamentBracketGenerator
{
    //This class is too long actually. 
    //It seems it breaks Open/Close and Single Responsobility Princibles
    public class Tournament
    {
        public Tournament(List<Participant> totalParticipants)
        {
            TotalParticipants = totalParticipants;
        }

        [ComVisible(true)]
        public List<Participant> TotalParticipants;
        [ComVisible(true)]
        public List<Bracket> Brackets  = new List<Bracket>();
        [ComVisible(true)]
        public List<Bracket> PreQualifyBrackets = new List<Bracket>();
        [ComVisible(true)]
        public List<Round> Rounds  = new List<Round>();
        [ComVisible(true)]
        public LastRoundBracket FinalBracket;
        [ComVisible(true)]
        public LastRoundBracket ThirdPlace;

        private int _initialBracketsCount;
        private int _preQualifiedBracketsCount;
        private int _tournamentRoundsCount;
        private List<int> _assignedPrequilifiedBracketsId = new List<int>();


        [ComVisible(true)]
        public void GenerateTournamemtBrackets()
        {
            // step 1. calculate number of brackets, prequalifier pairs and total rounds in this tournament
            // get total number of brackets/pairs in tournament
            _initialBracketsCount = TournamentCalcHelper.CalcInitialPairCount(TotalParticipants.Count);
            // get total number of pre-qualify pairs
            _preQualifiedBracketsCount = TournamentCalcHelper.CalcPreQualifyPairCount(TotalParticipants.Count);
            // get total number of rounds in this tournament
            _tournamentRoundsCount = TournamentCalcHelper.CalcRounds(_initialBracketsCount);

            // step 2. fill rounds
            FillRounds();
            FinalBracket = new LastRoundBracket(Rounds[_tournamentRoundsCount - 1], true);
            ThirdPlace = new LastRoundBracket(Rounds[_tournamentRoundsCount - 1], false);
        }

        private void FillRounds()
        {
            // first need to fill pre-qualifiers if such exist
            FillPreQualifiers();
            // create all rounds
            for (int iRound = 1; iRound <= _tournamentRoundsCount; iRound++)
            {
                Rounds.Add(new Round() { RoundId = iRound });
            }
            // process first round
            FillFirstRound();
            AssignSubsequentRounds();
        }
        //Personaly I prefer Single Line Return 
        private void FillPreQualifiers()
        {
            for (int i = 0; i < _preQualifiedBracketsCount; i++)
            {
                var bracket = new Bracket() { BracketId = PreQualifyBrackets.Count + 1 };
                // get "luckcy" :) prequlifyer for red corner
                bracket.RedCorner = GetRandomParticipant(TotalParticipants, PreQualifyBrackets, PreQualifyBrackets);
                PreQualifyBrackets.Add(bracket);
                bracket.BlueCorner = GetRandomParticipant(TotalParticipants, PreQualifyBrackets, PreQualifyBrackets );
            }
        }

        private void FillFirstRound()
        {
            var round = Rounds.Find(r => r.RoundId == 1);

            for (int count = 0; count < _initialBracketsCount; count++)
            {
                var randomBracket = GetRandomBracket(PreQualifyBrackets, round.Brackets);

                var bracket = new Bracket() { BracketId = round.Brackets.Count + 1 };
                // add new bracket to round
                round.Brackets.Add(bracket);
                // if we have bracket use bracket winner else use participants who didn't need qualification
                // red corner
                if (randomBracket != null)
                {
                    bracket.RedCornerBracket = randomBracket;
                    _assignedPrequilifiedBracketsId.Add(randomBracket.BracketId);
                }
                else
                {
                    bracket.RedCorner = GetRandomParticipant(TotalParticipants, round.Brackets, PreQualifyBrackets);
                }
                // blue corner
                randomBracket = GetRandomBracket(PreQualifyBrackets, round.Brackets);
                var test = bracket.WinnerName;
                if (randomBracket != null)
                {
                    bracket.BlueCornerBracket = randomBracket;
                    _assignedPrequilifiedBracketsId.Add(randomBracket.BracketId);

                }
                else
                {
                    bracket.BlueCorner = GetRandomParticipant(TotalParticipants, round.Brackets, PreQualifyBrackets);
                }
                test = bracket.WinnerName;
            }
        }

        private void AssignSubsequentRounds()
        {
            int iRound = 1;
            // reset count so it is not returns null
            _assignedPrequilifiedBracketsId.Clear();
            for (iRound = 1; iRound < _tournamentRoundsCount; iRound++)
            {
                // we need to itterate through all brackets in prior Round
                var prevRoundBrackets = Rounds[iRound - 1].Brackets;
                // current round
                var round = Rounds[iRound];
                // nubmer of brackets in this round
                for (int iBracket = 0; iBracket < prevRoundBrackets.Count / 2; iBracket++)
                {
                    var randomBracket = GetRandomBracket(prevRoundBrackets, round.Brackets);

                    var bracket = new Bracket() { BracketId = round.Brackets.Count + 1 };
                    // add new bracket to round
                    round.Brackets.Add(bracket);
                    // red cornet
                    bracket.RedCornerBracket = randomBracket;
                    // blue corner
                    randomBracket = GetRandomBracket(prevRoundBrackets, round.Brackets);
                    bracket.BlueCornerBracket = randomBracket;
                }
            }
        }
        private void AssignRunnerUp()
        {
            ThirdPlace.BlueCorner = Rounds[_tournamentRoundsCount - 1].Brackets[0].RunnerUp;
            ThirdPlace.RedCorner = Rounds[_tournamentRoundsCount - 1].Brackets[1].RunnerUp;
        }
        private Bracket GetRandomBracket(List<Bracket> sourse, List<Bracket> dest)
        {
            // if source and dest have same count then return null
            if (sourse.Count <= _assignedPrequilifiedBracketsId.Count) { return null; };

            Random rnd = new Random();
            var id = dest.SelectMany(x => new[] { x.RedCornerBracket?.BracketId, x.BlueCornerBracket?.BracketId }).ToList();
            var list = sourse.Where(x => !id.Any(y => y == x.BracketId)).ToList();
            return list[rnd.Next(list.Count)];
            //while (bracket == null)
            //{
            //    int id = rnd.Next(1, sourse.Count + 1);
            //    foreach (var b in dest)
            //    {
            //        // check if redbracket has id matching to random
            //        if (b.RedCornerBracket != null && b.RedCornerBracket.BracketId == id) { found = true; };
            //        // check if blue bracket id matches to random
            //        if (!found)
            //        {
            //            if (b.BlueCornerBracket != null && b.BlueCornerBracket.BracketId == id) { found = true; };
            //        }
            //    }
            //    if (!found) { bracket = sourse.Find(b => b.BracketId == id); }
            //    // reset
            //    found = false;
            //    id++;
            //}
            //return bracket;
        }
        private Participant GetRandomParticipant(List<Participant> participantsFrom, List<Bracket> dest, List<Bracket> destTWO)
        {
            Random rnd = new Random();
            var Id = dest.Union(destTWO).SelectMany(x => new[] { x.BlueCorner?.ID, x.RedCorner?.ID }).ToList();
            var part = participantsFrom.Where(x => !Id.Any(y => y == x.ID)).ToList();
            //need to be tested for inline return. additionally need to check performance
            //var test =
            //    participantsFrom
            //    .Where(x =>
            //        !dest.Union(destTWO).SelectMany(d => new[] { d.BlueCorner?.ID, d.RedCorner?.ID }).ToList()
            //        .Any(y => y == x.ID))
            //    .ToList()
            //    .Random();
            return part[rnd.Next(part.Count)];
        }
    }
}
