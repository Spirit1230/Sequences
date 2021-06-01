using System;
using static Iterations.Combinations;

namespace Iterations
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] testVals = new string[] {"APPLES", "PEARS", "ORANGES", "BANNANAS", "GRAPES", "AUBERGINE"};

            // FindCombsTest(testVals);
            // FindCombsWithRepsTest(testVals);

            FindPermsWithRepsTest(testVals);
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

            Console.WriteLine("Are all combinations unique?  {0}", AreAllCombinationsUnique(allCombs).ToString());

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

            Console.WriteLine("Are all combinations unique?  {0}", AreAllCombinationsUnique(allCombs).ToString());

            Console.WriteLine();
        }

        static private void FindPermsWithRepsTest(string[] testVals) 
        {
            Console.WriteLine("Finding all permutations with repeats\n");

            string[][] allPerms = GetPermutationsWithRepeats(testVals, 3);

            foreach (string[] perm in allPerms) 
            {
                Console.WriteLine(string.Join(" OR ", perm));
            }

            Console.WriteLine();

            Console.WriteLine("Found {0}/{1} permutations", allPerms.Length, CalculateTotalPermutationsWithRepeats(3, testVals.Length));

            Console.WriteLine();

            Console.WriteLine("Are all permutations unique?  {0}", AreAllPermutationsUnique(allPerms).ToString());

            Console.WriteLine();
        }

        static private bool AreAllCombinationsUnique(string[][] toTest) 
        {
            bool allUnique = true;

            for (int i = 0; i < toTest.Length; i++) 
            {
                string[] toCheck = toTest[i];

                for (int j = 0; j < toTest.Length; j++) 
                {
                    if (i != j) 
                    {
                        if (!checkCombinationsDiffer(toCheck, toTest[j])) 
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

        static private bool checkCombinationsDiffer(string[] toCheck, string[] testAgainst) 
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

        static private bool AreAllPermutationsUnique(string[][] toTest) 
        {
            bool result = true;

            for (int i = 0; i < toTest.Length; i++) 
            {
                string[] toCheck = toTest[i];

                for (int j = 0; j < toTest.Length; j++) 
                {
                    if (i != j) 
                    {
                        string[] testAgainst = toTest[j];

                        if (!CheckPermutationsDiffer(toCheck, testAgainst)) 
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        static private bool CheckPermutationsDiffer(string[] toCheck, string[] testAgainst) 
        {
            bool result = false;

            for (int i = 0; i < toCheck.Length; i++) 
            {
                if (toCheck[i] != testAgainst[i]) 
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
