using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var groups = new List<Group>();
            var lines = File.ReadAllLines("Input.txt");
            var group = new Group();
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    group.Persons.Add(new Person(line));
                }
                else
                {
                    groups.Add(group);
                    group = new Group();
                }
            }
            groups.Add(group);
            Console.WriteLine($"The sum of counts is: {groups.Sum(x => x.Count())}");
            Console.Read();
        }
    }
}