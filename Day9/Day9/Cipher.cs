using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day9
{
    public class Cipher
    {
        public long[] Values { get; set; }

        public Cipher(string[] input)
        {
            Values = input.Select(x => Convert.ToInt64(x)).ToArray();
        }

        public long Weakness()
        {
            for (int i = 25; i < Values.Length; i++)
            {
                if (!HasSum(Values[i], Values[(i - 25)..i]))
                    return Values[i];
            }

            return -1;
        }

        public long RangeWeakness(long target)
        {
            for (int i = 0; i < Values.Length; i ++)
            {
                for (int j = i + 1; j < Values.Length; j++)
                {
                    if (Values[i..j].Sum() == target)
                        return Values[i..j].Min() + Values[i..j].Max();
                    if (Values[i..j].Sum() > target)
                        break;
                }
            }
            return 1;
        }

        private bool HasSum(long target, long[] possibleValues)
        {
            for (int i = 0; i < possibleValues.Length; i++)
            {
                for (int j = i + 1; j < possibleValues.Length; j++)
                {
                    if (possibleValues[i] + possibleValues[j] == target)
                        return true;
                }
            }
            return false;
        }
    }
}