using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace adventofcode.source
{
    public class LanternFish
    {
        public int timer;

        public LanternFish()
        {
            timer = 8;
        }

        public LanternFish(int timer)
        {
            this.timer = timer;
        }

        public bool ReduceAndSpawn()
        {
            if (timer == 0)
            {
                timer = 6;
                return true;
            }

            --timer;
            return false;
        }
    }

    public static class Day6
    {
        static int loops = 256;
        public static string Part1(string[] data)
        {
            int[] timers = data[0].Split(',').Select(x => int.Parse(x)).ToArray();
            List<LanternFish> fish = new List<LanternFish>();

            for (int i =0; i < timers.Length; ++i)
            {
                fish.Add(new LanternFish(timers[i]));
            }

            for (int i = 0; i < loops; ++i)
            {
                int count = fish.Count();
              
                for (int f = 0; f < count; ++f)
                {
                    if (fish[f].ReduceAndSpawn())
                    {
                        fish.Add(new LanternFish());
                    }
                }
            }

            return fish.Count().ToString();
        }

        static int days = 7;
        static int startDays = 9;

        //42 mins at 256
        public static string Part2(string[] data)
        {
            int[] timers = data[0].Split(',').Select(x => int.Parse(x)).ToArray();

            ConcurrentBag<long> fish = new ConcurrentBag<long>();
            fish.Add(timers.Length);

            int initialStep = loops;
            Parallel.For (0, timers.Length, (i) => 
            {
                long local = 0;
                int firstSpawn = (initialStep - timers[i]);
                int children = (int)Math.Ceiling(firstSpawn / (double)days);

                for (int c = 0; c < children; ++c)
                {
                    int spawnPoint = firstSpawn - (c * days);
                    SpawnFish(ref local, spawnPoint);
                }

                Console.WriteLine("fish:" + fish.Count + " " + local);
                fish.Add(local);
            });

            BigInteger bigInt = new BigInteger(0);
            foreach(var num in fish)
            {
                bigInt += num;
            }

            return bigInt.ToString();
        }

        public static string Part2_Good(string[] data)
        {
            int[] timers = data[0].Split(',').Select(x => int.Parse(x)).ToArray();

            long[] map = new long[9];

            foreach (int item in timers)
            {
                ++map[item];
            }

            for (int i = 0; i < 256; i++)
            {
                long[] newArr = new long[9];
                for (int f = 1; f < 9; ++f)
                {
                    newArr[f - 1] = map[f];
                }

                newArr[6] += map[0];
                newArr[8] += map[0];

                map = newArr;
            }

            return map.Sum().ToString();
        }

        static void SpawnFish(ref long number, int start)
        {
            ++number;

            int firstSpawn = start - startDays;

            if (firstSpawn <= 0)
            {
                return;
            }

            int children = (int)Math.Ceiling(firstSpawn / (double)days);
            for (int i = 0; i < children; ++i)
            {
                int spawnPoint = firstSpawn - (i * days);
                SpawnFish(ref number, spawnPoint);
            }
        }
    }
}
