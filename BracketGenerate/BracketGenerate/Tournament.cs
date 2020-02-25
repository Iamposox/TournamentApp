using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        //        //This is unnessecery if you return generated model. It will be easier to use, test and understand
        //        [ComVisible(true)]
        public List<Participant> TotalParticipants;
        //        [ComVisible(true)]
        //        public List<Bracket> Brackets = new List<Bracket>();
        //        [ComVisible(true)]
        //        public List<Bracket> PreQualifyBrackets = new List<Bracket>();
        //        [ComVisible(true)]
        //        public List<Round> Rounds = new List<Round>();
        //        [ComVisible(true)]
        //        public LastRoundBracket FinalBracket;
        //        [ComVisible(true)]
        //        public LastRoundBracket ThirdPlace;

        //        private int _initialBracketsCount;
        //        private int _preQualifiedBracketsCount;
        //        private int _tournamentRoundsCount;
        //        private List<int> _assignedPrequilifiedBracketsId = new List<int>();

        //        //Use single seed of Random in entier class. Initializing new Random each time you need might create seeding issues
        //        private Random rnd = new Random();


        //        [ComVisible(true)]
        //        //I dont like this personaly. It should return values.
        //        //Return values are easier to test and alot easier to understand
        //        //currently i am not quite sure what exatcly this crap does and how to use this dll
        //        public void GenerateTournamemtBrackets()
        //        {
        //            // step 1. calculate number of brackets, prequalifier pairs and total rounds in this tournament
        //            // get total number of brackets/pairs in tournament
        //            _initialBracketsCount = TournamentCalcHelper.CalcInitialPairCount(TotalParticipants.Count);
        //            // get total number of pre-qualify pairs
        //            _preQualifiedBracketsCount = TournamentCalcHelper.CalcPreQualifyPairCount(TotalParticipants.Count);
        //            // get total number of rounds in this tournament
        //            _tournamentRoundsCount = TournamentCalcHelper.CalcRounds(_initialBracketsCount);

        //            // step 2. fill rounds
        //            FillRounds();
        //            FinalBracket = new LastRoundBracket(Rounds[_tournamentRoundsCount - 1], true);
        //            ThirdPlace = new LastRoundBracket(Rounds[_tournamentRoundsCount - 1], false);
        //        }

        //        private void FillRounds()
        //        {
        //            // first need to fill pre-qualifiers if such exist
        //            FillPreQualifiers();
        //            // create all rounds
        //            for (int iRound = 1; iRound <= _tournamentRoundsCount; iRound++)
        //            {
        //                //Rounds.Add(new Round() { RoundId = iRound });
        //            }
        //            // process first round
        //            FillFirstRound();
        //            AssignSubsequentRounds();
        //        }

        //        private void FillPreQualifiers()
        //        {
        //            for (int i = 0; i < _preQualifiedBracketsCount; i++)
        //            {
        //                var bracket = new Bracket() { BracketId = PreQualifyBrackets.Count + 1 };
        //                // get "luckcy" :) prequlifyer for red corner
        //                bracket.RedCorner = GetRandomParticipant(TotalParticipants, PreQualifyBrackets, PreQualifyBrackets);
        //                PreQualifyBrackets.Add(bracket);
        //                bracket.BlueCorner = GetRandomParticipant(TotalParticipants, PreQualifyBrackets, PreQualifyBrackets);
        //            }
        //        }

        //        private void FillFirstRound()
        //        {
        //            var round = Rounds.Find(r => r.RoundId == 1);

        //            for (int count = 0; count < _initialBracketsCount; count++)
        //            {
        //                var randomBracket = GetRandomBracket(PreQualifyBrackets, round.Brackets);

        //                var bracket = new Bracket() { BracketId = round.Brackets.Count + 1 };
        //                // add new bracket to round
        //                round.Brackets.Add(bracket);
        //                // if we have bracket use bracket winner else use participants who didn't need qualification
        //                // red corner
        //                if (randomBracket != null)
        //                {
        //                    bracket.RedCornerBracket = randomBracket;
        //                    _assignedPrequilifiedBracketsId.Add(randomBracket.BracketId);
        //                }
        //                else
        //                {
        //                    bracket.RedCorner = GetRandomParticipant(TotalParticipants, round.Brackets, PreQualifyBrackets);
        //                }
        //                // blue corner
        //                randomBracket = GetRandomBracket(PreQualifyBrackets, round.Brackets);
        //                var test = bracket.WinnerName;
        //                if (randomBracket != null)
        //                {
        //                    bracket.BlueCornerBracket = randomBracket;
        //                    _assignedPrequilifiedBracketsId.Add(randomBracket.BracketId);

        //                }
        //                else
        //                {
        //                    bracket.BlueCorner = GetRandomParticipant(TotalParticipants, round.Brackets, PreQualifyBrackets);
        //                }
        //                test = bracket.WinnerName;
        //            }
        //        }

        //        private void AssignSubsequentRounds()
        //        {
        //            int iRound = 1;
        //            // reset count so it is not returns null
        //            _assignedPrequilifiedBracketsId.Clear();
        //            for (iRound = 1; iRound < _tournamentRoundsCount; iRound++)
        //            {
        //                // we need to itterate through all brackets in prior Round
        //                var prevRoundBrackets = Rounds[iRound - 1].Brackets;
        //                // current round
        //                var round = Rounds[iRound];
        //                // nubmer of brackets in this round
        //                for (int iBracket = 0; iBracket < prevRoundBrackets.Count / 2; iBracket++)
        //                {
        //                    var randomBracket = GetRandomBracket(prevRoundBrackets, round.Brackets);

        //                    var bracket = new Bracket() { BracketId = round.Brackets.Count + 1 };
        //                    // add new bracket to round
        //                    round.Brackets.Add(bracket);
        //                    // red cornet
        //                    bracket.RedCornerBracket = randomBracket;
        //                    // blue corner
        //                    randomBracket = GetRandomBracket(prevRoundBrackets, round.Brackets);
        //                    bracket.BlueCornerBracket = randomBracket;
        //                }
        //            }
        //        }

        //        //You aint using it...why is it still here ?
        //        private void AssignRunnerUp()
        //        {
        //            ThirdPlace.BlueCorner = Rounds[_tournamentRoundsCount - 1].Brackets[0].RunnerUp;
        //            ThirdPlace.RedCorner = Rounds[_tournamentRoundsCount - 1].Brackets[1].RunnerUp;
        //        }

        //        private Bracket GetRandomBracket(List<Bracket> sourse, List<Bracket> dest)
        //        {
        //            // if source and dest have same count then return null
        //            if (sourse.Count <= _assignedPrequilifiedBracketsId.Count)
        //                return null;

        //            var id = dest.SelectMany(x => new[] { x.RedCornerBracket?.BracketId, x.BlueCornerBracket?.BracketId }).ToList();
        //            var list = sourse.Where(x => !id.Any(y => y == x.BracketId)).ToList();
        //            return list[rnd.Next(list.Count)];
        //            //while (bracket == null)
        //            //{
        //            //    int id = rnd.Next(1, sourse.Count + 1);
        //            //    foreach (var b in dest)
        //            //    {
        //            //        // check if redbracket has id matching to random
        //            //        if (b.RedCornerBracket != null && b.RedCornerBracket.BracketId == id) { found = true; };
        //            //        // check if blue bracket id matches to random
        //            //        if (!found)
        //            //        {
        //            //            if (b.BlueCornerBracket != null && b.BlueCornerBracket.BracketId == id) { found = true; };
        //            //        }
        //            //    }
        //            //    if (!found) { bracket = sourse.Find(b => b.BracketId == id); }
        //            //    // reset
        //            //    found = false;
        //            //    id++;
        //            //}
        //            //return bracket;
        //        }


        //        TimeSpan TimeSpanOriginalTimer = new TimeSpan();
        //        TimeSpan TimeSpanInlineTimer = new TimeSpan();
        //        Stopwatch stopwatch = new Stopwatch();
        //        Stopwatch stopwatch2 = new Stopwatch();

        //        private Participant GetRandomParticipant(List<Participant> participantsFrom, List<Bracket> dest, List<Bracket> destTWO)
        //        {
        //            stopwatch.Start();
        //            var Id = dest.Union(destTWO).SelectMany(x => new[] { x.BlueCorner?.ID, x.RedCorner?.ID }).ToList();
        //            var result = participantsFrom.Where(x => !Id.Any(y => y == x.ID)).Random();

        //            stopwatch.Stop();
        //            TimeSpanOriginalTimer= TimeSpanOriginalTimer.Add(stopwatch.Elapsed);

        //            stopwatch2.Start();
        //            GetRandomParticipantTest(participantsFrom, dest, destTWO);
        //            stopwatch2.Stop();
        //            TimeSpanInlineTimer = TimeSpanInlineTimer.Add(stopwatch2.Elapsed);

        //            return result;
        //        }

        //        private Participant GetRandomParticipantTest
        //            (
        //                List<Participant> participantsFrom, 
        //                List<Bracket> dest, 
        //                List<Bracket> destTWO
        //            )
        //            =>
        //                participantsFrom
        //                .Where(x =>
        //                    !dest.Union(destTWO).SelectMany(d => new[] { d.BlueCorner?.ID, d.RedCorner?.ID }).ToList()
        //                    .Any(y => y == x.ID))
        //                .ToList()
        //                .Random();

    }
}
