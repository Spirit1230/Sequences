using System;
using System.Collections.Generic;

namespace Iterations 
{
    static public class Combinations 
    {
        static public string[][] GetCombinations(string[] allVals, int numChosen) 
        {
            int[][] allCombsInt = FindAllCombinations(ConvertToIntArray(allVals), numChosen);

            List<string[]> allCombs = new List<string[]>();

            foreach (int[] combInt in allCombsInt) 
            {
                allCombs.Add(ConvertToStringArr(combInt, allVals));
            }

            return allCombs.ToArray();
        }

        static public string[][] GetCombinationsWithRepeats(string[] allVals, int numChosen) 
        {
            return new string[0][];
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

        static private int[][] FindAllCombinations(int[] allPosValues, int numChosen) 
        {
            List<int[]> posConds = new List<int[]>();
            
            int startPos = 0;
            int posIndex = startPos;

            int numFound = 0;
            int totalComb = CalculateTotalCombinations(numChosen, allPosValues.Length);

            List<int> posCond = new List<int>();

            while (numFound < totalComb) 
            {
                int nextValue = allPosValues[posIndex++];

                if (posCond.Count < numChosen && !posCond.Contains(nextValue)) 
                {
                    posCond.Add(nextValue);
                }
                else 
                {
                    int valToRemove;
                    int posInAllValues;

                    do 
                    {
                        valToRemove = posCond[posCond.Count - 1];

                        posInAllValues = 0;

                        for (int i = 0; i < allPosValues.Length; i++) 
                        {
                            if (valToRemove == allPosValues[i]) 
                            {
                                posInAllValues = i;
                                break;
                            }
                        }

                        startPos = posInAllValues + 1;
                        posCond.Remove(valToRemove);

                    } while (allPosValues.Length - startPos < numChosen - posCond.Count);

                    posIndex = startPos;
                }

                if (posCond.Count == numChosen)
                {
                    posConds.Add(posCond.ToArray());
                    posCond.RemoveAt(posCond.Count - 1);
                    numFound++;
                }

                if (posIndex >= allPosValues.Length) 
                {
                    posIndex = startPos;
                }
            }

            return posConds.ToArray();
        }

        // static public List<string[]> FindAllCombinationsWithRepeats(string[] allPosValues, int numCond) 
        // {
        //     string[] allValsRep = new string[allPosValues.Length * numCond];

        //     int index = 0;

        //     foreach (string val in allPosValues) 
        //     {
        //         for (int rep = 0; rep < numCond; rep++) 
        //         {
        //             allValsRep[index++] = val;
        //         }
        //     }

        //     return FindAllCombinations(allValsRep, numCond);
        // }

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

        static private int CalcFactorial(int n) 
        {
            int result = 1;

            for (int i = 1; i <= n; i++) 
            {
                result *= i;
            }

            return result;
        }
    }
}