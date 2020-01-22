using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Year2019
{
    public class Day3 : TaskDay
    {
        private static readonly string[] Input = File.ReadLines(InputFileDirectory + "Day3.txt").ToArray();
        private static readonly string[] InputLine1 = Input[0].Split(',').ToArray();
        private static readonly string[] InputLine2 = Input[1].Split(',').ToArray();
        private static readonly List<string> Line1 = Path(InputLine1);
        private static readonly List<string> Line2 = Path(InputLine2);
        private readonly List<string> _intersections = Line1.Intersect(Line2).ToList();

        public override string Task1()
        {
            return (ShortestDist(_intersections)).ToString();
        }
        
        public override string Task2()
        {
            return (ShortestWay(Line1, Line2, _intersections)).ToString();
        }

        private static int ShortestWay(IList<string> line1, IList<string> line2, IEnumerable<string> intersections)
        {
            const int shortestWay = int.MaxValue;

            return (from point in intersections let line1Loc = line1.IndexOf(point) let line2Loc = line2.IndexOf(point) select line1Loc + line2Loc + 2).Concat(new[] {shortestWay}).Min();
        }

        private static int ShortestDist(IEnumerable<string> line)
        {
            return line.Select(coords => coords.Split(',')
                    .Select(int.Parse)
                    .ToArray())
                .Select(coord => Math.Abs(coord[0]) + Math.Abs(coord[1]))
                .Concat(new[] {int.MaxValue})
                .Min();
        }
        private static List<string> Path (IEnumerable<string> vectors)
        {
            var path = new List<string>();
            var x = 0;
            var y = 0;
            foreach (var t in vectors)
            {
                switch (t[0])
                {
                    case ('R'):
                        for (var i = 1;
                            i <= System.Convert.ToInt32(t.Substring(1));
                            i++)
                        {
                            x++;
                            path.Add(x + "," + y);
                        }

                        break;

                    case ('L'):
                        for (var i = 1;
                            i <= System.Convert.ToInt32(t.Substring(1));
                            i++)
                        {
                            x--;
                            path.Add(x + "," + y);
                        }

                        break;

                    case ('U'):
                        for (var i = 1;
                            i <= System.Convert.ToInt32(t.Substring(1));
                            i++)
                        {
                            y++;
                            path.Add(x + "," + y);
                        }

                        break;

                    case ('D'):
                        for (var i = 1;
                            i <= System.Convert.ToInt32(t.Substring(1));
                            i++)
                        {
                            y--;
                            path.Add(x + "," + y);
                        }

                        break;
                }
            }

            return path;
        }
    }
}