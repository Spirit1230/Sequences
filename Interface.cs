using System;
using System.Collections.Generic;

namespace Sequences 
{
    static public partial class Combinations 
    {
        static public string[][] GetCombinations(string[] allVals, int numChosen) 
        {
            //Finds all the different combinations without any repeated values from an array of values

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
            //Finds all the different combinations with repeated values from an array of values

            int[][] allCombsInt = FindAllCombinations(ConvertToIntArray(allVals), numChosen, true);

            List<string[]> allCombs = new List<string[]>();

            foreach (int[] combInt in allCombsInt) 
            {
                allCombs.Add(ConvertToStringArr(combInt, allVals));
            }

            return allCombs.ToArray();
        }

        static public string[][] GetPermutations(string[] allVals, int numChosen) 
        {
            //Finds all the different permutations without repeated values from an array of values

            int[][] allPermsInt = FindAllPermutations(ConvertToIntArray(allVals), numChosen, false);

            List<string[]> allPerms = new List<string[]>();

            foreach (int[] permInt in allPermsInt) 
            {
                allPerms.Add(ConvertToStringArr(permInt, allVals));
            }

            return allPerms.ToArray();
        }

        static public string[][] GetPermutationsWithRepeats(string[] allVals, int numChosen) 
        {
            //Finds all the different permutations with repeated values from an array of values

            int[][] allPermsInt = FindAllPermutations(ConvertToIntArray(allVals), numChosen, true);

            List<string[]> allPerms = new List<string[]>();

            foreach (int[] permInt in allPermsInt) 
            {
                allPerms.Add(ConvertToStringArr(permInt, allVals));
            }

            return allPerms.ToArray();
        }

        static public int CalculateTotalCombinations(int numChosen, int totalOptions) 
        {
            //Calculates the total number of combinations without repeats
            //n! / (r!(n - r)!) where n = total options, r = numChosen and "!" stands for factorial

            int result;

            if (numChosen <= totalOptions) 
            {
                int calcTop = 1;

                (int calcBot, int largestBotFact) = (numChosen > totalOptions - numChosen) ? (totalOptions - numChosen, numChosen) : (numChosen, totalOptions - numChosen);

                for (int i = largestBotFact + 1; i <= totalOptions; i++) 
                {
                    calcTop *= i;                
                }

                result = calcTop / CalcFactorial(calcBot);
            }
            else 
            {
                result = 0;
            }
            

            return result;
        }

        static public int CalculateTotalCombinationsWithRepeats(int numChosen, int totalOptions) 
        {
            //Calculates the total number of combinations with repeats
            //(r + n - 1)! / (r!(n - 1)!) where n = totalOptions, r = numChosen and "!" stands for factorial

            int calcTop = 1;

            (int calcBot, int largestBotFact) = (numChosen > totalOptions - 1) ? (totalOptions - 1, numChosen) : (numChosen, totalOptions - 1);

            for (int i = largestBotFact + 1; i <= numChosen + totalOptions - 1; i++) 
            {
                calcTop *= i;                
            }

            return calcTop / CalcFactorial(calcBot);
        }

        static public int CalculateTotalPermutations(int numChosen, int totalOptions) 
        {
            //Calculates the total number of permutations without repeats
            //n! / (n - r)! where n = totalOptions, r = numChosen and "!" stands for factorial

            int result;

            if (numChosen <= totalOptions) 
            {
                result = 1;

                for (int i = totalOptions - numChosen + 1; i <= totalOptions; i++) 
                {
                    result *= i;
                }
            }
            else 
            {
                result = 0;
            }

            return result;
        }

        static public int CalculateTotalPermutationsWithRepeats(int numChosen, int totalOptions) 
        {
            //Calculates the total number of permutations with repeats
            //n ^ r where n = totalOptions, r = numChosen

            return (int)Math.Pow(totalOptions, numChosen);
        }
    }
}