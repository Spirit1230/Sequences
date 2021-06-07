using System;
using System.Diagnostics;
using static Sequences.Combinations;

namespace Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            //regular tests
            Console.WriteLine("Regular Tests\n");
            string[] testVals = new string[] {"APPLES", "PEARS", "ORANGES", "BANNANAS", "GRAPES", "AUBERGINE"};

            FindCombsTest(testVals, 3);
            FindCombsWithRepsTest(testVals, 3);

            FindPermsTest(testVals, 4);
            FindPermsWithRepsTest(testVals, 4);

            //tests when length asked for is greater than number of values provided
            Console.WriteLine("Testing when not enough values\n");
            string[] testVals2 = new string[] {"APPLES", "PEARS", "ORANGES"};

            FindCombsTest(testVals2, 5);
            FindCombsWithRepsTest(testVals2, 5);

            FindPermsTest(testVals2, 5);
            FindPermsWithRepsTest(testVals2, 5);

            //tests negative values
            Console.WriteLine("Testing negativ values\n");
            FindCombsTest(testVals2, -1);
            FindCombsWithRepsTest(testVals2, -2);

            FindPermsTest(testVals2, -5);
            FindPermsWithRepsTest(testVals2, -5);

            //tests 0 value
            Console.WriteLine("Testing 0\n");
            FindCombsTest(testVals2, 0);
            FindCombsWithRepsTest(testVals2, 0);

            FindPermsTest(testVals2, 0);
            FindPermsWithRepsTest(testVals2, 0);

            //tests empty string[] value
            Console.WriteLine("Testing empty array\n");
            FindCombsTest(new string[0], 0);
            FindCombsWithRepsTest(new string[0], 0);

            FindPermsTest(new string[0], 0);
            FindPermsWithRepsTest(new string[0], 0);

            //random tests
            RandomTests();

            //stress tests
            string[] testVals3 = new string[] {"APPLES", "PEARS", "ORANGES", "BANNANAS", "GRAPES", "AUBERGINE", "TOMATO", "POTATO", "BROCCOLI", "BEANS", "PINNAPPLE"};
            StressTests(testVals3);
        }

        static private void FindCombsTest(string[] testVals, int numToChoose) 
        {   
            //Tests whether all combinations of a certain length from a set of values are found
            //values can't be repeated

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

            //Checks correct number of combinations are found
            Console.WriteLine("Found {0}/{1} combinations in {2}ms", allCombs.Length, CalculateTotalCombinations(numToChoose, testVals.Length), timer.ElapsedMilliseconds);

            Console.WriteLine();

            //Checks whether all the combinations are unique
            Console.WriteLine("Are all combinations unique?  {0}", AreAllCombinationsUnique(allCombs).ToString());

            Console.WriteLine();
        }

        static private void FindCombsWithRepsTest(string[] testVals, int numToChoose) 
        {
            //Tests whether all combinations of a certain length from a set of values are found
            //values can be repeated

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

            //Checks correct number of combinations are found
            Console.WriteLine("Found {0}/{1} combinations in {2}ms", allCombs.Length, CalculateTotalCombinationsWithRepeats(numToChoose, testVals.Length), timer.ElapsedMilliseconds);

            Console.WriteLine();

            //Checks all combinations are unique
            Console.WriteLine("Are all combinations unique?  {0}", AreAllCombinationsUnique(allCombs).ToString());

            Console.WriteLine();
        }

        static private void FindPermsTest(string[] testVals, int numToChoose) 
        {
            //Tests whether all permutations of a certain length from a set of values are found
            //values can't be repeated

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

            //Checks correct number of permutations are found
            Console.WriteLine("Found {0}/{1} permutations in {2}ms", allPerms.Length, CalculateTotalPermutations(numToChoose, testVals.Length), timer.ElapsedMilliseconds);

            Console.WriteLine();

            //Checks whether all permutations are unique
            Console.WriteLine("Are all permutations unique?  {0}", AreAllPermutationsUnique(allPerms).ToString());

            Console.WriteLine();
        }

        static private void FindPermsWithRepsTest(string[] testVals, int numToChoose) 
        {
            //Tests whether all permutations of a certain length from a set of values are found
            //values can be repeated

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

            //Checks whether the correct number of permutations are found
            Console.WriteLine("Found {0}/{1} permutations in {2}ms", allPerms.Length, CalculateTotalPermutationsWithRepeats(numToChoose, testVals.Length), timer.ElapsedMilliseconds);

            Console.WriteLine();

            //Checks wheter all the permutations are unique
            Console.WriteLine("Are all permutations unique?  {0}", AreAllPermutationsUnique(allPerms).ToString());

            Console.WriteLine();
        }

        static private void RandomTests() 
        {
            Random rnd = new Random();

            for (int test = 0; test < 10000; test++) 
            {
                int nextLen = rnd.Next(0, 7);

                string[] testStrArr = new string[nextLen];

                for (int i = 0; i < nextLen; i++) 
                {
                    testStrArr[i] = i.ToString();
                }

                int combPermLen = rnd.Next(0, nextLen + 1);

                string[][] combTest = GetCombinations(testStrArr, combPermLen);
                string[][] combRepTest = GetCombinationsWithRepeats(testStrArr, combPermLen);
                string[][] permTest = GetPermutations(testStrArr, combPermLen);
                string[][] permRepTest = GetPermutationsWithRepeats(testStrArr, combPermLen);
            }
        }

        static private void StressTests(string[] testVals) 
        {
            Console.WriteLine("Stress Tests");

            Stopwatch timer = new Stopwatch();

            timer.Start();
            string[][] combTest = GetCombinations(testVals, testVals.Length / 2);
            timer.Stop();

            Console.WriteLine("Found {0}/{1} combinations in {2}ms", combTest.Length, CalculateTotalCombinations(testVals.Length / 2, testVals.Length), timer.ElapsedMilliseconds); 
            timer.Reset();

            timer.Start();
            string[][] combRepTest = GetCombinationsWithRepeats(testVals, testVals.Length / 2);
            timer.Stop();

            Console.WriteLine("Found {0}/{1} combinations with repetions in {2}ms", combRepTest.Length, CalculateTotalCombinationsWithRepeats(testVals.Length / 2, testVals.Length), timer.ElapsedMilliseconds); 
            timer.Reset();

            timer.Start();
            string[][] permTest = GetPermutations(testVals, testVals.Length);
            timer.Stop();

            Console.WriteLine("Found {0}/{1} permutations in {2}ms", permTest.Length, CalculateTotalPermutations(testVals.Length / 2, testVals.Length), timer.ElapsedMilliseconds); 
            timer.Reset();

            timer.Start();
            string[][] permRepTest = GetPermutationsWithRepeats(testVals, testVals.Length);
            timer.Stop();

            Console.WriteLine("Found {0}/{1} permutations with repetitions in {2}ms", permRepTest.Length, CalculateTotalPermutationsWithRepeats(testVals.Length / 2, testVals.Length), timer.ElapsedMilliseconds); 
            timer.Reset();
        }

        static private bool AreAllCombinationsUnique(string[][] toTest) 
        {
            //runs through a list of combinations to check they are all different

            bool allUnique = true;

            for (int i = 0; i < toTest.Length; i++) 
            {
                string[] toCheck = toTest[i];

                //starts at i + 1 to prevent double checking
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
            //checks the amount of each value in both combinations differ

            bool result = false;

            foreach (string val in toCheck) 
            {
                //counts number of each value in both combinations
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

                //if the number of a unique value in each combination differs then the combinations differ
                if (numInTestAgainst - numInToCheck != 0) 
                {
                    result = true;
                }
            }

            return result;
        }

        static private bool AreAllPermutationsUnique(string[][] toTest) 
        {
            //runs through a list of permutations to check they are all different

            bool result = true;

            for (int i = 0; i < toTest.Length; i++) 
            {
                string[] toCheck = toTest[i];

                //starts at i + 1 to prevent double checking
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
            //checks the equivalent positions in two permutaions are different

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
