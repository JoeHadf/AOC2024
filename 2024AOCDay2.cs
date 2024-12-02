using System;
using System.Collections.Generic;
using System.IO;

namespace Day2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"C:\Users\Josep\Documents\AOC2024\Day2Input.txt");
            char[] separators = new char[] { ' ' };

            List<List<int>> levelLists = new List<List<int>>(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                string[] splitInput = input[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                List<int> currentLevelList = new List<int>(splitInput.Length);
                for (int j = 0; j < splitInput.Length; j++)
                {
                    currentLevelList.Add(int.Parse(splitInput[j]));
                }
                levelLists.Add(currentLevelList);
            }

            int safeCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                List<int> currentLevelList = levelLists[i];

                bool listIsSafe = LevelsAreSafe(currentLevelList, out int initialBadLevelIndex);

                if (!listIsSafe)
                {
                    List<int> removalList0 = new List<int>(currentLevelList);
                    List<int> removalList1 = new List<int>(currentLevelList);
                    List<int> removalList2 = new List<int>(currentLevelList);
                    
                    removalList0.RemoveAt(0);
                    removalList1.RemoveAt(initialBadLevelIndex);
                    removalList2.RemoveAt(initialBadLevelIndex+1);

                    bool removalList0IsSafe = LevelsAreSafe(removalList0, out int ignore0);
                    bool removalList1IsSafe = LevelsAreSafe(removalList1, out int ignore1);
                    bool removalList2IsSafe = LevelsAreSafe(removalList2, out int ignore2);

                    listIsSafe = removalList0IsSafe || removalList1IsSafe || removalList2IsSafe;

                    if (!listIsSafe)
                    {
                        int z = 0;
                    }
                }
                
                if (listIsSafe)
                {
                    safeCount++;
                }
            }
            
            Console.WriteLine($"Safe Count: {safeCount}");

            bool LevelsAreSafe(List<int> levelList, out int initialBadLevelIndex)
            {
                bool levelsAreSafe = true;
                initialBadLevelIndex = -1;
                
                bool isIncreasing = false;
                bool isDecreasing = false;
                
                for (int j = 0; j < levelList.Count - 1; j++)
                {
                    int thisElement = levelList[j];
                    int nextElement = levelList[j + 1];
                    int difference = nextElement - thisElement;

                    if (!isIncreasing && !isDecreasing)
                    {
                        if (difference > 0 && difference <= 3)
                        {
                            isIncreasing = true;
                        }
                        else if (difference < 0 && difference >= -3)
                        {
                            isDecreasing = true;
                        }
                        else
                        {
                            levelsAreSafe = false;
                            initialBadLevelIndex = j;
                            break;
                        }
                    }
                    else if (isIncreasing && (difference <= 0 || difference > 3))
                    {
                        levelsAreSafe = false;
                        initialBadLevelIndex = j;
                        break;
                    }
                    else if (isDecreasing && (difference >= 0 || difference < -3))
                    {
                        levelsAreSafe = false;
                        initialBadLevelIndex = j;
                        break;
                    }
                }

                return levelsAreSafe;
            }
        }
    }
}