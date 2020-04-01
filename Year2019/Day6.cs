using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Year2019
{
    public class Day6 : TaskDay
    {
        private static readonly string[] Input = File.ReadLines(InputFileDirectory + "Day6.txt").ToArray();
        Dictionary<string, string> orbits = new Dictionary<string, string>();
        public static int counter = 0;
        static List<string> youPath = new List<string>();
        static List<string> sanPath = new List<string>();


        public override string Task1()
        {
            foreach (string relation in Input)
            {
                string[] relations = relation.Split(')');
                orbits.Add(relations[1], relations[0]);
            }

            foreach (KeyValuePair<string, string> satelite in orbits)
            {
                Calculate(satelite.Key, orbits, 0);
            }

            return counter.ToString();
        }

        public override string Task2()
        {
            You("YOU", orbits);
            San("SAN", orbits);

            List<string> intersection = youPath.Select(item => (string)item.Clone()).ToList().Intersect(sanPath).ToList();

            string meetingPoint = intersection[0];
            int youIndex = youPath.IndexOf(meetingPoint);
            int sanIndex = sanPath.IndexOf(meetingPoint);

            return (youIndex + sanIndex).ToString();
        }

        public static void Calculate(string name, Dictionary<string, string> orbits, int count)
        {
            if (name != "COM")
            {
                counter++;
                Calculate(orbits[name], orbits, count);
            }
        }

        public static void You(string name, Dictionary<string, string> orbits)
        {
            if (name != "COM")
            {
                youPath.Add(orbits[name]);
                You(orbits[name], orbits);
            }
        }

        public static void San(string name, Dictionary<string, string> orbits)
        {
            if (name != "COM")
            {
                sanPath.Add(orbits[name]);
                San(orbits[name], orbits);
            }
        }
    }
}
