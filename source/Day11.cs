using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace adventofcode.source
{
    public static class Day11
    {
        public static string Part1(string[] data)
        {
            int[][] arr = new int[data.Length][];
            int[][] newArray = new int[data.Length][];
            long flashes = 0;
            for (int x = 0; x < data.Length; ++x)
            {
                string line = data[x];
                arr[x] = new int[line.Length];
                newArray[x] = new int[line.Length];
                for (int y = 0; y < line.Length; ++y)
                {
                    arr[x][y] = int.Parse(line[y].ToString());
                    newArray[x][y] = arr[x][y];
                }
            }

            for (int i = 0; i <100; ++i)
            {
                Console.WriteLine("day " + i.ToString());
                for (int ix = 0; ix < arr.Length; ++ix)
                {
                    for (int iy = 0; iy < arr[ix].Length; ++iy)
                    {
                        Console.Write(arr[ix][iy]);
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");

                IncreaseAll(ref arr);
                Flash(ref arr, ref flashes);
            }

            return flashes.ToString();
        }

        public static string Part2(string[] data)
        {
            int[][] arr = new int[data.Length][];
            int[][] newArray = new int[data.Length][];
            long flashes = 0;
            for (int x = 0; x < data.Length; ++x)
            {
                string line = data[x];
                arr[x] = new int[line.Length];
                newArray[x] = new int[line.Length];
                for (int y = 0; y < line.Length; ++y)
                {
                    arr[x][y] = int.Parse(line[y].ToString());
                    newArray[x][y] = arr[x][y];
                }
            }

            int step = 0;
            bool sync = false;
            while(!sync)
            {
                ++step;
                for (int ix = 0; ix < arr.Length; ++ix)
                {
                    for (int iy = 0; iy < arr[ix].Length; ++iy)
                    {
                        Console.Write(arr[ix][iy]);
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");

                IncreaseAll(ref arr);
                Flash(ref arr, ref flashes);

                sync = true;

                for (int ix = 0; ix < arr.Length; ++ix)
                {
                    for (int iy = 0; iy < arr[ix].Length; ++iy)
                    {
                        if (arr[ix][iy] != 0) sync = false;
                    }
                }

            }

            return step.ToString();
        }

        private static void IncreaseAll(ref int[][] arr)
        {
            for (int x = 0; x < arr.Length; ++x)
            {
                for (int y = 0; y < arr[x].Length; ++y)
                {
                    ++arr[x][y];
                }
            }
        }

        private static void Flash(ref int[][] arr, ref long flashes)
        {
            for (int x = 0; x < arr.Length; ++x)
            {
                for (int y = 0; y < arr[x].Length; ++y)
                {
                    if (arr[x][y] > 9) Propigate(x,y,ref arr, ref flashes);
                }
            }
        }

        private static void Propigate(int x, int y, ref int[][] arr, ref long flashes)
        {
            if (arr[x][y] == 0) return;
            if (arr[x][y] > 9)
            {
                arr[x][y] = 0;
                ++flashes;
                for (int _x = x-1; _x <= x+1; ++_x)
                {
                    for (int _y = y-1; _y <= y+1; ++_y)
                    {
                        if (_x == x && _y == y) continue;
                        if (_x < 0 || _x >= arr.Length) continue;
                        if (_y < 0 || _y >= arr[_x].Length) continue;

                        if (arr[_x][_y] != 0)
                        {
                            ++arr[_x][_y];
                            Propigate(_x, _y, ref arr, ref flashes);
                        }
                    }
                }
            }
        }
    }
}
