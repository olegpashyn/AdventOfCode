using System;
using System.IO;
using System.Linq;

namespace Year2019
{
    public class Day1
    {
        public static void Task2(string inputFile)
        {
            var input = File.ReadLines(inputFile)
                .Select(l => Convert.ToInt32(l))
                .ToArray();

            var totalFuel = input.Sum(FuelMass);

            Console.WriteLine(totalFuel);

        }

        private static int FuelMass(int moduleMass)
        {
            var fuel = (moduleMass / 3) - 2;
            if ((fuel / 3) - 2 > 0)
            {
                fuel += FuelMass(fuel);
            }
            return fuel;
        }
    }
}
