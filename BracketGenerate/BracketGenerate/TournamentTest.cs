using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TournamentBracketGenerator.Helper;
using TournamentBracketGenerator.Model;
using BracketGenerate;

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

        //This is unnessecery if you return generated model. It will be easier to use, test and understand
        public List<Participant> TotalParticipants;
        //Use single seed of Random in entier class. Initializing new Random each time you need might create seeding issues
        private Random rnd = new Random();


        [ComVisible(true)]
        //I dont like this personaly. It should return values.
        //Return values are easier to test and alot easier to understand
        //currently i am not quite sure what exatcly this crap does and how to use this dll
        public void GenerateTournamemtBrackets()
        {

            RoundOperation FillRound = new RoundOperation();
            FillRound.TournamentCalc(TotalParticipants);
            FillRound.FillRounds(TotalParticipants);
        }

        
    }
}
