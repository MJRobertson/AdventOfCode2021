using System;
using System.Linq;

namespace adventofcode.source
{
    public static class Day7
    {
        public static string Part1(string[] data)
        {
            int[] position = data[0].Split(',').Select(x => int.Parse(x)).ToArray();
            Array.Sort(position);

            int median = position[position.Length / 2];

            int fuel = position.Select(x => Math.Abs(median - x)).Sum();

            return fuel.ToString();
        }

        public static string Part2(string[] data)
        {
            int[] position = data[0].Split(',').Select(x => int.Parse(x)).ToArray();
            Array.Sort(position);

            int mean = (position.Sum()) / position.Length;

            int total = (int)position.Select(x => Math.Abs(mean - x)).Select(x => x * (x + 1) / 2).Sum();
            return total.ToString();
        }
    }
}
