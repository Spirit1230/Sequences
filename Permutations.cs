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
                    int nextVal = posPerm[posToUpdate];

                    bool foundNextVal = false;

                    while (!foundNextVal && nextVal + 1 < allPosValues.Length) 
                    {
                        nextVal++;

                        bool containsVal = false;

                        for (int i = 0; i <= posToUpdate; i++) 
                        {
                            if (nextVal == posPerm[i]) 
                            {
                                containsVal = true;
                            }
                        }

                        if (!containsVal) 
                        {
                            foundNextVal = true;
                        }
                    }

                    if (foundNextVal) 
                    {
                        posPerm[posToUpdate] = nextVal;

                        for (int i = posToUpdate + 1; i < posPerm.Length; i++) 
                        {
                            bool valRepeated;
                            int valToAdd = -1;

                            do 
                            {
                                valRepeated = false;
                                valToAdd++;

                                for (int pos = 0; pos < i; pos++) 
                                {
                                    if (valToAdd == posPerm[pos]) 
                                    {
                                        valRepeated = true;
                                        break;
                                    }
                                }
                            } while (valRepeated && valToAdd < allPosValues.Length);

                            if (!valRepeated) 
                            {
                                posPerm[i] = valToAdd;
                            }
                        }

                        posToUpdate = posPerm.Length - 1;

                        allPerms.Add(CopyIntArr(posPerm));
                    }
                    else 
                    {
                        posToUpdate--;
                    }
                }
            }

            return allPerms.ToArray();
        }
    }
}