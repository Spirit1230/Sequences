using System;
using System.Collections.Generic;

namespace Iterations 
{
    public class Combinations 
    {
	public void Test() 
        {
            string[] testVals = new string[] {"APPLES", "PEARS", "ORANGES", "BANNANAS", "GRAPES", "AUBERGINE"};

            foreach (string[] cond in FindAllCombinations(testVals)) 
            {
                Console.WriteLine(string.Join(" OR ", cond));
            }
        }

        public List<string[]> FindAllCombinations(string[] allPosValues) 
        {
            List<string[]> posConds = new List<string[]>();

            int maxNumConds = allPosValues.Length - 1;
            int currentMaxConds = 1;
            
            int startPos = 0;
            int posIndex = startPos;

            int numFound = 0;
            int totalComb = CalculateTotalCombinations(currentMaxConds, allPosValues.Length);

            List<string> posCond = new List<string>();

            while (currentMaxConds <= maxNumConds) 
            {
                string nextValue = allPosValues[posIndex++];

                if (posCond.Count < currentMaxConds && !posCond.Contains(nextValue)) 
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

                    } while (allPosValues.Length - startPos < currentMaxConds - posCond.Count);

                    posIndex = startPos;
                }

                if (posCond.Count == currentMaxConds)
                {
                    posConds.Add(posCond.ToArray());
                    posCond.RemoveAt(posCond.Count - 1);
                    numFound++;
                }

                if (posIndex >= allPosValues.Length) 
                {
                    posIndex = startPos;
                }

                if (numFound == totalComb) 
                {
                    numFound = 0;
                    totalComb = CalculateTotalCombinations(++currentMaxConds, allPosValues.Length);
                    startPos = 0;
                    posIndex = startPos;
                    posCond.Clear();
                }
            }

            return posConds;
        }

        public int CalculateTotalCombinations(int numChosen, int totalOptions) 
        {
            int numComb = CalcFactorial(totalOptions) / (CalcFactorial(numChosen) * CalcFactorial(totalOptions - numChosen));

            return numComb;
        }

        private int CalcFactorial(int n) 
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