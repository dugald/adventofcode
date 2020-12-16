using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Day15
{
    public class CountingGame
    {
        public int[] NumbersSpoken { get; set; }
        public List<Number> Numbers { get; set; }

        public CountingGame()
        {
            Numbers = new List<Number>();
            NumbersSpoken = new int[] {};
        }

        public void Seed(IEnumerable<int> input)
        {
            int j = 0;
            foreach (var i in input)
            {
                NumbersSpoken = NumbersSpoken.Concat(new int[] {i}).ToArray();
                Numbers.Add(new Number {Value = i, PreviouslySpoken = new int[] { j++ } });
            }
        }
        public int GetNextNumber()
        {
            var lastNumberSpoken = NumbersSpoken[NumbersSpoken.Length - 1];
            var numberInfo = Numbers.First(x => x.Value == lastNumberSpoken);
            int newNumber;
            if (numberInfo.IsNew)
            {
                newNumber = 0;
            }
            else
            {
                newNumber = numberInfo.PreviouslySpoken[1] - numberInfo.PreviouslySpoken[0];
            }
            if (!Numbers.Any(x => x.Value == newNumber))
            {
                var number = new Number { Value = newNumber };
                number.PreviouslySpoken = new int[] { NumbersSpoken.Length };
                Numbers.Add(number);
            }
            else
            {
                //Numbers.First(x => x.Value == newNumber).IsNew = false;
                var number = Numbers.First(x => x.Value == newNumber);
                if (number.PreviouslySpoken.Length == 2)
                {
                    number.PreviouslySpoken[0] = number.PreviouslySpoken[1];
                    number.PreviouslySpoken[1] = NumbersSpoken.Length;
                }
                if (number.PreviouslySpoken.Length == 1)
                {
                    number.PreviouslySpoken = number.PreviouslySpoken.Concat(new int[] { NumbersSpoken.Length} ).ToArray();
                }
            }
            NumbersSpoken = NumbersSpoken.Concat(new int[] { newNumber }).ToArray();
            return newNumber;
        }

        public int GetXthNumber(int x)
        {
            while (NumbersSpoken.Length < x)
                GetNextNumber();
            return NumbersSpoken[x - 1];
        }
    }
    
    public class Number
    {
        public bool IsNew => PreviouslySpoken.Length <= 1;
        public int[] PreviouslySpoken { get; set; }
        public int Value { get; set; }
    }
}