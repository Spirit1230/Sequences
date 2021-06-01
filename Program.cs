using System;
using System.Diagnostics;
using static Iterations.Combinations;

namespace Iterations
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] testVals = new string[] {"APPLES", "PEARS", "ORANGES", "BANNANAS", "GRAPES", "AUBERGINE"};

            FindCombsTest(testVals, 4);
            FindCombsWithRepsTest(testVals, 4);

            FindPermsTest(testVals, 6);
            FindPermsWithRepsTest(testVals, 6);
        }

        static private void FindCombsTest(string[] testVals, int numToChoose) 
        {
            Stopwatch timer = new Stopwatch();

            Console.WriteLine("Finding all combinations\n");

            timer.Start();
            string[][] allCombs = GetCombinations(testVals, numToChoose);
            timer.Stop();

            // foreach (string[] comb in allCombs) 
            // {
            //     Console.WriteLine(string.Join(" OR ", comb));
            // }

            Console.WriteLine();

            Console.WriteLine("Found {0}/{1} combinations in {2}ms", allCombs.Length, CalculateTotalCombinations(numToChoose, testVals.Length), timer.ElapsedMilliseconds);

            Console.WriteLine();

            Console.WriteLine("Are all combinations unique?  {0}", AreAllCombinationsUnique(allCombs).ToString());

            Console.WriteLine();
        }

        static private void FindCombsWithRepsTest(string[] testVals, int numToChoose) 
        {
            Stopwatch timer = new Stopwatch();

            Console.WriteLine("Finding all combinations with repeats\n");

            timer.Start();
            string[][] allCombs = GetCombinationsWithRepeats(testVals, numToChoose);
            timer.Stop();

            // foreach (string[] comb in allCombs) 
            // {
            //     Console.WriteLine(string.Join(" OR ", comb));
            // }

            Console.WriteLine();

            Console.WriteLine("Found {0}/{1} combinations in {2}ms", allCombs.Length, CalculateTotalCombinationsWithRepeats(numToChoose, testVals.Length), timer.ElapsedMilliseconds);

            Console.WriteLine();

            Console.WriteLine("Are all combinations unique?  {0}", AreAllCombinationsUnique(allCombs).ToString());

            Console.WriteLine();
        }

        static private void FindPermsTest(string[] testVals, int numToChoose) 
        {
            Stopwatch timer = new Stopwatch();

            Console.WriteLine("Finding all permutations\n");

            timer.Start();
            string[][] allPerms = GetPermutations(testVals, numToChoose);
            timer.Stop();

            // foreach (string[] perm in allPerms) 
            // {
            //     Console.WriteLine(string.Join(" OR ", perm));
            // }

            Console.WriteLine();

            Console.WriteLine("Found {0}/{1} permutations in {2}ms", allPerms.Length, CalculateTotalPermutations(numToChoose, testVals.Length), timer.ElapsedMilliseconds);

            Console.WriteLine();

            Console.WriteLine("Are all permutations unique?  {0}", AreAllPermutationsUnique(allPerms).ToString());

            Console.WriteLine();
        }

        static private void FindPermsWithRepsTest(string[] testVals, int numToChoose) 
        {
            Stopwatch timer = new Stopwatch();

            Console.WriteLine("Finding all permutations with repeats\n");

            timer.Start();
            string[][] allPerms = GetPermutationsWithRepeats(testVals, numToChoose);
            timer.Stop();

            // foreach (string[] perm in allPerms) 
            // {
            //     Console.WriteLine(string.Join(" OR ", perm));
            // }

            Console.WriteLine();

            Console.WriteLine("Found {0}/{1} permutations in {2}ms", allPerms.Length, CalculateTotalPermutationsWithRepeats(numToChoose, testVals.Length), timer.ElapsedMilliseconds);

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

                for (int j = i + 1; j < toTest.Length; j++) 
                {
                    if (!checkCombinationsDiffer(toCheck, toTest[j])) 
                    {
                        allUnique = false;
                        break;
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

                for (int j = i + 1; j < toTest.Length; j++) 
                {
                    if (!CheckPermutationsDiffer(toCheck, toTest[j])) 
                    {
                        result = false;
                        break;
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
