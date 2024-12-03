using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Day3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input = File.ReadAllText(@"C:\Users\Josep\Documents\AOC2024\Day3Input.txt");

            int multSum = 0;
            bool isDoingMul = true;
            bool hasFoundMul = true;
            

            while (hasFoundMul)
            {
                int mulIndex = input.IndexOf("mul(", StringComparison.Ordinal);
                int doIndex = input.IndexOf("do()", StringComparison.Ordinal);
                int dontIndex = input.IndexOf("don't()", StringComparison.Ordinal);
                
                if (mulIndex == -1)
                {
                    hasFoundMul = false;
                }
                else
                {
                    doIndex = (doIndex == -1) ? int.MaxValue : doIndex;
                    dontIndex = (dontIndex == -1) ? int.MaxValue : dontIndex;
                    
                    if (doIndex < dontIndex && doIndex < mulIndex)
                    {
                        isDoingMul = true;
                        input = input.Substring(doIndex + 3);
                    }
                    else if (dontIndex < doIndex && dontIndex < mulIndex)
                    {
                        isDoingMul = false;
                        input = input.Substring(dontIndex + 6);
                    }
                    else
                    {
                        if (isDoingMul)
                        {
                            string subInput = input.Substring(mulIndex+4, 8);
                    
                            string[] numbers = subInput.Split(new char[] { ',', ')' });

                            List<int> numbersToMult = new List<int>(2);

                            if (numbers.Length >= 2)
                            {
                                if (int.TryParse(numbers[0], out int number1) && numbers[0].Length <= 3)
                                {
                                    numbersToMult.Add(number1);
                                }
            
                                if (int.TryParse(numbers[1], out int number2) && numbers[1].Length <= 3)
                                {
                                    numbersToMult.Add(number2);
                                }
                            }
                    
                            if (numbersToMult.Count == 2)
                            {
                                int mult = numbersToMult[0] * numbersToMult[1];
                                multSum += mult;
                            }
                        }
                        
                        input = input.Substring(mulIndex + 4);
                    }
                }
                
            }
            
            Console.WriteLine($"Mult Sum: {multSum}");

        }
    }
}