using System;
using static Iterations.Combinations;

namespace Iterations
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
        }

        static public void Test() 
        {
            string[] testVals = new string[] {"APPLES", "PEARS", "ORANGES", "BANNANAS", "GRAPES", "AUBERGINE"};

            for (int i = 1; i < testVals.Length; i++) 
            {
                foreach (string[] comb in GetCombinations(testVals, i)) 
                {
                    Console.WriteLine(string.Join(" OR ", comb));
                }
            }
        }

        static public void Test1() 
        {
            string[] testVals = new string[] {"APPLES", "PEARS", "ORANGES", "BANNANAS", "GRAPES", "AUBERGINE"};

            foreach (string[] comb in GetCombinations(testVals, 3)) 
            {
                Console.WriteLine(string.Join(" OR ", comb));
            }

            foreach (string[] comb in GetCombinationsWithRepeats(testVals, 3)) 
            {
                Console.WriteLine(string.Join(" OR ", comb));
            }
        }
    }
}
