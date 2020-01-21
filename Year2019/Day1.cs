using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Year2019
{
    public class Day1 : TaskDay
    {
        readonly int[] _input = File.ReadLines(InputFileDirectory + "Day1.txt")
            .Select(l => Convert.ToInt32(l))
            .ToArray();

        public override string Task1()
        {
            var totalFuel = _input.Sum(ModuleFuelMass);

            return totalFuel.ToString();
        }

        public override string Task2()
        {
            var totalFuel = _input.Sum(FuelMass);

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
        private static int ModuleFuelMass(int moduleMass)
        {
            return (moduleMass / 3) - 2;
        }
    }
}
