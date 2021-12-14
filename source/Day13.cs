using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace adventofcode.source
{
    public static class Day13
    {
        public static string Part1(string[] data)
        {
            List<(int x, int y)> coords = new List<(int x, int y)>();
            List<(string dir, int num)> directions = new List<(string dir, int num)>();

            bool dirInit = false;
            foreach(var line in data)
            {
                if (string.IsNullOrWhiteSpace(line)) { dirInit = true; continue; }

                if (!dirInit)
                {
                    string[] vals = line.Split(',');
                    coords.Add((int.Parse(vals[0]),int.Parse(vals[1])));
                }
                else
                {
                    MatchCollection v = Regex.Matches(line, "[xy]=[0-9]+");
                    string[] vals = v[0].Value.Split('=');
                    directions.Add((vals[0], int.Parse(vals[1])));
                }
            }

            int largestX = coords.OrderByDescending(i => i.x).First().x/2;
            int largestY = coords.OrderByDescending(i => i.y).First().y;

            int dots = 0;

            for (int i = 0; i < 1; ++i)
            {
                var instruction = directions[i];
                List<(int x, int y)> newCoords = new List<(int x, int y)>();

                if (instruction.dir == "x")
                {
                    foreach(var point in coords)
                    {
                        if (point.x > instruction.num)
                        {
                            var first = point.x - instruction.num;
                            var second = instruction.num - first;
                            (int x, int y) newPos = (second, point.y);
                            if (!newCoords.Contains(newPos)) newCoords.Add(newPos);
                        }
                        else
                        {
                            if (!newCoords.Contains(point)) newCoords.Add(point);

                        }
                    }
                }
                else if (instruction.dir == "y")
                {
                    foreach (var point in coords)
                    {
                        if (point.y > instruction.num)
                        {
                            var first = point.y - instruction.num;
                            var second = instruction.num - first;
                            (int x, int y) newPos = (point.x, second);
                            if (!newCoords.Contains(newPos)) newCoords.Add(newPos);
                        }
                        else
                        {
                            if (!newCoords.Contains(point)) newCoords.Add(point);

                        }
                    }
                }

                coords = new List<(int x, int y)>(newCoords);
            }

            coords = coords.Distinct().ToList();

            for (int y = 0; y <= largestY; ++y)
            {
                for (int x = 0; x <= largestX; ++x)
                {
                    (int x, int y) tmp = (x, y);
                    if (coords.Contains(tmp))
                    {
                        ++dots;
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.Write("\n");
            }

            return dots.ToString();
        }

        public static string Part2(string[] data)
        {
            List<(int x, int y)> coords = new List<(int x, int y)>();
            List<(string dir, int num)> directions = new List<(string dir, int num)>();

            bool dirInit = false;
            foreach (var line in data)
            {
                if (string.IsNullOrWhiteSpace(line)) { dirInit = true; continue; }

                if (!dirInit)
                {
                    string[] vals = line.Split(',');
                    coords.Add((int.Parse(vals[0]), int.Parse(vals[1])));
                }
                else
                {
                    MatchCollection v = Regex.Matches(line, "[xy]=[0-9]+");
                    string[] vals = v[0].Value.Split('=');
                    directions.Add((vals[0], int.Parse(vals[1])));
                }
            }

            int dots = 0;

            for (int i = 0; i < directions.Count; ++i)
            {
                var instruction = directions[i];
                List<(int x, int y)> newCoords = new List<(int x, int y)>();

                if (instruction.dir == "x")
                {
                    foreach (var point in coords)
                    {
                        if (point.x > instruction.num)
                        {
                            var first = point.x - instruction.num;
                            var second = instruction.num - first;
                            (int x, int y) newPos = (second, point.y);
                            if (!newCoords.Contains(newPos)) newCoords.Add(newPos);
                        }
                        else
                        {
                            if (!newCoords.Contains(point)) newCoords.Add(point);

                        }
                    }
                }
                else if (instruction.dir == "y")
                {
                    foreach (var point in coords)
                    {
                        if (point.y > instruction.num)
                        {
                            var first = point.y - instruction.num;
                            var second = instruction.num - first;
                            (int x, int y) newPos = (point.x, second);
                            if (!newCoords.Contains(newPos)) newCoords.Add(newPos);
                        }
                        else
                        {
                            if (!newCoords.Contains(point)) newCoords.Add(point);

                        }
                    }
                }

                coords = new List<(int x, int y)>(newCoords);
            }

            coords = coords.Distinct().ToList();

            int largestX = coords.OrderByDescending(i => i.x).First().x;
            int largestY = coords.OrderByDescending(i => i.y).First().y;

            for (int y = 0; y <= largestY; ++y)
            {
                for (int x = 0; x <= largestX; ++x)
                {
                    (int x, int y) tmp = (x, y);
                    if (coords.Contains(tmp))
                    {
                        ++dots;
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.Write("\n");
            }

            return dots.ToString();
        }
    }
}
