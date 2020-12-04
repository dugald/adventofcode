using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = File.Open("Input.txt", FileMode.Open);
            var reader = new StreamReader(stream);
            string line;

            IList<Passport> passports = new List<Passport>();
            var passport = new Passport();
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    passports.Add(passport);
                    passport = new Passport();
                }
                passport.LoadData(line);
            }
            passports.Add(passport);
            Console.WriteLine($"Valid passports: {passports.Count(x => x.IsValid())}");
            Console.Read();
        }
    }
}
