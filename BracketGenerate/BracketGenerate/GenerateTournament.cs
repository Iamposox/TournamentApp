using BracketGenerate.Interface;
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
        //The Collection hold type of interface
        public List<IParticipant> TotalParticipant;// = new List<IParticipant>();
        private int _initialPairCount;
        private int _qualificationPairCount;
        private int _roundsCount;
        public List<Match> PreQualifyBrackets = new List<Match>();
        private List<int> _assignedPrequilifiedBracketsId = new List<int>();
        //Also no need in teams, since they all are under single interface
        //public List<Team> teams = new List<Team>();
        // No need in unions
        //public List<TeamUnion> teamUni= new List<TeamUnion>();
        Random rnd = new Random();

        public List<FirstRound> Rounds = new List<FirstRound>();
        //Yep we are also creating with Interface
        public GenerateTournament(List<IParticipant> totalParticipant) 
        {
            TotalParticipant = new List<IParticipant>(totalParticipant);
        }
        //public GenerateTournament(List<Team> totalTeam) 
        //{
        //    teams = totalTeam;
        //}
        // No need in unions
        //public GenerateTournament(List<TeamUnion> TeamUnion)
        //{
        //    teamUni = TeamUnion;
        //}
        public Tournament LaunchGenerationForParticipant() 
        {
            CounterOfRounds(TotalParticipant);
            if (_qualificationPairCount == 0) 
            {
                FillFirstRound(TotalParticipant);
                var e = new Tournament();
                e.FirstRounds = Rounds;
                return e;
            }
            else 
            {
                generateQualifiedRounds(TotalParticipant);
                FillFirstRound(TotalParticipant);
                var e = new Tournament();
                e.FirstRounds = Rounds;
                return e;
            }
        }
        //Sorry we dont need this crap either
        //public Tournament LaunchGenerationForTeams() 
        //{
        //    CounterOfRounds(teams);
        //    if (_qualificationPairCount == 0) 
        //    {
        //        FillFirstRound(teams);
        //        var e = new Tournament();
        //        e.FirstRounds = Rounds;
        //        return e;
        //    }
        //    else 
        //    {
        //        generateQualifiedRounds(teams);
        //        FillFirstRound(teams);
        //        var e = new Tournament();
        //        e.FirstRounds = Rounds;
        //        return e;
        //    }
        //}
        //public Tournament LaunchGenerationForUnion() 
        //{
        //    CounterOfRounds(teamUni);
        //    if(_qualificationPairCount == 0) 
        //    {
        //        FillFirstRound(teamUni);
        //        var e = new Tournament();
        //        e.FirstRounds = Rounds;
        //        return e;
        //    }
        //    else 
        //    {
        //        generateQualifiedRounds(teamUni);
        //        FillFirstRound(teamUni);
        //        var e = new Tournament();
        //        e.FirstRounds = Rounds;
        //        return e;
        //    }
        //}
        public void CounterOfRounds<T>(List<T> sender) 
        {
            // step 1. calculate number of brackets, prequalifier pairs and total rounds in this tournament
            //            // get total number of brackets/pairs in tournament
            _initialPairCount = TournamentCalcHelper.CalcInitialPairCount(sender.Count);
            //            // get total number of pre-qualify pairs
            _qualificationPairCount = TournamentCalcHelper.CalcPreQualifyPairCount(sender.Count);
            //            // get total number of rounds in this tournament
            _roundsCount = TournamentCalcHelper.CalcRounds(_initialPairCount);

        }
        public void generateQualifiedRounds(List<IParticipant> TotalParticipant) 
        {
            for (int i = 0; i < _qualificationPairCount; i++)
            {
                var bracket = new Match() { ID = PreQualifyBrackets.Count + 1 };
                // get "luckcy" :) prequlifyer for red corner
                bracket.RedCorner = GetRandomParticipantTest(TotalParticipant, PreQualifyBrackets, PreQualifyBrackets);
                bracket.BlueCorner = GetRandomParticipantTest(TotalParticipant, PreQualifyBrackets, PreQualifyBrackets);
                PreQualifyBrackets.Add(bracket);
            }
        }
        //public void generateQualifiedRounds(List<Team> teams)
        //{
        //    for (int i = 0; i < _qualificationPairCount; i++)
        //    {
        //        var bracket = new Match() { ID = PreQualifyBrackets.Count + 1 };
        //        // get "luckcy" :) prequlifyer for red corner
        //        bracket.RedCornerTeam = GetRandomTeams(teams, PreQualifyBrackets, PreQualifyBrackets);
        //        bracket.BlueCornerTeam = GetRandomTeams(teams, PreQualifyBrackets, PreQualifyBrackets);
        //        PreQualifyBrackets.Add(bracket);
        //    }
        //}
        
        //public void generateQualifiedRounds(List<TeamUnion> teams)
        //{
        //    for (int i = 0; i < _qualificationPairCount; i++)
        //    {
        //        var bracket = new Match() { ID = PreQualifyBrackets.Count + 1 };
        //        // get "luckcy" :) prequlifyer for red corner
        //        bracket.UnionRed = GetRandomTeamUnion(teams, PreQualifyBrackets, PreQualifyBrackets);
        //        bracket.UnionBlue = GetRandomTeamUnion(teams, PreQualifyBrackets, PreQualifyBrackets);
        //        PreQualifyBrackets.Add(bracket);
        //    }
        //}

        private void FillFirstRound(List<IParticipant> TotalParticipant)
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

        //Also doesnt provide benefit
        //private void FillFirstRound(List<Team> teams)
        //{
        //    var round = Rounds.Find(r => r.ID == 1);

        //    for (int count = 0; count < _initialPairCount; count++)
        //    {
        //        var randomBracket = GetRandomBracket(PreQualifyBrackets, Rounds);

        //        var bracket = new FirstRound() { ID = Rounds.Count + 1 };
        //        // add new bracket to round
        //        Rounds.Add(bracket);
        //        // if we have bracket use bracket winner else use participants who didn't need qualification
        //        // red corner
        //        if (randomBracket != null)
        //        {
        //            bracket.RedCornerPair = randomBracket;
        //            _assignedPrequilifiedBracketsId.Add(randomBracket.ID);
        //        }
        //        else
        //        {
        //            bracket.RedCornerTeam = GetRandomTeams(teams, PreQualifyBrackets, PreQualifyBrackets);
        //        }
        //        // blue corner
        //        randomBracket = GetRandomBracket(PreQualifyBrackets, Rounds);
        //        if (randomBracket != null)
        //        {
        //            bracket.BlueCornerPair = randomBracket;
        //            _assignedPrequilifiedBracketsId.Add(randomBracket.ID);

        //        }
        //        else
        //        {
        //            bracket.BlueCornerTeam = GetRandomTeams(teams, PreQualifyBrackets, PreQualifyBrackets);
        //        }
        //    }
        //}

        //pointless crap
        //private void FillFirstRound(List<TeamUnion> teams)
        //{
        //    var round = Rounds.Find(r => r.ID == 1);

        //    for (int count = 0; count < _initialPairCount; count++)
        //    {
        //        var randomBracket = GetRandomBracket(PreQualifyBrackets, Rounds);

        //        var bracket = new FirstRound() { ID = Rounds.Count + 1 };
        //        // add new bracket to round
        //        Rounds.Add(bracket);
        //        // if we have bracket use bracket winner else use participants who didn't need qualification
        //        // red corner
        //        if (randomBracket != null)
        //        {
        //            bracket.RedCornerPair = randomBracket;
        //            _assignedPrequilifiedBracketsId.Add(randomBracket.ID);
        //        }
        //        else
        //        {
        //            //bracket.UnionRed = GetRandomTeamUnion(teams, PreQualifyBrackets, PreQualifyBrackets);
        //        }
        //        // blue corner
        //        randomBracket = GetRandomBracket(PreQualifyBrackets, Rounds);
        //        if (randomBracket != null)
        //        {
        //            bracket.BlueCornerPair = randomBracket;
        //            _assignedPrequilifiedBracketsId.Add(randomBracket.ID);

        //        }
        //        else
        //        {
        //            //bracket.UnionBlue = GetRandomTeamUnion(teams, PreQualifyBrackets, PreQualifyBrackets);
        //        }
        //    }
        //}
      
        
        private IParticipant GetRandomParticipantTest
            (
                List<IParticipant> participantsFrom,
                List<Match> dest,
                List<Match> destTWO
            )
            =>
                participantsFrom
                .Where(x =>
                    !dest.Union(destTWO).SelectMany(d => new[] { d.BlueCorner?.ID, d.RedCorner?.ID }).ToList()
                    .Any(y => y == x.ID))
                .ToList()
                .Random();


        private Team GetRandomTeams(List<Team> teams, List<Match> dest,
                List<Match> destTWO) => teams
            .Where(x =>
                !dest.Union(destTWO).SelectMany(d => new[] { d.BlueCorner?.ID, d.RedCorner?.ID }).ToList()
                .Any(y => y == x.ID))
            .ToList()
            .Random();
//totally dont need that
        //private TeamUnion GetRandomTeamUnion(List<TeamUnion> teamUni, List<Match> dest, List<Match> destTWO) => teamUni
        //    .Where(x =>
        //        !dest.Union(destTWO).SelectMany(d => new[] { d.BlueCorner?.ID, d.RedCorner?.ID }).ToList()
        //        .Any(y => y == x.ID))
        //    .ToList()
        //    .Random();
        public Match GetRandomBracketTest(List<Match> source, List<FirstRound> dest, List<int> _countId) => (source.Count <= _countId.Count) ? null : source
            .Where(x =>
                !dest.SelectMany(d => new[] { d.RedCornerPair?.ID, d.BlueCornerPair.ID})
                .Any(y => y == x.ID))
            .ToList().Random();
        private Match GetRandomBracket(List<Match> sourse, List<FirstRound> dest)
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
