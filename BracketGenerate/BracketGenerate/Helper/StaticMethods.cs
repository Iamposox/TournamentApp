using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracketGenerator.Helper
{
    //Please Rename this class. StaticMethods is not saying much about what this class supposed to do
    public static class StaticMethods
    {
        public static bool isPowerOfTwo(int x)
        {
            return ((x != 0) && ((x & (~x + 1)) == x));
        }

        public static int CalcInitialPairCount(int count)
        {
            while (!isPowerOfTwo(count))
            {
                count--;
            }
            return count / 2;
        }

        public static int CalcPreQualifyPairCount(int totalCount)
        {
            int count = totalCount;
            while (!isPowerOfTwo(count))
            {
                count--;
            }
            return totalCount - count;
        }

        public static int CalcRounds(int totalBrackets)
        {
            int count = 0;
            while (totalBrackets > 1)
            {
                totalBrackets = totalBrackets / 2;
                count++;
            }
            return count;
        }

    }
}
