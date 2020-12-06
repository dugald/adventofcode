using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main()
        {
            List<BinarySeat> seats = new List<BinarySeat>();
            var inputLines = File.ReadAllLines("Input.txt").Select(x => x.Trim());
            foreach (var line in inputLines)
            {
                seats.Add(new BinarySeat(line));
            }

            Console.WriteLine($"Highest score: {seats.Max(x => x.SeatId())}");

            var sortedSeats = seats.OrderBy(x => x.SeatId()).ToArray();
            for (int i = 0; i < sortedSeats.Length -1; i++)
            {
                if (sortedSeats[i].SeatId() + 2 == sortedSeats[i+1].SeatId())
                    Console.WriteLine($"Possible Seat between {sortedSeats[i].SeatId()} and {sortedSeats[i + 1].SeatId()}");
            }
            Console.Read();
        }
    }
}
