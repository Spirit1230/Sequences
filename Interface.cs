using System;
using System.Collections.Generic;

namespace Sequences 
{
    static public partial class Combinations 
    {
        static public T[][] GetCombinations<T>(T[] allVals, int numChosen) 
        {
            //Finds all the different combinations without any repeated values from an array of values

            int[][] allCombsInt = FindAllCombinations(ConvertToIntArray(allVals), numChosen, false);

            List<T[]> allCombs = new List<T[]>();

            foreach (int[] combInt in allCombsInt) 
            {
                allCombs.Add(ConvertToTArr(combInt, allVals));
            }

            return allCombs.ToArray();
        }

        static public T[][] GetCombinationsWithRepeats<T>(T[] allVals, int numChosen) 
        {
            //Finds all the different combinations with repeated values from an array of values

            int[][] allCombsInt = FindAllCombinations(ConvertToIntArray(allVals), numChosen, true);

            List<T[]> allCombs = new List<T[]>();

            foreach (int[] combInt in allCombsInt) 
            {
                allCombs.Add(ConvertToTArr(combInt, allVals));
            }

            return allCombs.ToArray();
        }

        static public T[][] GetPermutations<T>(T[] allVals, int numChosen) 
        {
            //Finds all the different permutations without repeated values from an array of values

            int[][] allPermsInt = FindAllPermutations(ConvertToIntArray(allVals), numChosen, false);

            List<T[]> allPerms = new List<T[]>();

            foreach (int[] permInt in allPermsInt) 
            {
                allPerms.Add(ConvertToTArr(permInt, allVals));
            }

            return allPerms.ToArray();
        }

        static public T[][] GetPermutationsWithRepeats<T>(T[] allVals, int numChosen) 
        {
            //Finds all the different permutations with repeated values from an array of values

            int[][] allPermsInt = FindAllPermutations(ConvertToIntArray(allVals), numChosen, true);

            List<T[]> allPerms = new List<T[]>();

            foreach (int[] permInt in allPermsInt) 
            {
                allPerms.Add(ConvertToTArr(permInt, allVals));
            }

            return allPerms.ToArray();
        }

        static public ulong CalculateTotalCombinations(int numChosen, int totalOptions) 
        {
            //Calculates the total number of combinations without repeats
            //n! / (r!(n - r)!) where n = total options, r = numChosen and "!" stands for factorial

            ulong result;

            if (0 < numChosen && numChosen <= totalOptions) 
            {
                ulong calcTop = 1;

                (int calcBot, int largestBotFact) = (numChosen > totalOptions - numChosen) ? (totalOptions - numChosen, numChosen) : (numChosen, totalOptions - numChosen);

                for (int i = largestBotFact + 1; i <= totalOptions; i++) 
                {
                    calcTop *= (ulong)i;                
                }

                result = (ulong)calcTop / CalcFactorial(calcBot);
            }
            else 
            {
                result = 0;
            }
            

            return result;
        }

        static public ulong CalculateTotalCombinationsWithRepeats(int numChosen, int totalOptions) 
        {
            //Calculates the total number of combinations with repeats
            //(r + n - 1)! / (r!(n - 1)!) where n = totalOptions, r = numChosen and "!" stands for factorial

            ulong result;

            if (numChosen > 0) 
            {
                ulong calcTop = 1;

                (int calcBot, int largestBotFact) = (numChosen > totalOptions - 1) ? (totalOptions - 1, numChosen) : (numChosen, totalOptions - 1);

                for (int i = largestBotFact + 1; i <= numChosen + totalOptions - 1; i++) 
                {
                    calcTop *= (ulong)i;                
                }

                result = (ulong)calcTop / CalcFactorial(calcBot);
            }
            else 
            {
                result = 0;
            }

            return result;
        }

        static public ulong CalculateTotalPermutations(int numChosen, int totalOptions) 
        {
            //Calculates the total number of permutations without repeats
            //n! / (n - r)! where n = totalOptions, r = numChosen and "!" stands for factorial

            ulong result;

            if (0 < numChosen && numChosen <= totalOptions) 
            {
                result = 1;

                for (int i = totalOptions - numChosen + 1; i <= totalOptions; i++) 
                {
                    result *= (ulong)i;
                }
            }
            else 
            {
                result = 0;
            }

            return result;
        }

        static public ulong CalculateTotalPermutationsWithRepeats(int numChosen, int totalOptions) 
        {
            //Calculates the total number of permutations with repeats
            //n ^ r where n = totalOptions, r = numChosen

            ulong result;

            if (0 < numChosen) 
            {
                result = (ulong)Math.Pow(totalOptions, numChosen);
            }
            else 
            {
                result = 0;
            }

            return result;
        }
    }
}