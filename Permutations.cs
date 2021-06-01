using System; 
using System.Collections.Generic;

namespace Iterations 
{
    static public partial class Combinations 
    {
        static private int[][] FindAllPermutations(int[] allPosValues, int numChosen, bool allowRepeats = false) 
        {
            List<int[]> allPerms = new List<int[]>();

            int[] posPerm = new int[numChosen];

            for (int i = 0; i < posPerm.Length; i++) 
            {
                if (allowRepeats) 
                {
                    posPerm[i] = 0;
                }
                else 
                {
                    posPerm[i] = i;
                }
            }

            allPerms.Add(CopyIntArr(posPerm));

            int posToUpdate = posPerm.Length - 1;

            while (posToUpdate >= 0) 
            {
                if (allowRepeats) 
                {
                    if (posPerm[posToUpdate] + 1 < allPosValues.Length) 
                    {
                        posPerm[posToUpdate]++;

                        for (int i = posToUpdate + 1; i < posPerm.Length; i++) 
                        {
                            posPerm[i] = 0;
                        }

                        posToUpdate = posPerm.Length - 1;

                        allPerms.Add(CopyIntArr(posPerm));
                    }
                    else 
                    {
                        posToUpdate--;
                    }
                }
                else 
                {

                }
            }

            return allPerms.ToArray();
        }
    }
}