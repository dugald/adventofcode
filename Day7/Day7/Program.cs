using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Input.txt");
            List<Bag> bags = new List<Bag>();
            foreach (var line in lines)
            {
                bags.Add(new Bag(line));
            }
            Console.WriteLine($"There are {bags.Count} kinds of bags.");

            List<string> bagNames = new List<string>();
            bagNames.Add("shiny gold bag");
            var selectedBags = bags.Where(x => bagNames.Any(x.Contents.Keys.Contains)).ToList();
            while (selectedBags.Any())
            {
                foreach (var selectedBag in selectedBags)
                {
                    if (!bagNames.Contains(selectedBag.Description))
                        bagNames.Add(selectedBag.Description);
                }

                var newBagNames = selectedBags.Select(x => x.Description).ToList();
                selectedBags = bags.Where(x => newBagNames.Any(x.Contents.Keys.Contains)).ToList();
            }
            Console.WriteLine($"{bagNames.Count - 1} colors contain the shiny gold bag");
            var allBags = new AllBags( lines);
            Console.WriteLine($"{allBags.BagsInside("shiny gold bag") - 1} bags inside the shiny gold bag");
            Console.Read();

        }
    }
}
