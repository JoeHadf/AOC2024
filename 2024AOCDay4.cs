using System;
using System.IO;

namespace Day4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"C:\Users\Josep\Documents\AOC2024\Day4Input.txt");

            int xmasCount = 0;

            for (int i = 1; i < input.Length - 1; i++)
            {
                for (int j = 1; j < input[i].Length - 1; j++)
                {
                    if (input[i][j] == 'A')
                    {
                        bool forwardDiagonalHasM = input[i - 1][j + 1] == 'M' || input[i + 1][j - 1] == 'M';
                        bool forwardDiagonalHasS = input[i - 1][j + 1] == 'S' || input[i + 1][j - 1] == 'S';

                        bool forwardDiagonalIsMas = forwardDiagonalHasM && forwardDiagonalHasS;
                        
                        bool backwardDiagonalHasM = input[i - 1][j - 1] == 'M' || input[i + 1][j + 1] == 'M';
                        bool backwardDiagonalHasS = input[i - 1][j - 1] == 'S' || input[i + 1][j + 1] == 'S';
                        
                        bool backwardDiagonalIsMas = backwardDiagonalHasM && backwardDiagonalHasS;

                        if (forwardDiagonalIsMas && backwardDiagonalIsMas)
                        {
                            xmasCount++;
                        }

                    }
                }
            }
            
            Console.WriteLine($"XMAS count : {xmasCount}");
        }
    }
}