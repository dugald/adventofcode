using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Day4
{
    public class Passport
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(BirthYear) &&
                   !string.IsNullOrWhiteSpace(IssueYear) &&
                   !string.IsNullOrWhiteSpace(ExpirationYear) &&
                   !string.IsNullOrWhiteSpace(Height) &&
                   !string.IsNullOrWhiteSpace(HairColor) &&
                   !string.IsNullOrWhiteSpace(EyeColor) &&
                   !string.IsNullOrWhiteSpace(PassportId) &&
                   BirthYearValid() && IssueYearValid() && ExpirationYearValid() && ValidHeight() && ValidHairColor() && ValidEyeColor() && ValidPassportId();

        }

        private bool BirthYearValid()
        {
            return ValidYear(BirthYear, 1920, 2002);
        }

        private bool IssueYearValid()
        {
            return ValidYear(IssueYear, 2010, 2020);
        }

        private bool ExpirationYearValid()
        {
            return ValidYear(ExpirationYear, 2020, 2030);
        }

        private bool ValidYear(string yearValue, int minYear, int maxYear)
        {
            if (yearValue.Length != 4)
                return false;
            if (!int.TryParse(yearValue, out var year))
                return false;
            return minYear <= year && year <= maxYear;
        }

        private bool ValidHeight()
        {
            int heightValue;
            if (Height.EndsWith("in"))
            {
                if (!int.TryParse(Height.Replace("in", ""), out heightValue))
                    return false;
                return 59 <= heightValue && heightValue <= 76;
            }
            if (Height.EndsWith("cm"))
            {
                if (!int.TryParse(Height.Replace("cm", ""), out heightValue))
                    return false;
                return 150 <= heightValue && heightValue <= 193;
            }
            return false;
        }

        private bool ValidHairColor()
        {
            // regex
            Regex regex = new Regex(@"^#[a-f0-9]{6,}$");
            return regex.IsMatch(HairColor);
        }

        private bool ValidEyeColor()
        {
            List<string> validColors = new List<string> {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
            return validColors.Contains(EyeColor);
        }

        private bool ValidPassportId()
        {
            return PassportId.Length == 9 && int.TryParse(PassportId, out var num);
        }

        public void LoadData(string data)
        {
            var dataElements = data.Split(' ');
            foreach (var element in dataElements)
            {
                var values = element.Split(':');
                switch (values[0])
                {
                    case "byr":
                        BirthYear = values[1];
                        break;
                    case "iyr":
                        IssueYear = values[1];
                        break;
                    case "eyr":
                        ExpirationYear = values[1];
                        break;
                    case "hgt":
                        Height = values[1];
                        break;
                    case "hcl":
                        HairColor = values[1];
                        break;
                    case "ecl":
                        EyeColor = values[1];
                        break;
                    case "pid":
                        PassportId = values[1];
                        break;
                    case "cid":
                        CountryId = values[1];
                        break;
                }
            }
        }
    }
}
