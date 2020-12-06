namespace Day6
{
    public class Person
    {
        public char[] Answers { get; set; }

        public Person(string input)
        {
            Answers = input.ToCharArray();
        }
    }
}