using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace adventofcode.source
{
    public static class Day5
    {
        public struct Vector2Int
        {
            public int X;
            public int Y;

            public Vector2Int(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public static string Part1(string[] data)
        {
            List<(Vector2Int start, Vector2Int end)> vecs = new List<(Vector2Int start, Vector2Int end)>();
            Dictionary<Vector2Int, int> cells = new Dictionary<Vector2Int, int>();

            foreach (var vec in data)
            {
                MatchCollection v = Regex.Matches(vec, "[0-9]+");
                Vector2Int start = new Vector2Int(int.Parse(v[0].Value), int.Parse(v[1].Value));
                Vector2Int end = new Vector2Int(int.Parse(v[2].Value), int.Parse(v[3].Value));
                vecs.Add((start, end));
            }

            foreach (var vec in vecs)
            {
                if (vec.start.X == vec.end.X || vec.start.Y == vec.end.Y)
                {
                    if (!cells.ContainsKey(vec.start)) cells.Add(vec.start, 0);
                    foreach(var point in GetPointsOnLine(vec.start.X, vec.start.Y, vec.end.X, vec.end.Y))
                    {
                        if (!cells.ContainsKey(point)) cells.Add(point, 0);
                        cells[point] += 1;
                    }
                }
            }

            int total = 0;

            foreach (var item in cells)
            {
                if (item.Value >= 2) ++total;
            }

            return total.ToString();
        }

        public static string Part2(string[] data)
        {
            List<(Vector2Int start, Vector2Int end)> vecs = new List<(Vector2Int start, Vector2Int end)>();
            Dictionary<Vector2Int, int> cells = new Dictionary<Vector2Int, int>();

            foreach (var vec in data)
            {
                MatchCollection v = Regex.Matches(vec, "[0-9]+");
                Vector2Int start = new Vector2Int(int.Parse(v[0].Value), int.Parse(v[1].Value));
                Vector2Int end = new Vector2Int(int.Parse(v[2].Value), int.Parse(v[3].Value));
                vecs.Add((start, end));
            }

            foreach (var vec in vecs)
            {
                if (!cells.ContainsKey(vec.start)) cells.Add(vec.start, 0);
                foreach (var point in GetPointsOnLine(vec.start.X, vec.start.Y, vec.end.X, vec.end.Y))
                {
                    if (!cells.ContainsKey(point)) cells.Add(point, 0);
                    cells[point] += 1;
                }
            }

            int total = 0;

            foreach (var item in cells)
            {
                if (item.Value >= 2) ++total;
            }

            return total.ToString();
        }

        public static IEnumerable<Vector2Int> GetPointsOnLine(int x0, int y0, int x1, int y1)
        {
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                int t;
                t = x0; // swap x0 and y0
                x0 = y0;
                y0 = t;
                t = x1; // swap x1 and y1
                x1 = y1;
                y1 = t;
            }
            if (x0 > x1)
            {
                int t;
                t = x0; // swap x0 and x1
                x0 = x1;
                x1 = t;
                t = y0; // swap y0 and y1
                y0 = y1;
                y1 = t;
            }
            int dx = x1 - x0;
            int dy = Math.Abs(y1 - y0);
            int error = dx / 2;
            int ystep = (y0 < y1) ? 1 : -1;
            int y = y0;
            for (int x = x0; x <= x1; x++)
            {
                yield return new Vector2Int((steep ? y : x), (steep ? x : y));
                error = error - dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
            yield break;
        }
    }
}
