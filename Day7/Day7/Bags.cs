using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day7
{
    public class AllBags
    {
        public List<Bag> Bags { get; set; }

        public int BagsInside(string bagName)
        {
            var bag = Bags.FirstOrDefault(x => x.Description == bagName);
            if (!bag.Contents.Any())
                return 1;
            var sum = 1;
            foreach (var bagContent in bag.Contents)
            {
                sum += bagContent.Value * BagsInside(bagContent.Key);
            }

            return sum;
        }

        public AllBags(string[] input)
        {
            Bags = new List<Bag>();
            foreach (var line in input)
            {
                Bags.Add(new Bag(line));
            }
        }
    }
}