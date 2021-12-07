using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace adventofcode.source
{
    public static class Day2
    {
        public static string Part1(string[] data)
        {
            (string direction, int change)[] split = ConvertToSplitTuple(data);

            int horiz = 0;
            int depth = 0;

            foreach (var m in split)
            {
                if (m.direction.IndexOf("forward") >= 0)
                {
                    horiz += m.change;
                }
                else if (m.direction.IndexOf("up") >= 0)
                {
                    depth -= m.change;
                }
                else if (m.direction.IndexOf("down") >= 0)
                {
                    depth += m.change;
                }
            }

            int result = horiz * depth;
            return result.ToString();
        }

        public static string Part2(string[] data)
        {
            (string direction, int change)[] split = ConvertToSplitTuple(data);

            int horiz = 0;
            int depth = 0;
            int aim = 0;

            foreach (var m in split)
            {
                if (m.direction.IndexOf("forward") >= 0)
                {
                    horiz += m.change;
                    depth += m.change * aim;
                }
                else if (m.direction.IndexOf("up") >= 0)
                {
                    aim -= m.change;
                }
                else if (m.direction.IndexOf("down") >= 0)
                {
                    aim += m.change;
                }
            }

            int result = horiz * depth;
            return result.ToString();
        }

        private static (string direction, int change)[] ConvertToSplitTuple(string[] data)
        {
            return Array.ConvertAll(data, s =>
            {
                var split = s.Split(' ');
                return (split[0], int.Parse(split[1]));
            });
        }
    }
}
