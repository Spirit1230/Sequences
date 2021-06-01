namespace Iterations 
{
    static public partial class Combinations 
    {
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

        static private int CalcFactorial(int n) 
        {
            int result = 1;

            for (int i = 1; i <= n; i++) 
            {
                result *= i;
            }

            return result;
        }

        static private int[] CopyIntArr(int[] toCopy) 
        {
            int[] copiedArr = new int[toCopy.Length];

            for (int i = 0; i < toCopy.Length; i++) 
            {
                copiedArr[i] = toCopy[i];
            }

            return copiedArr;
        }
    }
}