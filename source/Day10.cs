using System;
using System.Linq;
using System.Collections.Generic;

namespace adventofcode.source
{
    public static class Day10
    {
        public static string Part1(string[] data)
        {

            (char opening, char closing)[] pairs = new (char, char)[]
            {
                ('(',')'),
                ('[', ']'),
                ('{', '}'),
                ('<', '>')
            };

            long total = 0;
            List<long> total_2 = new List<long>();
            foreach (var str in data)
            {
                List<char> corruptedOnes = new List<char>();
                List<char> incompleteOnes = new List<char>();
                int index = 0;
                char target = ' ';
                while (index < str.Length)
                {
                    char nextChar = str[index];
                    if (pairs.Where(x => x.opening == nextChar).Count() >= 1)
                    {
                        target = pairs.Where(x => x.opening == nextChar).Select(x => x.closing).First();
                        ParseCharacter(str, ref index, target, ref corruptedOnes, ref incompleteOnes, pairs);
                    }
                    else
                    {
                        if (nextChar != target) corruptedOnes.Add(nextChar);
                    }

                    ++index;
                }
                total += AddValueCorrupted(corruptedOnes);
                if (incompleteOnes.Count > 0) total_2.Add(AddValueIncomplete(incompleteOnes));
            }

            long[] sorted = total_2.ToArray();
            Array.Sort(sorted);
            long answer2 = sorted[sorted.Length/2];

            return " part 1: " + total.ToString() + " part 2: " + answer2.ToString();
        }

        public static string Part2(string[] data)
        {
            return Part1(data);
        }

        static void ParseCharacter(string mainstring, ref int index, char target, ref List<char> corrupted, ref List<char> incomplete, (char opening, char closing)[] collection)
        {
        Looper:
            ++index;
            if (index >= mainstring.Length)
            {
                if (corrupted.Count < 1) incomplete.Add(target);
                return;
            }

            char nextChar = mainstring[index];
            bool isOpening = collection.Where(x => x.opening == nextChar).Count() >= 1;

            if (isOpening)
            {
                char t = collection.Where(x => x.opening == nextChar).Select(x => x.closing).First();
                ParseCharacter(mainstring, ref index, t, ref corrupted, ref incomplete, collection);
            }
            else
            {
                if (nextChar != target) corrupted.Add(nextChar);
                return;
            }

            goto Looper;
        }

        static int AddValueCorrupted(List<char> listToAdd)
        {
            int val = 0;
            foreach (var c in listToAdd)
            {
                switch (c)
                {
                    case ')':
                        val += 3;
                        break;
                    case ']':
                        val += 57;
                        break;
                    case '}':
                        val += 1197;
                        break;
                    case '>':
                        val += 25137;
                        break;
                    default:
                        break;
                }
            }
            return val;
        }

        static long AddValueIncomplete(List<char> listToAdd)
        {
            long val = 0;
            foreach (var c in listToAdd)
            {
                switch (c)
                {
                    case ')':
                        val *= 5;
                        val += 1;
                        break;
                    case ']':
                        val *= 5;
                        val += 2;
                        break;
                    case '}':
                        val *= 5;
                        val += 3;
                        break;
                    case '>':
                        val *= 5;
                        val += 4;
                        break;
                    default:
                        break;
                }
            }
            return val;
        }
    }
}
