using System;
using Year2019;

namespace Launcher
{
    class Program
    {
        const string inputFilesDirectory = "..\\..\\..\\..\\Year2019\\InputFiles\\";
        static void Main(string[] args)
        {
            Console.WriteLine("Launcher");
            IntCode robot = new IntCode(inputFilesDirectory + "Day1.txt");
            Console.WriteLine(robot.Output);
            Class1.Run();
            Console.ReadKey();
        }
    }
}
