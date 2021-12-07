using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adventofcode.source
{
    public static class Day1
    {
        //find out how many times it increases
        public static string Part1(string[] data)
        {
            int count = 0;
            for (int i = 1; i< data.Length; ++i)
            {
                if (int.Parse(data[i]) > int.Parse(data[i-1])) ++count;
            }

            return count.ToString();
        }

        //sum for three measurements using letters to match
        public static string Part2(string[] data)
        {
            int[] myInts = Array.ConvertAll(data, s => int.Parse(s));
            int count = 0;
            for (int i = 3, j = i-1; i < data.Length; ++i, ++j)
            {
                int first = (new int[3] { myInts[j], myInts[j - 1], myInts[j - 2] }).Sum();
                int second = (new int[3] { myInts[i], myInts[i - 1], myInts[i - 2] }).Sum();

                if (second > first) ++count;
            }

            return count.ToString();
        }

    }
}
