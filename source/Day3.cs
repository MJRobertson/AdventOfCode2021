using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode.source
{
    public static class Day3
    {
        public static string Part1(string[] data)
        {
            int l = data.Length;
            string[] arr = new string[data[0].Length];

            Parallel.For(0, arr.Length, (c) =>
            {
                int one = 0, zero = 0;

                for (int i = 0; i < l; ++i)
                {
                    if (data[i][c] == '1') ++one;
                    if (data[i][c] == '0') ++zero;
                }

                lock (arr)
                {
                    arr[c] = one > zero ? "1" : "0";
                }

            });

            string result = string.Join("", arr);
            int gamma = Convert.ToInt32(result, 2);
            int epsilon = ~gamma & 0x00000FFF;
            int answer = gamma * epsilon;
            return answer.ToString();
        }

        public static string Part2(string[] data)
        {
            
            int chars = data[0].Length;

            List<string> largest = new List<string>(data);
            List<string> smallest = new List<string>(data);

            for (int c = 0; c < chars; ++c)
            {
                if (largest.Count == 1 && smallest.Count == 1) break;
                RemoveItems(largest, c, (nc) => largest.RemoveAll(s => s[c] == nc), null);
                RemoveItems(smallest, c, null, (nc) => smallest.RemoveAll(s => s[c] == nc));
            }

            int oxy = Convert.ToInt32(largest[0], 2);
            int co2 = Convert.ToInt32(smallest[0], 2);

            int result = oxy * co2;

            return result.ToString();

            static void RemoveItems(List<string> source, int c, Action<char> OnBigger, Action<char> OnSmaller)
            {
                if (source.Count == 1) return;
                int ones = 0;
                int zeros = 0;
                int dLen = source.Count;

                for (int i = 0; i < dLen; ++i)
                {
                    if (source[i][c] == '1') ++ones;
                    if (source[i][c] == '0') ++zeros;
                }

                if (ones == zeros)
                {
                    OnBigger?.Invoke('1');
                    OnSmaller?.Invoke('0');
                }
                else
                {
                    OnBigger?.Invoke(ones > zeros ? '1' : '0');
                    OnSmaller?.Invoke(ones > zeros ? '0' : '1');
                }
            }
        }
    }
}
