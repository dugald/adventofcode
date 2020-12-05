using System;

namespace Day5
{
    public class BinarySeat
    {
        public BinarySeat(string data)
        {
            string row = data.Substring(0, 7).Replace("F","0").Replace("B","1");
            Row = Convert.ToInt32(row, 2);
            string seat = data.Substring(7).Replace("R","1").Replace("L","0");
            Seat = Convert.ToInt32(seat, 2);
        }

        public int Row { get; set; }
        public int Seat { get; set; }

        public int SeatId()
        {
            return Row * 8 + Seat;
        }
    }
}