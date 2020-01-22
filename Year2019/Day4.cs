using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2019
{
    public class Day4 : TaskDay
    {
        private readonly int _start = int.Parse(File.ReadAllText(InputFileDirectory + "Day4.txt").Split('-')[0]);
        private readonly int _end = int.Parse(File.ReadAllText(InputFileDirectory + "Day4.txt").Split('-')[1]);

        public override string Task1()
        {
            var count = 0;
            for (var i = _start; i <= _end; i++)
            {
                var number = i.ToString().ToCharArray();
                if ((AdjacentSame(number).Max() > 1) & NeverDecrease(number))
                {
                    count++;
                }
            }

            return count.ToString();
        }

        public override string Task2()
        {
            var count = 0;
            for (var i = _start; i <= _end; i++)
            {
                var number = i.ToString().ToCharArray();
                if (AdjacentSame(number).Contains(2) & NeverDecrease(number))
                {
                    count++;
                }
            }

            return count.ToString();
        }


        private static IEnumerable<int> AdjacentSame(char[] number)
        {
            var count = 1;
            var counters = new List<int>();
            for (var a = 0; a < 5; a++)
            {
                if (number[a] == number[a + 1])
                {
                    count++;     
                }
                else
                {
                    counters.Add(count);
                    count = 1;
                }
            }
            counters.Add(count);

            return counters;
        }

        private static bool NeverDecrease(IReadOnlyList<char> number)
        {
            var flag = true;
            for (var a = 0; a < 5; a++)
            {
                if (number[a] > number[a + 1])
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
