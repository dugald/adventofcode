using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day10
{
    public class AdapterList
    {
        public int OneJolts { get; set; }
        public int ThreeJolts { get; set; }
        public List<int> AdapterJoltages { get; set; }

        public AdapterList(string[] input)
        {
            OneJolts = 0;
            ThreeJolts = 0;
            AdapterJoltages = input.Select(x => Convert.ToInt32(x)).ToList();
            AdapterJoltages.Add(0);
            AdapterJoltages.Add(AdapterJoltages.Max() + 3);
            AdapterJoltages.Sort();
        }

        public void TraverseAdapters()
        {
            for (int i = 0; i < AdapterJoltages.Count -1; i++)
            {
                if (AdapterJoltages[i] + 1 == AdapterJoltages[i + 1])
                    OneJolts++;
                if (AdapterJoltages[i] + 3 == AdapterJoltages[i + 1])
                    ThreeJolts++;
            }
        }

        public long JoltagesArrangements()
        {
            Dictionary<int, long> cache = new Dictionary<int, long>();
            return CountValidPaths(AdapterJoltages.ToArray(), cache);
        }

        private long CountValidPaths(int[] voltages, Dictionary<int, long> cache)
        {
            //var voltagesSize = new string('X', voltages.Length);
            //Console.WriteLine(voltagesSize);
            if (voltages.Length == 1)
                return 1;
            else
            {
                long sum = 0;
                int i = 1;
                while (i < voltages.Length && voltages[i] - voltages[0] <= 3)
                {
                    if (cache.ContainsKey(voltages[i]))
                        sum += cache[voltages[i]];
                    else
                    {
                        var count = CountValidPaths(voltages[i..], cache);
                        sum += count;
                        cache[voltages[i]] = count;
                    }
                    i++;
                }

                return sum;
            }
        }

        public int AdapterListScore()
        {
            return OneJolts * ThreeJolts;
        }
    }
}