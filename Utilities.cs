namespace Sequences 
{
    static public partial class Combinations 
    {
        static private int[] ConvertToIntArray<T>(T[] stringArr) 
        {
            //Converts a string array to an array of numbers
            //Repeated values in the string array will be assigned different numbers

            int[] intArr = new int[stringArr.Length];

            for (int i = 0; i < stringArr.Length; i++) 
            {
                intArr[i] = i;
            }

            return intArr;
        }

        static private T[] ConvertToTArr<T>(int[] intArray, T[] mapArr) 
        {
            //Converts the int array to a string array
            //stringArr parameter is used as a key to translate the int array

            T[] convArr = new T[intArray.Length];

            for (int i = 0; i < intArray.Length; i++) 
            {
                convArr[i] = mapArr[intArray[i]];
            }

            return convArr;
        }

        static private int CalcFactorial(int n) 
        {
            //Calculates the factorial "!" by multiplying all numbers up to the specified number
            //eg 6! = 6 * 5 * 4 * 3 * 2 * 1 = 720

            int result = 1;

            for (int i = 1; i <= n; i++) 
            {
                result *= i;
            }

            return result;
        }

        static private int[] CopyIntArr(int[] toCopy) 
        {
            //Creats a copy of the specified int array
            //This allows the original array to be manipulated without changing the copied array

            int[] copiedArr = new int[toCopy.Length];

            for (int i = 0; i < toCopy.Length; i++) 
            {
                copiedArr[i] = toCopy[i];
            }

            return copiedArr;
        }
    }
}