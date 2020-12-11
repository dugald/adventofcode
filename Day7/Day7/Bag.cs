using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Day7
{
    public class Bag
    {
        public string Description { get; set; }
        public Dictionary<string, int> Contents { get; set; }

        public Bag(string data)
        {
            Contents = new Dictionary<string, int>();
            Description = data.Split(" contain ").First().TrimEnd('s');

            if (data.Contains(" contain ") && !data.Contains("no other bags"))
            {
                var contents = data.Split(" contain ")[1];
                foreach (var description in contents.Split(',').Select(x => x.Trim().TrimEnd('.').TrimEnd('s')))
                {
                    int count = Convert.ToInt32(description.Substring(0, description.IndexOf(' ')));
                    string bagInfo = description.Substring(description.IndexOf(' ') + 1);
                    Contents.Add(bagInfo, count);
                }
            }
        }

        public bool HasBag(string bagDescription)
        {
            if (Description == bagDescription)
                return true;
            else
            {
                foreach (var bag in Contents)
                {
                    return bag.Key.Equals(bagDescription);
                }
            }
            return false;
        }
    }
}