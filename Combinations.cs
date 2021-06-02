using System.Collections.Generic;

namespace Sequences
{
    static public partial class Combinations 
    {
        static private int[][] FindAllCombinations(int[] allPosValues, int numChosen, bool allowRepeats = false) 
        {
            //Finds all combinations with a given length of a set of values and returns all of them as an array of arrays
            //order doesn't matter for combinations so {0, 1, 2} is equivalent to {2, 0, 1}

            List<int[]> allCombs = new List<int[]>();

            //assigns an intital combination and adds to list
            int[] posComb = new int[numChosen];

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

            //finds each new combination by counting through each position in the original array
            //works a bit like a digital clock, counts the seconds and as that gets to its max value it increases the minutes and restarts counting the seconds
            //when reseting positions are set to be higher or equal to the position being updated to avoid repeat combinations
            //eg {0, 0, 1} > {0, 0, 2} > {0, 1, 1} > {0, 1, 2} > {0, 2, 2} > {1, 1, 1} > and so on
            int posToUpdate = posComb.Length - 1;

            while (posToUpdate >= 0) 
            {
                //Checks the current position can be increased, isn't at it's max value
                if (posComb[posToUpdate] + 1 < allPosValues.Length) 
                {
                    if (posToUpdate == posComb.Length - 1) 
                    {
                        //if pointer at final position
                        //updates position and adds new combination to list
                        posComb[posToUpdate]++;
                        allCombs.Add(CopyIntArr(posComb));
                    }
                    else 
                    {
                        if (allowRepeats) 
                        {
                            //if values can be repeated
                            int val = posComb[posToUpdate] + 1;

                            //updates current position and all following position to same value
                            for (int i = posToUpdate; i < posComb.Length; i++) 
                            {
                                posComb[i] = val;
                            }

                            //sets pointer to final position
                            posToUpdate = posComb.Length - 1;

                            //adds new combination to list
                            allCombs.Add(CopyIntArr(posComb));
                        }
                        else 
                        {
                            //if values can't be repeated
                            int val = posComb[posToUpdate] + 1;

                            //checks there are enough values to chose from to update all positions
                            if (allPosValues.Length - val >= posComb.Length - posToUpdate) 
                            {
                                //updates current position and all following positions incrementing by 1 each position
                                for (int i = posToUpdate; i < posComb.Length; i++) 
                                {
                                    posComb[i] = val + i - posToUpdate;
                                }

                                //sets pointer to final position
                                posToUpdate = posComb.Length - 1;

                                //adds new combination to list
                                allCombs.Add(CopyIntArr(posComb));
                            }
                            else 
                            {
                                //checks preceding position if current position can't be updated
                                posToUpdate--;
                            }
                        }
                    }
                }
                else 
                {
                    //checks preceding position if current position can't be updated
                    posToUpdate--;
                }
            }

            return allCombs.ToArray();
        }
    }
}