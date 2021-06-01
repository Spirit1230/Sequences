using System.Collections.Generic;

namespace Iterations 
{
    static public partial class Combinations 
    {
        static private int[][] FindAllCombinations(int[] allPosValues, int numChosen, bool allowRepeats = false) 
        {
            List<int[]> allCombs = new List<int[]>();

            int[] posComb = new int[numChosen];

            //assigns first combination intital combination
            for (int pos = 0; pos < posComb.Length; pos++) 
            {
                if (allowRepeats) 
                {
                    posComb[pos] = 0;
                }
                else 
                {
                    posComb[pos] = pos;
                }
            }

            allCombs.Add(CopyIntArr(posComb));

            int posToUpdate = posComb.Length - 1;

            while (posToUpdate >= 0) 
            {
                if (posComb[posToUpdate] + 1 < allPosValues.Length) 
                {
                    if (posToUpdate == posComb.Length - 1) 
                    {
                        posComb[posToUpdate]++;
                        allCombs.Add(CopyIntArr(posComb));
                    }
                    else 
                    {
                        if (allowRepeats) 
                        {
                            int val = posComb[posToUpdate] + 1;

                            for (int i = posToUpdate; i < posComb.Length; i++) 
                            {
                                posComb[i] = val;
                            }

                            posToUpdate = posComb.Length - 1;

                            allCombs.Add(CopyIntArr(posComb));
                        }
                        else 
                        {
                            int val = posComb[posToUpdate] + 1;

                            if (allPosValues.Length - val >= posComb.Length - posToUpdate) 
                            {
                                for (int i = posToUpdate; i < posComb.Length; i++) 
                                {
                                    posComb[i] = val + i - posToUpdate;
                                }

                                posToUpdate = posComb.Length - 1;

                                allCombs.Add(CopyIntArr(posComb));
                            }
                            else 
                            {
                                posToUpdate--;
                            }
                        }
                    }
                }
                else 
                {
                    posToUpdate--;
                }
            }

            return allCombs.ToArray();
        }
    }
}