using adventofcode.source;
using System;
using System.IO;
using System.Reflection;

namespace adventofcode
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(folder, @"data/day12.txt");
            string[] lines = TextParser.ReadLines(path);

            //string Day1Part1Answer = Day1.Part1(lines);
            //string Day1Part2Answer = Day1.Part2(lines);
            //string Day2Part1Answer = Day2.Part1(lines);
            //string Day2Part2Answer = Day2.Part2(lines);
            //string Day3Part1Answer = Day3.Part1(lines);
            //string Day3Part2Answer = Day3.Part2(lines);
            //string Day4Part1Answer = Day4.Part1(lines);
            //string Day4Part2Answer = Day4.Part2(lines);
            //string Day5Part1Answer = Day5.Part1(lines);
            //string Day5Part2Answer = Day5.Part2(lines);
            //string Day6Part1Answer = Day6.Part1(lines);
            //string Day6Part2Answer = Day6.Part2_Good(lines);
            //string Day7Part1Answer = Day7.Part1(lines);
            //string Day7Part2Answer = Day7.Part2(lines);
            //string Day8Part1Answer = Day8.Part1(lines);
            //string Day8Part2Answer = Day8.Part2(lines);
            //string Day9Part1Answer = Day9.Part1(lines);
            //string Day9Part2Answer = Day9.Part2(lines);
            //string Day10Part1Answer = Day10.Part1(lines);
            //string Day10Part2Answer = Day10.Part2(lines);
            //string Day11Part1Answer = Day11.Part1(lines);
            //string Day11Part2Answer = Day11.Part2(lines);
            //string Day12Part1Answer = Day12.Part1(lines);
            string Day12Part2Answer = Day12.Part2(lines);
            Console.WriteLine(Day12Part2Answer);
            //Console.WriteLine(Day6Part2Answer);
        }
    }
}
