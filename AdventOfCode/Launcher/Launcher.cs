using System;
using System.Collections.Generic;
using Year2019;

namespace Launcher
{
    internal static class Launcher
    {
        private static readonly Dictionary<string, TaskDay> Days = new Dictionary<string, TaskDay>
        {
            {"1", new Day1()},
            {"2", new Day2()},
            {"3", new Day6()},
            {"4", new Day4()},
            {"5", new Day5()},
            {"6", new Day6()},
            //{"7", new Day7()},
            //{"8", new Day8()},
            //{"9", new Day9()},
            //{"10", new Day10()},
            //{"11", new Day11()},
            //{"12", new Day12()},
            //{"13", new Day13()},
            //{"14", new Day14()},
            //{"15", new Day15()},
            //{"16", new Day16()},
            //{"17", new Day17()},
            //{"18", new Day18()},
            //{"19", new Day19()},
            //{"20", new Day20()},
            //{"21", new Day21()},
            //{"22", new Day22()},
            //{"23", new Day23()},
            //{"24", new Day24()},
            //{"25", new Day25()},
        };

        private static void Main()
        {
            var input = "1";
            while (input != "0")
            {
                Console.WriteLine("Available advent days are:");
                Console.WriteLine();
                foreach (var availableDay in Days.Keys)
                {
                    Console.Write(availableDay + ", ");
                }
                Console.WriteLine();
                Console.WriteLine("Enter day number. To exit - enter 0.");
                input = Console.ReadLine();
                if (Days.ContainsKey(input ?? throw new InvalidOperationException()))
                {
                    var day = Days[input];
                    Console.WriteLine("Enter task number (1 or 2):");
                    var task = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    switch (task)
                    {
                        case 1:
                            Console.WriteLine(day.Task1());
                            break;
                        case 2:
                            Console.WriteLine(day.Task2());
                            break;
                    }
                }
                else
                {
                    if (input == "0")
                    {
                        break;
                    }

                    Console.WriteLine("Day not found.");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
