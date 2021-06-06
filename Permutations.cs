using System.Collections.Generic;

namespace Sequences 
{
    static public partial class Combinations 
    {
        static private int[][] FindAllPermutations(int[] allPosValues, int numChosen, bool allowRepeats = false) 
        {
            //Finds all permutations with a given length or a set of values and returns all of them as an array of arrays
            //order does matter with permutations so {0, 1, 2} is not equivalent to {2, 0, 1}

            List<int[]> allPerms = new List<int[]>();

            //checks enough values given to produce permutations of the specified length
            if (0 < numChosen && (numChosen <= allPosValues.Length || allowRepeats)) 
            {
                //assigns an initial permutaion and adds to list
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

                //finds each new permutation by counting through each position in the original array
                //works a bit like a digital clock, counts the seconds and as that gets to its max value it increases the minutes and restarts counting the seconds
                //eg {0, 0, 1} > {0, 0, 2} > {0, 1, 0} > {0, 1, 1} > {0, 1, 2} > {0, 2, 0} > and so on
                int posToUpdate = posPerm.Length - 1;

                while (posToUpdate >= 0) 
                {
                    //checks whether repeats are allowed or not
                    if (allowRepeats) 
                    {
                        //checks current position can be updated
                        if (posPerm[posToUpdate] + 1 < allPosValues.Length) 
                        {
                            posPerm[posToUpdate]++;

                            //resets all following positions to 0
                            for (int i = posToUpdate + 1; i < posPerm.Length; i++) 
                            {
                                posPerm[i] = 0;
                            }

                            //sets pointer to final position
                            posToUpdate = posPerm.Length - 1;

                            //adds new permutation to list
                            allPerms.Add(CopyIntArr(posPerm));
                        }
                        else 
                        {
                            //checks preceding position if current position can't be updated
                            posToUpdate--;
                        }
                    }
                    else 
                    {
                        //finds next value that the current position can be updated to
                        int nextVal = posPerm[posToUpdate];

                        bool foundNextVal = false;

                        while (!foundNextVal && nextVal + 1 < allPosValues.Length) 
                        {
                            nextVal++;

                            bool containsVal = false;

                            //checks value isn't contained in any positions preceding the one being updated
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

                            //updates all following positions
                            for (int i = posToUpdate + 1; i < posPerm.Length; i++) 
                            {
                                //finds next non repeated value
                                bool valRepeated;
                                int valToAdd = -1; //set to -1 so value 0 is checked in first iteration

                                do 
                                {
                                    valRepeated = false;
                                    valToAdd++;

                                    //checks value isn't contained in and positions preceding the one being updated
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
                                    //updates position
                                    //a value will always be found since all possible values are being checked
                                    posPerm[i] = valToAdd;
                                }
                            }

                            //sets pointer to final position
                            posToUpdate = posPerm.Length - 1;

                            //adds new permutation to list
                            allPerms.Add(CopyIntArr(posPerm));
                        }
                        else 
                        {
                            //checks preceding position if current position can't be updated
                            posToUpdate--;
                        }
                    }
                }
            }            

            return allPerms.ToArray();
        }
    }
}