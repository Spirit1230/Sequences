using System;
using System.Collections.Generic;

namespace Iterations 
{
    static public class Combinations 
    {
        static public List<string[]> FindAllCombinations(string[] allPosValues, int numChosen) 
        {
            List<string[]> posConds = new List<string[]>();
            
            int startPos = 0;
            int posIndex = startPos;

            int numFound = 0;
            int totalComb = CalculateTotalCombinations(numChosen, allPosValues.Length);

            List<string> posCond = new List<string>();

            while (numFound < totalComb) 
            {
                string nextValue = allPosValues[posIndex++];

                if (posCond.Count < numChosen && !posCond.Contains(nextValue)) 
                {
                    posCond.Add(nextValue);
                }
                else 
                {
                    string valToRemove;
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

            return posConds;
        }

        static public List<string[]> FindAllCombinationsWithRepeats(string[] allPosValues) 
        {
            return new List<string[]>();
        }

        static public int CalculateTotalCombinations(int numChosen, int totalOptions) 
        {
            int numComb = CalcFactorial(totalOptions) / (CalcFactorial(numChosen) * CalcFactorial(totalOptions - numChosen));

            return numComb;
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