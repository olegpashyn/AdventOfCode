using System;
using System.Collections.Generic;
using Year2019;

namespace Launcher
{
    internal static class Launcher
    {
        private const string InputFileDirectory = "..\\..\\..\\..\\Year2019\\InputFiles\\";
        private static Dictionary<string, Action<string>> _days = new Dictionary<string, Action<string>>
        {
            {"1", (inputFilesFolder) => Day1.Task2(InputFileDirectory)},
            {"2", new Day2()},
            {"3", new Day3()},
            //{"4", new Day4()},
            //{"5", new Day5()},
            //{"6", new Day6()},
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
            Console.WriteLine("Available advent days are:");
            Console.WriteLine();
            foreach (var availableDay in _days.Keys)
            {
                Console.Write(availableDay + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("Enter day number");
            var input = Console.ReadLine();
            if (_days.ContainsKey(input ?? throw new InvalidOperationException()))
            {
                var day = _days[input];
                Console.WriteLine((TaskDay.TasksAvailable));
            }
            else
            {
                Console.WriteLine("Day not found.");
            }

            Console.ReadKey();
        }
    }
}
