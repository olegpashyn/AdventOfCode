using System;
using Year2019;

namespace Launcher
{
    internal static class Launcher
    {
        const string inputFileDirectory = "..\\..\\..\\..\\Year2019\\InputFiles\\";

        private static void Main()
        {
            Day2.Task2(inputFileDirectory + "Day2.txt");
            Console.ReadKey();
        }
    }
}
