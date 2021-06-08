using System;
using System.Diagnostics;
using static Sequences.Combinations;

namespace Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDataTypes();

            // //regular tests
            // Console.WriteLine("Regular Tests\n");
            // string[] testVals = new string[] {"APPLES", "PEARS", "ORANGES", "BANNANAS", "GRAPES", "AUBERGINE"};

            // FindCombsTest(testVals, 3);
            // FindCombsWithRepsTest(testVals, 3);

            // FindPermsTest(testVals, 4);
            // FindPermsWithRepsTest(testVals, 4);

            // //tests when length asked for is greater than number of values provided
            // Console.WriteLine("Testing when not enough values\n");
            // string[] testVals2 = new string[] {"APPLES", "PEARS", "ORANGES"};

            // FindCombsTest(testVals2, 5);
            // FindCombsWithRepsTest(testVals2, 5);

            // FindPermsTest(testVals2, 5);
            // FindPermsWithRepsTest(testVals2, 5);

            // //tests negative values
            // Console.WriteLine("Testing negativ values\n");
            // FindCombsTest(testVals2, -1);
            // FindCombsWithRepsTest(testVals2, -2);

            // FindPermsTest(testVals2, -5);
            // FindPermsWithRepsTest(testVals2, -5);

            // //tests 0 value
            // Console.WriteLine("Testing 0\n");
            // FindCombsTest(testVals2, 0);
            // FindCombsWithRepsTest(testVals2, 0);

            // FindPermsTest(testVals2, 0);
            // FindPermsWithRepsTest(testVals2, 0);

            // //tests empty string[] value
            // Console.WriteLine("Testing empty array\n");
            // FindCombsTest(new string[0], 0);
            // FindCombsWithRepsTest(new string[0], 0);

            // FindPermsTest(new string[0], 0);
            // FindPermsWithRepsTest(new string[0], 0);

            // //random tests
            // RandomTests();

            // //stress tests
            // string[] testVals3 = new string[] {"APPLES", "PEARS", "ORANGES", "BANNANAS", "GRAPES", "AUBERGINE", "TOMATO", "POTATO", "BROCCOLI", "BEANS", "PINNAPPLE"};
            // StressTests(testVals3);
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

        static private void TestDataTypes() 
        {
            Console.WriteLine("Testing with bool[]\n");

            bool[] boolArr = new bool[] {true, false};

            var boolCombs = GetCombinationsWithRepeats(boolArr, boolArr.Length);

            Console.WriteLine("Found {0}/{1} combinations with repeats", boolCombs.Length, CalculateTotalCombinationsWithRepeats(boolArr.Length, boolArr.Length));
            Console.WriteLine("Are all combinations unique?\t{0}", AreAllCombinationsUnique(boolCombs));
            Console.WriteLine();

            var boolPerms = GetPermutationsWithRepeats(boolArr, boolArr.Length);

            Console.WriteLine("Found {0}/{1} permutations with repeats", boolPerms.Length, CalculateTotalPermutationsWithRepeats(boolArr.Length, boolArr.Length));
            Console.WriteLine("Are all permutations unique?\t{0}", AreAllPermutationsUnique(boolPerms));
            Console.WriteLine();

            Console.WriteLine("Testing with char[]\n");

            char[] charArr = new char[] {'a', 'b', 'c'};

            var charCombs = GetCombinations(charArr, charArr.Length / 2);

            Console.WriteLine("Found {0}/{1} combinations", charCombs.Length, CalculateTotalCombinations(charArr.Length / 2, charArr.Length));
            Console.WriteLine("Are all combinations unique?\t{0}", AreAllCombinationsUnique(charCombs));
            Console.WriteLine();

            var charCombsRep = GetCombinationsWithRepeats(charArr, charArr.Length);

            Console.WriteLine("Found {0}/{1} combinations with repeats", charCombsRep.Length, CalculateTotalCombinationsWithRepeats(charArr.Length, charArr.Length));
            Console.WriteLine("Are all combinations unique?\t{0}", AreAllCombinationsUnique(charCombsRep));
            Console.WriteLine();

            var charPerms = GetPermutations(charArr, charArr.Length);

            Console.WriteLine("Found {0}/{1} permutations", charPerms.Length, CalculateTotalPermutations(charArr.Length, charArr.Length));
            Console.WriteLine("Are all permutations unique?\t{0}", AreAllPermutationsUnique(charPerms));
            Console.WriteLine();

            var charPermsRep = GetPermutationsWithRepeats(charArr, charArr.Length);

            Console.WriteLine("Found {0}/{1} permutations with repeats", charPermsRep.Length, CalculateTotalPermutationsWithRepeats(charArr.Length, charArr.Length));
            Console.WriteLine("Are all permutations unique?\t{0}", AreAllPermutationsUnique(charPermsRep));
            Console.WriteLine();

            Console.WriteLine("Testing with int[]\n");

            int[] intArr = new int[] {1, 2, 3, 4};

            var intCombs = GetCombinations(intArr, intArr.Length / 2);

            Console.WriteLine("Found {0}/{1} combinations", intCombs.Length, CalculateTotalCombinations(intArr.Length / 2, intArr.Length));
            Console.WriteLine("Are all combinations unique?\t{0}", AreAllCombinationsUnique(intCombs));
            Console.WriteLine();

            var intCombsRep = GetCombinationsWithRepeats(intArr, intArr.Length);

            Console.WriteLine("Found {0}/{1} combinations with repeats", intCombsRep.Length, CalculateTotalCombinationsWithRepeats(intArr.Length, intArr.Length));
            Console.WriteLine("Are all combinations unique?\t{0}", AreAllCombinationsUnique(intCombsRep));
            Console.WriteLine();

            var intPerms = GetPermutations(intArr, intArr.Length);

            Console.WriteLine("Found {0}/{1} permutations", intPerms.Length, CalculateTotalPermutations(intArr.Length, intArr.Length));
            Console.WriteLine("Are all permutations unique?\t{0}", AreAllPermutationsUnique(intPerms));
            Console.WriteLine();

            var intPermsRep = GetPermutationsWithRepeats(intArr, intArr.Length);

            Console.WriteLine("Found {0}/{1} permutations with repeats", intPermsRep.Length, CalculateTotalPermutationsWithRepeats(intArr.Length, intArr.Length));
            Console.WriteLine("Are all permutations unique?\t{0}", AreAllPermutationsUnique(intPermsRep));
            Console.WriteLine();

            Console.WriteLine("Testing user defined class array\n");

            Pear[] pears = new Pear[4];
            
            for (int i = 0; i < pears.Length; i++) 
            {
                pears[i] = new Pear(i);
            }

            var pearCombs = GetCombinations(pears, pears.Length / 2);
            Console.WriteLine("Found {0}/{1} combinations", pearCombs.Length, CalculateTotalCombinations(pears.Length / 2, pears.Length));

            Console.WriteLine();

            var pearCombsRep = GetCombinationsWithRepeats(pears, pears.Length);
            Console.WriteLine("Found {0}/{1} combinations with repeats", pearCombsRep.Length, CalculateTotalCombinationsWithRepeats(pears.Length, pears.Length));

            Console.WriteLine();

            var pearPerms = GetPermutations(pears, pears.Length);
            Console.WriteLine("Found {0}/{1} permutations", pearPerms.Length, CalculateTotalPermutations(pears.Length, pears.Length));

            Console.WriteLine();

            var pearPermsRep = GetPermutationsWithRepeats(pears, pears.Length);
            Console.WriteLine("Found {0}/{1} permutations with repeats", pearPermsRep.Length, CalculateTotalPermutationsWithRepeats(pears.Length, pears.Length));

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

            Console.WriteLine("Found {0}/{1} permutations in {2}ms", permTest.Length, CalculateTotalPermutations(testVals.Length, testVals.Length), timer.ElapsedMilliseconds); 
            timer.Reset();

            timer.Start();
            string[][] permRepTest = GetPermutationsWithRepeats(testVals, testVals.Length);
            timer.Stop();

            Console.WriteLine("Found {0}/{1} permutations with repetitions in {2}ms", permRepTest.Length, CalculateTotalPermutationsWithRepeats(testVals.Length, testVals.Length), timer.ElapsedMilliseconds); 
            timer.Reset();
        }

        static private bool AreAllCombinationsUnique<T>(T[][] toTest) 
        {
            //runs through a list of combinations to check they are all different

            bool allUnique = true;

            for (int i = 0; i < toTest.Length; i++) 
            {
                T[] toCheck = toTest[i];

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

        static private bool checkCombinationsDiffer<T>(T[] toCheck, T[] testAgainst) 
        {
            //checks the amount of each value in both combinations differ

            bool result = false;

            foreach (var val in toCheck) 
            {
                //counts number of each value in both combinations
                int numInToCheck = 0;
                int numInTestAgainst = 0;

                for (int i = 0; i < testAgainst.Length; i++) 
                {
                    if (Convert.ToString(toCheck[i]) == Convert.ToString(val))
                    {
                        numInToCheck++;
                    }

                    if (Convert.ToString(testAgainst[i]) == Convert.ToString(val)) 
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

        static private bool AreAllPermutationsUnique<T>(T[][] toTest) 
        {
            //runs through a list of permutations to check they are all different

            bool result = true;

            for (int i = 0; i < toTest.Length; i++) 
            {
                T[] toCheck = toTest[i];

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

        static private bool CheckPermutationsDiffer<T>(T[] toCheck, T[] testAgainst) 
        {
            //checks the equivalent positions in two permutaions are different

            bool result = false;

            for (int i = 0; i < toCheck.Length; i++) 
            {
                if (Convert.ToString(toCheck[i]) != Convert.ToString(testAgainst[i])) 
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }

    public class Pear 
    {
        private int pearNum;

        public Pear(int num) 
        {
            pearNum = num;
        }

        public string GetName() 
        {
            return "PEAR" + pearNum.ToString();
        }
    }
}
