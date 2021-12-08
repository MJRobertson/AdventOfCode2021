using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace adventofcode.source
{
    public static class Day8
    {
        struct Input
        {
            public string sum;
            public string result;
        }

        public static string Part1(string[] data)
        {
            Dictionary<string, int> m_defaultNumberLink = new Dictionary<string, int>()
            {
                {"abcefg", 0},
                {"cf", 1},
                {"acdeg", 2},
                {"acdfg", 3},
                {"bcdf", 4},
                {"abdfg", 5},
                {"abdefg", 6},
                {"acf", 7},
                {"abcdefg", 8},
                {"abcdfg", 9}
            };

            Input[] inputs = data.Select(x => {
                string[] split = x.Split('|');
                return new Input{
                    sum = split[0],
                    result = split[1]
                    };
            }).ToArray();

            int missshapes = 0;

            foreach (var d in inputs)
            {
                string[] numbers = d.result.Split(' ');

                foreach (var n in numbers) 
                {
                    int l = n.Length;
                    if (l == 2 || l == 3 || l == 4 || l == 7) ++missshapes;
                } 
            }

            return missshapes.ToString();
        }

        public static string Part2(string[] data)
        {
            int total = 0;

            foreach (var item in data)
            {
                var Translation = new Dictionary<string, int>();

                string[] arr = item.Split('|');
                var wires = arr[0].Trim().Split(' ').Select((x) => string.Concat(x.OrderBy(c => c)).ToCharArray()).ToList();
                var Ouput = arr[1].Trim().Split(' ').Select((x) => string.Concat(x.OrderBy(c => c))).ToList();

                var one = wires.Where((x) => x.Length == 2).First();
                var four = wires.Where((x) => x.Length == 4).First();
                var seven = wires.Where((x) => x.Length == 3).First();
                var eight = wires.Where((x) => x.Length == 7).First();

                var middle_topLeft = four.Except(one);
                var top = seven.Except(one);
                var bottom_bottomLeft = eight.Except(four).Except(top);

                var nine = wires.Where((x) => x.Length == 6 && x.Except(four).Except(top).Count() == 1).First();

                var bottom = nine.Except(four).Except(top);
                var bottomLeft = bottom_bottomLeft.Except(bottom);

                var zero = wires.Where((x) => x.Length == 6 && x.Except(seven).Except(bottom_bottomLeft).Count() == 1).First();

                var topLeft = zero.Except(seven).Except(bottom_bottomLeft);
                var middle = middle_topLeft.Except(topLeft);

                var six = wires.Where((x) => x.Length == 6 && x.Except(top).Except(middle_topLeft).Except(bottom).Except(bottomLeft).Count() == 1).First();

                var bottomRight = six.Except(top).Except(middle_topLeft).Except(bottom).Except(bottomLeft);
                var topRight = one.Except(bottomRight);

                var two = eight.Except(bottomRight).Except(topLeft).ToArray();
                var three = nine.Except(topLeft).ToArray();
                var five = six.Except(bottomLeft).ToArray();

                Translation.Add(new string(zero), 0);
                Translation.Add(new string(one), 1);
                Translation.Add(new string(two), 2);
                Translation.Add(new string(three), 3);
                Translation.Add(new string(four), 4);
                Translation.Add(new string(five), 5);
                Translation.Add(new string(six), 6);
                Translation.Add(new string(seven), 7);
                Translation.Add(new string(eight), 8);
                Translation.Add(new string(nine), 9);

                var calc = Ouput.Select((x, index) => Translation[x] * (int)Math.Pow(10, 3 - index));
                total += calc.Sum();
            }


            return total.ToString();
        }
    }
}
