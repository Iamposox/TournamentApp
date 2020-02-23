using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBracketGenerator.Helper;
using TournamentBracketGenerator.Model;
using BracketGenerate;

namespace BracketGenerate
{
    public class RoundOperation
    {
        public RoundOperation(){}
        public List<Round> Rounds = new List<Round>();
        public List<Bracket> PreQualifyBrackets = new List<Bracket>();
        private int _initialBracketsCount;
        private int _preQualifiedBracketsCount;
        private int _tournamentRoundsCount;
        public List<int> _assignedPrequilifiedBracketsId = new List<int>();
        private ParticipantOperator participant = new ParticipantOperator();
        private BracketOperation brackets = new BracketOperation();
        public LastRoundBracket FinalBracket;
        public LastRoundBracket ThirdPlace;

        public List<Bracket> Brackets = new List<Bracket>();
        public void TournamentCalc(List<Participant> TotalParticipants) 
        {
            // step 1. calculate number of brackets, prequalifier pairs and total rounds in this tournament
            // get total number of brackets/pairs in tournament
            _initialBracketsCount = TournamentCalcHelper.CalcInitialPairCount(TotalParticipants.Count);
            // get total number of pre-qualify pairs
            _preQualifiedBracketsCount = TournamentCalcHelper.CalcPreQualifyPairCount(TotalParticipants.Count);
            // get total number of rounds in this tournament
            _tournamentRoundsCount = TournamentCalcHelper.CalcRounds(_initialBracketsCount);
        }
        public void FillRounds(List<Participant> TotalParticipants)
        {
            // first need to fill pre-qualifiers if such exist
            FillPreQualifiers(TotalParticipants);
            // create all rounds
            for (int iRound = 1; iRound <= _tournamentRoundsCount; iRound++)
            {
                Rounds.Add(new Round() { RoundId = iRound });
            }
            // process first round
            FillFirstRound(TotalParticipants);
            AssignSubsequentRounds();
            AssignRunnerUp();
        }

        private void FillPreQualifiers(List<Participant> TotalParticipants)
        {
            for (int i = 0; i < _preQualifiedBracketsCount; i++)
            {
                var bracket = new Bracket() { BracketId = PreQualifyBrackets.Count + 1 };
                // get "luckcy" :) prequlifyer for red corner
                bracket.RedCorner = participant.GetRandomParticipantTest(TotalParticipants, PreQualifyBrackets, PreQualifyBrackets);
                PreQualifyBrackets.Add(bracket);
                bracket.BlueCorner = participant.GetRandomParticipantTest(TotalParticipants, PreQualifyBrackets, PreQualifyBrackets);
            }
        }

        private void FillFirstRound(List<Participant> TotalParticipants)
        {
            var round = Rounds.Find(r => r.RoundId == 1);

            for (int count = 0; count < _initialBracketsCount; count++)
            {
                var randomBracket = brackets.GetRandomBracket(PreQualifyBrackets, round.Brackets, _assignedPrequilifiedBracketsId);

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
                    bracket.RedCorner = participant.GetRandomParticipantTest(TotalParticipants, round.Brackets, PreQualifyBrackets);
                }
                // blue corner
                randomBracket = brackets.GetRandomBracket(PreQualifyBrackets, round.Brackets, _assignedPrequilifiedBracketsId);
                var test = bracket.WinnerName;
                if (randomBracket != null)
                {
                    bracket.BlueCornerBracket = randomBracket;
                    _assignedPrequilifiedBracketsId.Add(randomBracket.BracketId);

                }
                else
                {
                    bracket.BlueCorner = participant.GetRandomParticipantTest(TotalParticipants, round.Brackets, PreQualifyBrackets);
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
                    var randomBracket = brackets.GetRandomBracketTest(prevRoundBrackets, round.Brackets, _assignedPrequilifiedBracketsId);

                    var bracket = new Bracket() { BracketId = round.Brackets.Count + 1 };
                    // add new bracket to round
                    round.Brackets.Add(bracket);
                    // red cornet
                    bracket.RedCornerBracket = randomBracket;
                    // blue corner
                    randomBracket = brackets.GetRandomBracketTest(prevRoundBrackets, round.Brackets, _assignedPrequilifiedBracketsId);
                    bracket.BlueCornerBracket = randomBracket;
                }
            }
        }

        //You aint using it...why is it still here ?
        private void AssignRunnerUp()
        {
            FinalBracket = new LastRoundBracket(Rounds[_tournamentRoundsCount - 1], true);
            ThirdPlace = new LastRoundBracket(Rounds[_tournamentRoundsCount - 1], false);
        }
    }
}
