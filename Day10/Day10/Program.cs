using System;
using System.IO;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("Input.txt");
            var adapters = new AdapterList(input);
            adapters.TraverseAdapters();
            Console.WriteLine($"Adapters score is: {adapters.AdapterListScore()}");
            Console.WriteLine($"{adapters.JoltagesArrangements()} arrangements");
        }
    }
}