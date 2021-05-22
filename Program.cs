using System;
using static Iterations.Combinations;

namespace Iterations
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        static public void Test() 
        {
            string[] testVals = new string[] {"APPLES", "PEARS", "ORANGES", "BANNANAS", "GRAPES", "AUBERGINE"};

            for (int i = 1; i < testVals.Length; i++) 
            {
                foreach (string[] comb in FindAllCombinations(testVals, i)) 
                {
                    Console.WriteLine(string.Join(" OR ", comb));
                }
            }
        }
    }
}
