using System;
using System.Linq;

namespace Year2019
{
    public class Day2
    {
        public static void Task2()
        {

            int[] input = "1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,1,6,19,1,9,19,23,1,6,23,27,1,10,27,31,1,5,31,35,2,6,35,39,1,5,39,43,1,5,43,47,2,47,6,51,1,51,5,55,1,13,55,59,2,9,59,63,1,5,63,67,2,67,9,71,1,5,71,75,2,10,75,79,1,6,79,83,1,13,83,87,1,10,87,91,1,91,5,95,2,95,10,99,2,9,99,103,1,103,6,107,1,107,10,111,2,111,10,115,1,115,6,119,2,119,9,123,1,123,6,127,2,127,10,131,1,131,6,135,2,6,135,139,1,139,5,143,1,9,143,147,1,13,147,151,1,2,151,155,1,10,155,0,99,2,14,0,0".Split(',')
                .Select(str => int.Parse(str))
                .ToArray();
            int[] working = (int[])input.Clone();
            int search = 19690720;
            for (int d = 1; d <= 99; d++)
            {
                for (int e = 0; e < 99; e++)
                {
                    working = (int[])input.Clone();
                    working[1] = d;
                    working[2] = e;
                    if (result(working) == search)
                    {
                        Console.WriteLine(d * 100 + e);
                    }
                }
            }
        }

        private static int result(int[] instructions)
        {
            for (int position = 0; position < (instructions.Length - 4); position = position + 4)
            {
                int a = instructions[position + 1];
                int b = instructions[position + 2];
                int c = instructions[position + 3];

                if (instructions[position] == 1)
                {
                    instructions[c] = instructions[a] + instructions[b];
                }

                else if (instructions[position] == 2)
                {
                    instructions[c] = instructions[a] * instructions[b];
                }

                else if (instructions[position] == 99)
                {
                    break;
                }
            }
            return instructions[0];
        }
    }
}
