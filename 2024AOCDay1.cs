﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace Day1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"C:\Users\Josep\Documents\AOC2024\Day1Input.txt");
            char[] seperators = new char[] { ' ' };

            Dictionary<int, int> valueQuantityInList1 = new Dictionary<int, int>(input.Length);
            Dictionary<int, int> valueQuantityInList2 = new Dictionary<int, int>(input.Length);

            HashSet<int> list1Values = new HashSet<int>(input.Length);
            
            for (int i = 0; i < input.Length; i++)
            {
                string[] splitInput = input[i].Split(seperators, System.StringSplitOptions.RemoveEmptyEntries);

                int list1Value = int.Parse(splitInput[0]);
                int list2Value = int.Parse(splitInput[1]);

                list1Values.Add(list1Value);

                if (valueQuantityInList1.ContainsKey(list1Value))
                {
                    valueQuantityInList1[list1Value] += 1;
                }
                else
                {
                    valueQuantityInList1[list1Value] = 1;
                }
                
                if (valueQuantityInList2.ContainsKey(list2Value))
                {
                    valueQuantityInList2[list2Value] += 1;
                }
                else
                {
                    valueQuantityInList2[list2Value] = 1;
                }
                
            }

            long similaritySum = 0;

            foreach ( (int key, int value) in valueQuantityInList1)
            {
                int occurrencesInList1 = idAndQuantityPair.Value;
                int occurrencesInList2 = valueQuantityInList2.TryGetValue(idAndQuantityPair.Key, out int occurrences) ? occurrences : 0;

                similaritySum += occurrencesInList1 * idAndQuantityPair.Key * occurrencesInList2;
            }
            
            Console.WriteLine($"Similarity sum: {similaritySum}");

        }
    }
}