using System;
using System.IO;
using System.Linq;

namespace Year2019
{
    public class Day1
    {
        public static void Task2(string inputFile)
        {

            int totalFuel = 0;
            int[] input = File.ReadLines(inputFile)
                .Select(l => Convert.ToInt32(l))
                .ToArray();

            foreach (int number in input)
            {
                totalFuel += FuelMass(number);
            }

            Console.WriteLine(totalFuel);

        }

        public static int FuelMass(int moduleMass)
        {
            int fuel = (moduleMass / 3) - 2;
            if ((fuel / 3) - 2 > 0)
            {
                fuel += FuelMass(fuel);
            }
            return fuel;
        }
    }
}
