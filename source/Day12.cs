using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace adventofcode.source
{
    public static class Day12
    {
        static List<Stack<string>> paths = new List<Stack<string>>();

        public static string Part1(string[] data)
        {
            Dictionary<string, List<string>> links = new Dictionary<string, List<string>>();

            foreach(var line in data)
            {
                string[] items = line.Split('-');

                if (!links.ContainsKey(items[0]))
                {
                    links.Add(items[0], new List<string>()); ;
                }
                if (!links.ContainsKey(items[1]))
                {
                    links.Add(items[1], new List<string>()); ;
                }

                if (!links[items[0]].Contains(items[1])) links[items[0]].Add(items[1]);
                if (!links[items[1]].Contains(items[0])) links[items[1]].Add(items[0]);
            }

            var start = links["start"];

            foreach(var path in start)
            {
                Stack<string> stack = new Stack<string>();
                stack.Push("start");
                stack.Push(path);
                Search_part1(path, stack, links);
            }

            return paths.Count().ToString();
        }

        public static string Part2(string[] data)
        {
            Dictionary<string, List<string>> links = new Dictionary<string, List<string>>();

            foreach (var line in data)
            {
                string[] items = line.Split('-');

                if (!links.ContainsKey(items[0]))
                {
                    links.Add(items[0], new List<string>()); ;
                }
                if (!links.ContainsKey(items[1]))
                {
                    links.Add(items[1], new List<string>()); ;
                }

                if (!links[items[0]].Contains(items[1])) links[items[0]].Add(items[1]);
                if (!links[items[1]].Contains(items[0])) links[items[1]].Add(items[0]);
            }

            var start = links["start"];

            foreach (var path in start)
            {
                Stack<string> stack = new Stack<string>();
                stack.Push("start");
                stack.Push(path);
                Search_part2(path, stack, links);
            }

            return paths.Count().ToString();
        }

        private static void Search_part1(string currentPosition, Stack<string> route, Dictionary<string, List<string>> links)
        {
            var node = links[currentPosition];

            foreach (var path in node)
            {
                Stack<string> stack = new Stack<string>(route);
                stack.Push(path);

                if (path == "end") { paths.Add(route); continue; }
                if (route.Contains(path) && Regex.IsMatch(path, "^[a-z]+") || path == "start") continue;

                Search_part1(path, stack, links);
            }
        }

        private static void Search_part2(string currentPosition, Stack<string> route, Dictionary<string, List<string>> links)
        {
            var node = links[currentPosition];

            foreach (var path in node)
            {
                Stack<string> stack = new Stack<string>(route);
                stack.Push(path);

                if (path == "end") { paths.Add(route); continue; }
                if (path == "start") continue;
                if (route.Contains(path) && Regex.IsMatch(path, "^[a-z]+"))
                {
                    var query = route.GroupBy(x => x)
                                     .Where(g => g.Count() > 1)
                                     .Select(y => y.Key)
                                     .Where(x => Regex.IsMatch(x, "^[a-z]+"))
                                     .ToArray(); //lowercase duplicates

                    if (query.Length > 1) continue;
                    if (query.Length > 0) if(route.Select(x => x == query[0]).ToArray().Length > 2) continue;
                }

                Search_part2(path, stack, links);
            }
        }

    }
}
