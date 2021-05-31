using System;
using static Iterations.Combinations;

namespace Iterations
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] testVals = new string[] {"APPLES", "PEARS", "ORANGES", "BANNANAS", "GRAPES", "AUBERGINE"};

            FindCombsTest(testVals);
            FindCombsWithRepsTest(testVals);
        }

        static private void FindCombsTest(string[] testVals) 
        {
            Console.WriteLine("Finding all combinations\n");

            string[][] allCombs = GetCombinations(testVals, 3);

            foreach (string[] comb in allCombs) 
            {
                Console.WriteLine(string.Join(" OR ", comb));
            }

            Console.WriteLine();

            Console.WriteLine("Found {0}/{1} combinations", allCombs.Length, CalculateTotalCombinations(3, testVals.Length));

            Console.WriteLine();

            Console.WriteLine("Are all combinations unique?  {0}", AreCombinationsUnique(allCombs).ToString());

            Console.WriteLine();
        }

        static private void FindCombsWithRepsTest(string[] testVals) 
        {
            Console.WriteLine("Finding all combinations with repeats\n");

            string[][] allCombs = GetCombinationsWithRepeats(testVals, 3);

            foreach (string[] comb in allCombs) 
            {
                Console.WriteLine(string.Join(" OR ", comb));
            }

            Console.WriteLine();

            Console.WriteLine("Found {0}/{1} combinations", allCombs.Length, CalculateTotalCombinationsWithRepeats(3, testVals.Length));

            Console.WriteLine();

            Console.WriteLine("Are all combinations unique?  {0}", AreCombinationsUnique(allCombs).ToString());

            Console.WriteLine();
        }

        static private bool AreCombinationsUnique(string[][] toTest) 
        {
            bool allUnique = true;

            for (int i = 0; i < toTest.Length; i++) 
            {
                string[] toCheck = toTest[i];

                for (int j = 0; j < toTest.Length; j++) 
                {
                    if (i != j) 
                    {
                        if (!checkCombinations(toCheck, toTest[j])) 
                        {
                            allUnique = false;
                            break;
                        }
                    }
                }

                if (!allUnique) 
                {
                    break;
                }
            }

            return allUnique;
        }

        static private bool checkCombinations(string[] toCheck, string[] testAgainst) 
        {
            int uniquenessVal = 0;

            foreach (string val in toCheck) 
            {
                int numInToCheck = 0;
                int numInTestAgainst = 0;

                for (int i = 0; i < testAgainst.Length; i++) 
                {
                    if (toCheck[i] == val) 
                    {
                        numInToCheck++;
                    }

                    if (testAgainst[i] == val) 
                    {
                        numInTestAgainst++;
                    }
                }

                uniquenessVal += (numInToCheck > numInTestAgainst) ? numInToCheck - numInTestAgainst : numInTestAgainst - numInToCheck;
            }

            bool uniqueVal;

            if (uniquenessVal > 0) 
            {
                uniqueVal = true;
            }
            else 
            {
                uniqueVal = false;
            }

            return uniqueVal;
        }
    }
}
