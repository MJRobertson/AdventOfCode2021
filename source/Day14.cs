using System.Linq;
using System.Collections.Generic;

namespace adventofcode.source
{
    public static class Day14
    {
        public static string Part1(string[] data)
        {
            string main = data[0];
            Dictionary<string, char> mapping = new Dictionary<string, char>();

            for (int i = 2; i < data.Length; ++i)
            {
                string[] split = data[i].Split("->").Select(x => x.Trim()).ToArray();
                mapping[split[0]] = split[1].ToCharArray()[0];
            }

            Dictionary<string, int> occ = new Dictionary<string, int>();
            Dictionary<char, int> count = new Dictionary<char, int>();
            for (int i = 0; i < main.Length-1; ++i)
            {
                char char1 = main[i];
                char char2 = main[i + 1];
                if (!count.ContainsKey(char1)) count.Add(char1, 0);
                if (!count.ContainsKey(char2)) count.Add(char2, 0);
                count[char1] += 1;
                count[char2] += 1;

                string id = $"{char1}{char2}";

                if (!occ.ContainsKey(id)) occ.Add(id, 0);
                occ[id] += 1;
            }

            int step = 10;
            for (int i = 0; i < step; ++i)
            {
                Dictionary<string, int> newOcc = new Dictionary<string, int>();
                Dictionary<char, int> newCount = new Dictionary<char, int>();
                int c = 0;

                foreach (var code in occ)
                {
                    ++c;
                    if (code.Value == 0) continue;

                    char extra = mapping[$"{code.Key[0]}{code.Key[1]}"];
                    string m1 = $"{code.Key[0]}{extra}";
                    string m2 = $"{extra}{code.Key[1]}";

                    if (!newOcc.ContainsKey(m1)) newOcc.Add(m1, 0);
                    if (!newOcc.ContainsKey(m2)) newOcc.Add(m2, 0);
                    newOcc[m1] += code.Value;
                    newOcc[m2] += code.Value;

                    if (!newCount.ContainsKey(extra)) newCount.Add(extra, 0);
                    if (!newCount.ContainsKey(code.Key[0])) newCount.Add(code.Key[0], 0);
                    if (!newCount.ContainsKey(code.Key[1])) newCount.Add(code.Key[1], 0);
                    newCount[extra] += code.Value;
                    newCount[code.Key[0]] += code.Value;
                    if (c == occ.Count) newCount[code.Key[1]] += 1;
                }

                occ = new Dictionary<string, int>(newOcc);
                count = new Dictionary<char, int>(newCount);
            }

            var max = count.Values.Max();
            var min = count.Values.Min();


            return (max-min).ToString();
        }

        public static string Part2(string[] data)
        {
            string main = data[0];
            Dictionary<string, char> mapping = new Dictionary<string, char>();

            for (int i = 2; i < data.Length; ++i)
            {
                string[] split = data[i].Split("->").Select(x => x.Trim()).ToArray();
                mapping[split[0]] = split[1].ToCharArray()[0];
            }

            Dictionary<string, long> occ = new Dictionary<string, long>();
            Dictionary<char, long> count = new Dictionary<char, long>();
            for (int i = 0; i < main.Length - 1; ++i)
            {
                char char1 = main[i];
                char char2 = main[i + 1];
                if (!count.ContainsKey(char1)) count.Add(char1, 0);
                if (!count.ContainsKey(char2)) count.Add(char2, 0);
                count[char1] += 1;
                count[char2] += 1;

                string id = $"{char1}{char2}";

                if (!occ.ContainsKey(id)) occ.Add(id, 0);
                occ[id] += 1;
            }

            int step = 40;
            for (int i = 0; i < step; ++i)
            {
                Dictionary<string, long> newOcc = new Dictionary<string, long>();
                Dictionary<char, long> newCount = new Dictionary<char, long>();
                int c = 0;

                foreach (var code in occ)
                {
                    ++c;
                    if (code.Value == 0) continue;

                    char extra = mapping[$"{code.Key[0]}{code.Key[1]}"];
                    string m1 = $"{code.Key[0]}{extra}";
                    string m2 = $"{extra}{code.Key[1]}";

                    if (!newOcc.ContainsKey(m1)) newOcc.Add(m1, 0);
                    if (!newOcc.ContainsKey(m2)) newOcc.Add(m2, 0);
                    newOcc[m1] += code.Value;
                    newOcc[m2] += code.Value;

                    if (!newCount.ContainsKey(extra)) newCount.Add(extra, 0);
                    if (!newCount.ContainsKey(code.Key[0])) newCount.Add(code.Key[0], 0);
                    if (!newCount.ContainsKey(code.Key[1])) newCount.Add(code.Key[1], 0);
                    newCount[extra] += code.Value;
                    newCount[code.Key[0]] += code.Value;
                    if (c == occ.Count) newCount[code.Key[1]] += 1;
                }

                occ = new Dictionary<string, long>(newOcc);
                count = new Dictionary<char, long>(newCount);
            }

            long max = count.Values.Max();
            long min = count.Values.Min();

            return (max - min).ToString();
        }
    }
}
