using System;
using System.IO;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Input.txt");
            var navigator = new Navigator(lines);
            navigator.ProcessInstructions();
            Console.WriteLine($"The manhattan distance for this set is {navigator.Distance}");
        }
    }
}