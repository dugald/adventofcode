using System;
using System.IO;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Input.txt");
            var cipher = new Cipher(lines);
            Console.WriteLine($"The cipher's weakness is {cipher.Weakness()}");
            Console.WriteLine($"The cipher's range weakness is {cipher.RangeWeakness(cipher.Weakness())}");
        }
    }
}