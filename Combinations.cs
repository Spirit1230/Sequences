using System;
using System.Collections.Generic;

namespace Iterations 
{
    static public class Combinations 
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

        static private int[][] FindAllCombinations(int[] allPosValues, int numChosen, bool allowRepeats = false) 
        {
            List<int[]> allCombs = new List<int[]>();

            int[] posComb = new int[numChosen];

            //assigns first combination intital combination
            for (int pos = 0; pos < posComb.Length; pos++) 
            {
                if (allowRepeats) 
                {
                    posComb[pos] = 0;
                }
                else 
                {
                    posComb[pos] = pos;
                }
            }

            allCombs.Add(CopyIntArr(posComb));

            int posToUpdate = posComb.Length - 1;

            while (posToUpdate >= 0) 
            {
                if (posComb[posToUpdate] + 1 < allPosValues.Length) 
                {
                    if (posToUpdate == posComb.Length - 1) 
                    {
                        posComb[posToUpdate]++;
                        allCombs.Add(CopyIntArr(posComb));
                    }
                    else 
                    {
                        if (allowRepeats) 
                        {
                            int val = posComb[posToUpdate] + 1;

                            for (int i = posToUpdate; i < posComb.Length; i++) 
                            {
                                posComb[i] = val;
                            }

                            posToUpdate = posComb.Length - 1;

                            allCombs.Add(CopyIntArr(posComb));
                        }
                        else 
                        {
                            int val = posComb[posToUpdate] + 1;

                            if (allPosValues.Length - val >= posComb.Length - posToUpdate) 
                            {
                                for (int i = posToUpdate; i < posComb.Length; i++) 
                                {
                                    posComb[i] = val + i - posToUpdate;
                                }

                                posToUpdate = posComb.Length - 1;

                                allCombs.Add(CopyIntArr(posComb));
                            }
                            else 
                            {
                                posToUpdate--;
                            }
                        }
                    }
                }
                else 
                {
                    posToUpdate--;
                }
            }

            return allCombs.ToArray();
        }

        static private int[] ConvertToIntArray(string[] stringArr) 
        {
            int[] intArr = new int[stringArr.Length];

            for (int i = 0; i < stringArr.Length; i++) 
            {
                intArr[i] = i;
            }

            return intArr;
        }

        static private string[] ConvertToStringArr(int[] intArray, string[] stringArr) 
        {
            string[] convArr = new string[intArray.Length];

            for (int i = 0; i < intArray.Length; i++) 
            {
                convArr[i] = stringArr[intArray[i]];
            }

            return convArr;
        }

        static private int CalcFactorial(int n) 
        {
            int result = 1;

            for (int i = 1; i <= n; i++) 
            {
                result *= i;
            }

            return result;
        }

        static private int[] CopyIntArr(int[] toCopy) 
        {
            int[] copiedArr = new int[toCopy.Length];

            for (int i = 0; i < toCopy.Length; i++) 
            {
                copiedArr[i] = toCopy[i];
            }

            return copiedArr;
        }
    }
}