using System;
using System.Collections.Generic;
using Year2019;

namespace Launcher
{
    internal static class Launcher
    {
        private static Dictionary<string, Func<string>[]> _days = new Dictionary<string, Func<string>[]>
        {
            {"1", new Func<string>[] {() => Day1.Task1(), () => Day1.Task2(), } },
            {"2", new Func<string>[] {() => Day2.Task1(), () => Day2.Task2(), } },
            {"3", new Func<string>[] {() => Day3.Task1(), () => Day3.Task2(), } },
            //{"4", new Func<string>[] {() => Day4.Task1(), () => Day4.Task2(), } },
            //{"5", new Func<string>[] {() => Day5.Task1(), () => Day5.Task2(), } },
            //{"6", new Func<string>[] {() => Day6.Task1(), () => Day6.Task2(), } },
            //{"7", new Func<string>[] {() => Day7.Task1(), () => Day7.Task2(), } },
            //{"8", new Func<string>[] {() => Day8.Task1(), () => Day8.Task2(), } },
            //{"9", new Func<string>[] {() => Day9.Task1(), () => Day9.Task2(), } },
            //{"10", new Func<string>[] {() => Day10.Task1(), () => Day10.Task2(), } },
            //{"11", new Func<string>[] {() => Day11.Task1(), () => Day11.Task2(), } },
            //{"12", new Func<string>[] {() => Day12.Task1(), () => Day12.Task2(), } },
            //{"13", new Func<string>[] {() => Day13.Task1(), () => Day13.Task2(), } },
            //{"14", new Func<string>[] {() => Day14.Task1(), () => Day14.Task2(), } },
            //{"15", new Func<string>[] {() => Day15.Task1(), () => Day15.Task2(), } },
            //{"16", new Func<string>[] {() => Day16.Task1(), () => Day16.Task2(), } },
            //{"17", new Func<string>[] {() => Day17.Task1(), () => Day17.Task2(), } },
            //{"18", new Func<string>[] {() => Day18.Task1(), () => Day18.Task2(), } },
            //{"19", new Func<string>[] {() => Day19.Task1(), () => Day19.Task2(), } },
            //{"20", new Func<string>[] {() => Day20.Task1(), () => Day20.Task2(), } },
            //{"21", new Func<string>[] {() => Day21.Task1(), () => Day21.Task2(), } },
            //{"22", new Func<string>[] {() => Day22.Task1(), () => Day22.Task2(), } },
            //{"23", new Func<string>[] {() => Day23.Task1(), () => Day23.Task2(), } },
            //{"24", new Func<string>[] {() => Day24.Task1(), () => Day24.Task2(), } },
            //{"25", new Func<string>[] {() => Day25.Task1(), () => Day25.Task2(), } },
        };
         
        
        private static void Main()
        {
            var input = "1";
            while (input != "0")
            {
                Console.WriteLine("Available advent days are:");
                Console.WriteLine();
                foreach (var availableDay in _days.Keys)
                {
                    Console.Write(availableDay + ", ");
                }
                Console.WriteLine();
                Console.WriteLine("Enter day number. To exit - enter 0.");
                input = Console.ReadLine();
                if (_days.ContainsKey(input))
                {
                    var day = _days[input];
                    Console.WriteLine("Enter task number (1 or 2):");
                    var task = int.Parse(Console.ReadLine());
                    Console.WriteLine(day[task - 1].Invoke());
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
            }
        }
    }
}
