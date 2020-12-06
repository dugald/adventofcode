using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public class Group
    {
        public List<Person> Persons { get; set; }

        public Group()
        {
            Persons = new List<Person>();
        }

        public int Count()
        {
            //return Persons.SelectMany(x => x.Answers).Distinct().Count();
            var allAnswers = Persons.SelectMany(x => x.Answers);
            var answers = Persons.SelectMany(x => x.Answers).Distinct();
            var count = 0;
            foreach (var answer in answers)
            {
                if (allAnswers.Count(x => x == answer) == Persons.Count)
                    count++;
            }

            return count;
        }
    }
}