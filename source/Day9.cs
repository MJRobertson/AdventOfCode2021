using System;
using System.Collections.Generic;

namespace adventofcode.source
{
    public static class Day9
    {
        public static string Part1(string[] data)
        {
            int[][] arr = new int[data.Length][];

            for(int x = 0; x < data.Length; ++x)
            {
                string line = data[x];
                arr[x] = new int[line.Length];
                for (int y = 0; y < line.Length; ++y)
                {
                    arr[x][y] = int.Parse(line[y].ToString());
                }
            }

            int total = 0;

            for (int x = 0; x < arr.Length; ++x)
            {
                for (int y = 0; y < arr[x].Length; ++y)
                {
                    int? top = null, right = null, down = null, left = null;

                    int centre = arr[x][y];

                    if (y+1 < arr[x].Length) top = arr?[x]?[y+1];
                    if (x+1 < arr.Length) right = arr?[x+1]?[y];
                    if (y - 1 >=0) down = arr?[x]?[y-1];
                    if (x-1 >= 0) left = arr?[x-1]?[y];

                    if ((top == null || centre < top) &&
                        (right == null || centre < right) &&
                        (down == null || centre < down) &&
                        (left == null || centre < left))
                    {
                        total += (1 + centre);
                    }
                }
            }

            return total.ToString();
        }

        public static string Part2(string[] data)
        {
            int?[][] arr = new int?[data.Length][];

            for (int x = 0; x < data.Length; ++x)
            {
                string line = data[x];
                arr[x] = new int?[line.Length];
                for (int y = 0; y < line.Length; ++y)
                {
                    arr[x][y] = int.Parse(line[y].ToString());
                }
            }

            List<int> sizes = new List<int>();
            for (int x = 0; x < arr.Length; ++x)
            {
                for (int y = 0; y < arr[x].Length; ++y)
                {
                    int? centre = arr?[x]?[y];
                    if (centre == null || centre == 9) continue;

                    int size = 0;
                    ReturnSize(x, y, ref arr, ref size);
                    sizes.Add(size);
                    
                }
            }

            var s = sizes.ToArray();
            Array.Sort(s);

            int result = s[^1] * s[^2] * s[^3];//oof

            return result.ToString();
        }

        static void ReturnSize(int x, int y, ref int?[][] arr, ref int counter)
        {
            int? centre = arr?[x]?[y];
            if (centre == null) return;

            ++counter;
            arr[x][y] = null;
            
            int? top = null, right = null, down = null, left = null;
            if (y + 1 < arr[x].Length) top = arr?[x]?[y + 1];
            if (x + 1 < arr.Length) right = arr?[x + 1]?[y];
            if (y - 1 >= 0) down = arr?[x]?[y - 1];
            if (x - 1 >= 0) left = arr?[x - 1]?[y];

            if (top != null && top != 9) ReturnSize(x, y + 1,ref arr, ref counter);
            if (right != null && right != 9) ReturnSize(x + 1, y, ref arr, ref counter);
            if (down != null && down != 9) ReturnSize(x, y - 1, ref arr, ref counter);
            if (left != null && left != 9) ReturnSize(x-1, y, ref arr, ref counter);
        }
    }
}
