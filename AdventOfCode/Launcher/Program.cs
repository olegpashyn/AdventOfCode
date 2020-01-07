using System;
using Year2019;

namespace Launcher
{
    class Program
    {
        const string inputFileDirectory = "..\\..\\..\\..\\Year2019\\InputFiles\\";
        static void Main()
        {
            Day1.Task2(inputFileDirectory + "Day1.txt");
            Console.ReadKey();
        }
    }
}
