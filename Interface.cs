using System;
using System.Collections.Generic;

namespace Iterations 
{
    static public partial class Combinations 
    {
        static public string[][] GetCombinations(string[] allVals, int numChosen) 
        {
            int[][] allCombsInt = FindAllCombinations(ConvertToIntArray(allVals), numChosen, false);

            List<string[]> allCombs = new List<string[]>();

            foreach (int[] combInt in allCombsInt) 
            {
                allCombs.Add(ConvertToStringArr(combInt, allVals));
            }

            return allCombs.ToArray();
        }

        static public string[][] GetCombinationsWithRepeats(string[] allVals, int numChosen) 
        {
            int[][] allCombsInt = FindAllCombinations(ConvertToIntArray(allVals), numChosen, true);

            List<string[]> allCombs = new List<string[]>();

            foreach (int[] combInt in allCombsInt) 
            {
                allCombs.Add(ConvertToStringArr(combInt, allVals));
            }

            return allCombs.ToArray();
        }

        static public int CalculateTotalCombinations(int numChosen, int totalOptions) 
        {
            int calcTop = 1;

            (int calcBot, int largestBotFact) = (numChosen > totalOptions - numChosen) ? (totalOptions - numChosen, numChosen) : (numChosen, totalOptions - numChosen);

            for (int i = 1; i <= totalOptions; i++) 
            {
                if (i > largestBotFact) 
                {
                    calcTop *= i;
                }
            }

            return calcTop / CalcFactorial(calcBot);
        }

        static public int CalculateTotalCombinationsWithRepeats(int numChosen, int totalOptions) 
        {
            int calcTop = 1;

            (int calcBot, int largestBotFact) = (numChosen > totalOptions - 1) ? (totalOptions - 1, numChosen) : (numChosen, totalOptions - 1);

            for (int i = 1; i <= numChosen + totalOptions - 1; i++) 
            {
                if (i > largestBotFact) 
                {
                    calcTop *= i;
                }
            }

            return calcTop / CalcFactorial(calcBot);
        }

        static public int CalculateTotalPermuations(int numChosen, int totalOptions) 
        {
            int result = 1;

            for (int i = totalOptions - numChosen + 1; i <= totalOptions; i++) 
            {
                result *= i;
            }

            return result;
        }

        static public int CalculateTotalPermuationsWithRepitions(int numChosen, int totalOptions) 
        {
            return (int)Math.Pow(totalOptions, numChosen);
        }
    }
}