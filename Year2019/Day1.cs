using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Year2019
{
    public class Day1 : TaskDay
    {
        public static new string Task2()
        {
            int[] input = File.ReadLines(InputFileDirectory +  "Day1.txt")
                .Select(l => Convert.ToInt32(l))
                .ToArray();

            var totalFuel = input.Sum(FuelMass);

            return totalFuel.ToString();
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
